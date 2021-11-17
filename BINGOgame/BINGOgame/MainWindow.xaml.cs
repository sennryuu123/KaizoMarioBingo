using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Collections.ObjectModel;


namespace BINGOgame
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        /* スター名と、スター名称 */
        string hack_name;                           /* ハック名 */
        string[] normal_star_list = new string[256]; /* ノーマルスター  */
        string[] reds_star_list = new string[256]; /* 赤コインスター  */
        string[] coins_star_list = new string[256]; /* 100コインスター */
        string[] selected_star_list = new string[256 * 4];
        string[] bingo_card_list = new string[256 * 4];
        int normal_star_num;
        int reds_star_num;
        int coins_star_num;
        int selected_star_num;
        ObservableCollection<STAR_NAME_INFO> normalStarNameInfo = new ObservableCollection<STAR_NAME_INFO>();
        ObservableCollection<STAR_NAME_INFO> redsStarNameInfo   = new ObservableCollection<STAR_NAME_INFO>();
        ObservableCollection<STAR_NAME_INFO> coinsStarNameInfo  = new ObservableCollection<STAR_NAME_INFO>();
        List<STAR_INFO> starList = new List<STAR_INFO>();
        List<STAR_INFO> selectedStarList = new List<STAR_INFO>();
        List<STAR_INFO> bingoCardList = new List<STAR_INFO>();

        public enum result_t
        {
            OK = 0,
            NG
        };

        public class STAR_INFO
        {
            public int offset;
            public string course;
            public int num;
            public string name;
        }

        public class STAR_NAME_INFO
        {
            public bool chk { get; set; }
            public string name { get; set; }
        }

        public MainWindow()
        {    
            /* テキストファイルからデータを読み出す */
            if (result_t.NG == textRead())
            {
                Application.Current.Shutdown();
            }

            InitializeComponent();

            /* 設定メニューを表示する */
            configMenuShow();
        }

        /// <summary>
        /// テキストファイルからデータを読み出して、グローバル変数に格納する
        /// テキストファイルのパスは実行ファイルと同じにする
        /// 
        /// return result_t 
        /// </summary>
        public result_t textRead()
        {
            /* テキスト読み出し */
            using (StreamReader sr = new StreamReader("config.txt"))
            {
                bool flag_hack = false;
                bool flag_normal = false;
                bool flag_reds = false;
                bool flag_coins = false;
                string oneLine;
                string[] temp;
                int i = 0;

                while (!sr.EndOfStream)
                {
                    oneLine = sr.ReadLine();

                    /* block確認 */

                    /* ハック名取得 */
                    if (oneLine.Equals("1:"))
                    {
                        while (!sr.EndOfStream)
                        {
                            oneLine = sr.ReadLine();

                            if (oneLine.Equals("end:"))
                            {
                                /* 終了 */
                                flag_hack = true;
                                break;
                            }

                            temp = oneLine.Split(';');
                            hack_name = temp[0];
                        }
                    }
                    /* ノーマルスター取得 */
                    else if (oneLine.Equals("2:"))
                    {
                        i = 0;
                        while (!sr.EndOfStream)
                        {
                            oneLine = sr.ReadLine();

                            if (oneLine.Equals("end:"))
                            {
                                /* 終了 */
                                normal_star_num = i;
                                flag_normal = true;
                                break;
                            }

                            STAR_INFO star_info = new STAR_INFO();

                            temp = oneLine.Split(';');

                            /* ;が足りていなかったらエラー */
                            if (temp.Contains(null))
                            {
                                return (result_t.NG);
                            }

                            /* オフセット取得 */
                            if (!int.TryParse(temp[0], out star_info.offset))
                            {
                                return (result_t.NG);
                            }

                            /* コース名取得 */
                            star_info.course = temp[1];

                            /* スター番号取得 */
                            if (!int.TryParse(temp[2], out star_info.num))
                            {
                                return (result_t.NG);
                            }

                            /* スター名取得 */
                            star_info.name = temp[3];

                            starList.Add(star_info);

                            /* 設定画面に表示する名称を追加 */
                            normal_star_list[i++] = temp[1] + " Star " + temp[2] + " " + temp[3];
                        }
                    }
                    /* 赤コインスター取得 */
                    else if (oneLine.Equals("3:"))
                    {
                        i = 0;
                        while (!sr.EndOfStream)
                        {
                            oneLine = sr.ReadLine();

                            if (oneLine.Equals("end:"))
                            {
                                /* 終了 */
                                reds_star_num = i;
                                flag_reds = true;
                                break;
                            }

                            STAR_INFO star_info = new STAR_INFO();

                            temp = oneLine.Split(';');

                            /* ;が足りていなかったらエラー */
                            if (temp.Contains(null))
                            {
                                return (result_t.NG);
                            }

                            /* オフセット取得 */
                            if (!int.TryParse(temp[0], out star_info.offset))
                            {
                                return (result_t.NG);
                            }

                            /* コース名取得 */
                            star_info.course = temp[1];

                            /* スター番号取得 */
                            if (!int.TryParse(temp[2], out star_info.num))
                            {
                                return (result_t.NG);
                            }

                            /* スター名取得 */
                            star_info.name = temp[3];

                            starList.Add(star_info);

                            /* 設定画面に表示する名称を追加 */
                            reds_star_list[i++] = temp[1] + " Star " + temp[2] + " " + temp[3];
                        }
                    }
                    /* 100コインスター取得 */
                    else if (oneLine.Equals("4:"))
                    {
                        i = 0;
                        while (!sr.EndOfStream)
                        {
                            oneLine = sr.ReadLine();

                            if (oneLine.Equals("end:"))
                            {
                                /* 終了 */
                                coins_star_num = i;
                                flag_coins = true;
                                break;
                            }

                            STAR_INFO star_info = new STAR_INFO();

                            temp = oneLine.Split(';');

                            /* ;が足りていなかったらエラー */
                            if (temp.Contains(null))
                            {
                                return (result_t.NG);
                            }

                            /* オフセット取得 */
                            if (!int.TryParse(temp[0], out star_info.offset))
                            {
                                return (result_t.NG);
                            }

                            /* コース名取得 */
                            star_info.course = temp[1];

                            /* スター番号取得 */
                            if (!int.TryParse(temp[2], out star_info.num))
                            {
                                return (result_t.NG);
                            }

                            /* スター名取得 */
                            star_info.name = temp[3];

                            starList.Add(star_info);

                            /* 設定画面に表示する名称を追加 */
                            coins_star_list[i++] = temp[1] + " Star " + temp[2] + " " + temp[3];
                        }
                    }
                    else
                    {
                        return (result_t.NG);
                    }
                }

                if ((flag_hack == true) &&
                    (flag_normal == true) &&
                    (flag_reds == true) &&
                    (flag_coins == true))
                {
                    return (result_t.OK);
                }
                else
                {
                    MessageBox.Show("config.txtの内容が不適です。");
                    return (result_t.NG);
                }
            }
        }

        /// <summary>
        /// 以下を設定するウィンドウを表示する
        /// ビンゴサイズ
        /// 配置するスター
        /// シード値
        /// 
        /// return result_t 
        /// </summary>
        public result_t configMenuShow()
        {
            result_t ret = result_t.OK;

            for (int i = 3; i <= 9; i++) 
            {
                ComboBox_BingoSize.Items.Add(i);
            }
            
            ComboBox_BingoSize.SelectedValue = 5;

            return (ret);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            listbox_normal.ItemsSource = normalStarNameInfo;
            listbox_reds.ItemsSource   = redsStarNameInfo;
            listbox_coins.ItemsSource  = coinsStarNameInfo;
        }

        private void all_chk_normal_checked(object sender, RoutedEventArgs e)
        {
            normalStarNameInfo.Clear();

            int i;
            for (i = 0; i < normal_star_num; i++)
            {
                STAR_NAME_INFO temp = new STAR_NAME_INFO();
                temp.chk = true;
                temp.name = normal_star_list[i];
                normalStarNameInfo.Add(temp);
            }
        }

        private void all_chk_normal_unchecked(object sender, RoutedEventArgs e)
        {
            normalStarNameInfo.Clear();

            int i;
            for (i = 0; i < normal_star_num; i++)
            {
                STAR_NAME_INFO temp = new STAR_NAME_INFO();
                temp.chk = false;
                temp.name = normal_star_list[i];
                normalStarNameInfo.Add(temp);
            }
        }

        private void all_chk_reds_checked(object sender, RoutedEventArgs e)
        {
            redsStarNameInfo.Clear();

            int i;
            for (i = 0; i < reds_star_num; i++)
            {
                STAR_NAME_INFO temp = new STAR_NAME_INFO();
                temp.chk = true;
                temp.name = reds_star_list[i];
                redsStarNameInfo.Add(temp);
            }
        }

        private void all_chk_reds_unchecked(object sender, RoutedEventArgs e)
        {
            redsStarNameInfo.Clear();

            int i;
            for (i = 0; i < reds_star_num; i++)
            {
                STAR_NAME_INFO temp = new STAR_NAME_INFO();
                temp.chk = false;
                temp.name = reds_star_list[i];
                redsStarNameInfo.Add(temp);
            }
        }

        private void all_chk_coins_checked(object sender, RoutedEventArgs e)
        {
            coinsStarNameInfo.Clear();

            int i;
            for (i = 0; i < coins_star_num; i++)
            {
                STAR_NAME_INFO temp = new STAR_NAME_INFO();
                temp.chk = true;
                temp.name = coins_star_list[i];
                coinsStarNameInfo.Add(temp);
            }
        }

        private void all_chk_coins_unchecked(object sender, RoutedEventArgs e)
        {
            coinsStarNameInfo.Clear();

            int i;
            for (i = 0; i < coins_star_num; i++)
            {
                STAR_NAME_INFO temp = new STAR_NAME_INFO();
                temp.chk = false;
                temp.name = coins_star_list[i];
                coinsStarNameInfo.Add(temp);
            }
        }


        private void OK_Button_Click(object sender, RoutedEventArgs e)
        {
            int bingo_size;
            int upper_star_num;
            int seed;
            int i;

            /* 配置するスターリスト取得 */
            i = 0;
            foreach (var starInfo in normalStarNameInfo)
            {
                if (starInfo.chk)
                {
                    selectedStarList.Add(starList[i]);
                }
                i++;
            }

            foreach (var starInfo in redsStarNameInfo)
            {
                if (starInfo.chk)
                {
                    selectedStarList.Add(starList[i]);
                }
                i++;
            }

            foreach (var starInfo in coinsStarNameInfo)
            {
                if (starInfo.chk)
                {
                    selectedStarList.Add(starList[i]);
                }
                i++;
            }

            selected_star_num = selectedStarList.Count;
            bingo_size = (int)ComboBox_BingoSize.SelectedItem;
            upper_star_num = bingo_size * bingo_size;

            /* シード値取得 */
            if (upper_star_num > selected_star_num)
            {
                MessageBox.Show("スター数が不足しています。");
                return;
            }

            /* シード値が空の場合は、ランダムなシード値を設定する  */
            if (TextBox_Seed.Text == "")
            {
                seed = new Random().Next(0, 999999999);
            }
            else 
            {
                /* シード値が数値か判定する  */
                if (!int.TryParse(TextBox_Seed.Text, out seed))
                {
                    MessageBox.Show("シード値が数値ではありません。");
                    return;
                }

                /* シード値の桁数が9桁以下か判定する  */
                if (9 < (seed.ToString().Length))
                {
                    MessageBox.Show("シード値が大きすぎます。");
                    return;
                }
            }

            System.Diagnostics.Debug.WriteLine("seed値:" + seed.ToString());

            /* ビンゴカードに配置するスターを取得 */
            int[] bingo_card_list_index = Enumerable.Repeat<int>(-1, 10 * 10).ToArray(); /* ビンゴサイズの最大値+1 */
            int temp_index;
            int cnt = 0;

            /* ビンゴカードウィンドウを作成する */

            seed += bingo_size;
            Random rnd = new Random(seed);

            while (cnt < upper_star_num)
            {
                temp_index = rnd.Next(0, selected_star_num);

                if (bingo_card_list_index.Contains(temp_index))
                {
                    continue;
                }

                bingo_card_list_index[cnt] = temp_index;               /* 同値判定用配列に格納 */

                bingoCardList.Add(selectedStarList[temp_index]);
                System.Diagnostics.Debug.WriteLine(bingo_card_list[cnt]);

                cnt++;
            }

            switch (bingo_size) 
            {
                case 3:
                    var bingo_card3 = new bingoWindow3(hack_name, seed, bingo_size, bingoCardList);
                    bingo_card3.Show();
                    break;

                case 4:
                    var bingo_card4 = new bingoWindow4(hack_name, seed, bingo_size, bingoCardList);
                    bingo_card4.Show();
                    break;

                case 5:
                    var bingo_card5 = new bingoWindow5(hack_name, seed, bingo_size, bingoCardList);
                    bingo_card5.Show();
                    break;

                case 6:
                    var bingo_card6 = new bingoWindow6(hack_name, seed, bingo_size, bingoCardList);
                    bingo_card6.Show();
                    break;

                case 7:
                    var bingo_card7 = new bingoWindow7(hack_name, seed, bingo_size, bingoCardList);
                    bingo_card7.Show();
                    break;

                case 8:
                    var bingo_card8 = new bingoWindow8(hack_name, seed, bingo_size, bingoCardList);
                    bingo_card8.Show();
                    break;

                case 9:
                    var bingo_card9 = new bingoWindow9(hack_name, seed, bingo_size, bingoCardList);
                    bingo_card9.Show();
                    break;

                default:
                    MessageBox.Show("対応していないビンゴサイズです。");
                    break;
            }

            this.Close();
        }


        private void Reload_Button_Click(object sender, RoutedEventArgs e)
        {
            /* TBD */
        }
    }

}

