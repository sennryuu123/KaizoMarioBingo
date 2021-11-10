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
        string[] key_list = new string[256]; /* クッパキー      */
        string[] selected_star_list = new string[256 * 4];
        string[] bingo_card_list = new string[256 * 4];
        int normal_star_num;
        int reds_star_num;
        int coins_star_num;
        int key_num;
        int selected_star_num;
        ObservableCollection<StarInfo> normalStarInfo = new ObservableCollection<StarInfo>();
        ObservableCollection<StarInfo> redsStarInfo   = new ObservableCollection<StarInfo>();
        ObservableCollection<StarInfo> coinsStarInfo  = new ObservableCollection<StarInfo>();
        ObservableCollection<StarInfo> keyInfo        = new ObservableCollection<StarInfo>();

        public enum result_t
        {
            OK = 0,
            NG
        };

        public MainWindow()
        {
            /* テキストファイルからデータを読み出す */
            if (result_t.NG == textRead())
            {
                MessageBox.Show("config.txtの形式が正しくありません。");
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
                bool flag_key = false;
                string temp;
                int i = 0;

                while (!sr.EndOfStream)
                {
                    temp = sr.ReadLine();
                    if (temp == "ハック名:")
                    {
                        hack_name = sr.ReadLine();
                        flag_hack = true;
                    }

                    if (temp == "ノーマルスター:")
                    {
                        i = 0;
                        while (!sr.EndOfStream)
                        {
                            temp = sr.ReadLine();
                            if (temp == ";")
                            {
                                flag_normal = true;
                                break;
                            }
                            normal_star_list[i] = temp;
                            i++;
                        }
                        normal_star_num = i;
                    }

                    if (temp == "赤:")
                    {
                        i = 0;
                        while (!sr.EndOfStream)
                        {
                            temp = sr.ReadLine();
                            if (temp == ";")
                            {
                                flag_reds = true;
                                break;
                            }

                            reds_star_list[i] = temp;
                            i++;
                        }
                        reds_star_num = i;
                    }

                    if (temp == "100:")
                    {
                        i = 0;
                        while (!sr.EndOfStream)
                        {
                            temp = sr.ReadLine();
                            if (temp == ";")
                            {
                                flag_coins = true;
                                break;
                            }

                            coins_star_list[i] = temp;
                            i++;
                        }
                        coins_star_num = i;
                    }

                    if (temp == "Key:")
                    {
                        i = 0;
                        while (!sr.EndOfStream)
                        {
                            temp = sr.ReadLine();
                            if (temp == ";")
                            {
                                flag_key = true;
                                break;
                            }

                            key_list[i] = temp;
                            i++;
                        }
                        key_num = i;
                    }
                }

                if ((flag_hack == true) &&
                    (flag_normal == true) &&
                    (flag_reds == true) &&
                    (flag_coins == true) &&
                    (flag_key == true))
                {
#if false
                    MessageBox.Show("Success!!");
                    MessageBox.Show(hack_name, "ハック名");
                    MessageBox.Show(normal_star_list[0], "ノーマルスター");
                    MessageBox.Show(reds_star_list[0], "赤");
                    MessageBox.Show(coins_star_list[0], "100");
                    MessageBox.Show(key_list[0], "キー");
#endif
                    return (result_t.OK);
                }
                else
                {
                    MessageBox.Show("Please Check Config.txt GG!!!");
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
            listbox_normal.ItemsSource = normalStarInfo;
            listbox_reds.ItemsSource   = redsStarInfo;
            listbox_coins.ItemsSource  = coinsStarInfo;
            listbox_key.ItemsSource    = keyInfo;
        }

        public class StarInfo
        {
            public bool chk { get; set; }
            public string name { get; set; }
        }

        private void all_chk_normal_checked(object sender, RoutedEventArgs e)
        {
            normalStarInfo.Clear();

            int i;
            for (i = 0; i < normal_star_num; i++)
            {
                StarInfo test = new StarInfo();
                test.chk = true;
                test.name = normal_star_list[i].Replace("@", " ");
                normalStarInfo.Add(test);
            }
        }

        private void all_chk_normal_unchecked(object sender, RoutedEventArgs e)
        {
            normalStarInfo.Clear();

            int i;
            for (i = 0; i < normal_star_num; i++)
            {
                StarInfo test = new StarInfo();
                test.chk = false;
                test.name = normal_star_list[i].Replace("@", " ");
                normalStarInfo.Add(test);
            }
        }

        private void all_chk_reds_checked(object sender, RoutedEventArgs e)
        {
            redsStarInfo.Clear();

            int i;
            for (i = 0; i < reds_star_num; i++)
            {
                StarInfo test = new StarInfo();
                test.chk = true;
                test.name = reds_star_list[i].Replace("@", " ");
                redsStarInfo.Add(test);
            }
        }

        private void all_chk_reds_unchecked(object sender, RoutedEventArgs e)
        {
            redsStarInfo.Clear();

            int i;
            for (i = 0; i < reds_star_num; i++)
            {
                StarInfo test = new StarInfo();
                test.chk = false;
                test.name = reds_star_list[i].Replace("@", " ");
                redsStarInfo.Add(test);
            }
        }

        private void all_chk_coins_checked(object sender, RoutedEventArgs e)
        {
            coinsStarInfo.Clear();

            int i;
            for (i = 0; i < coins_star_num; i++)
            {
                StarInfo test = new StarInfo();
                test.chk = true;
                test.name = coins_star_list[i].Replace("@", " ");
                coinsStarInfo.Add(test);
            }
        }

        private void all_chk_coins_unchecked(object sender, RoutedEventArgs e)
        {
            coinsStarInfo.Clear();

            int i;
            for (i = 0; i < coins_star_num; i++)
            {
                StarInfo test = new StarInfo();
                test.chk = false;
                test.name = coins_star_list[i].Replace("@", " ");
                coinsStarInfo.Add(test);
            }
        }

        private void all_chk_key_checked(object sender, RoutedEventArgs e)
        {
            keyInfo.Clear();

            int i;
            for (i = 0; i < key_num; i++)
            {
                StarInfo test = new StarInfo();
                test.chk = true;
                test.name = key_list[i].Replace("@", " ");
                keyInfo.Add(test);
            }
        }

        private void all_chk_key_unchecked(object sender, RoutedEventArgs e)
        {
            keyInfo.Clear();

            int i;
            for (i = 0; i < key_num; i++)
            {
                StarInfo test = new StarInfo();
                test.chk = false;
                test.name = key_list[i].Replace("@", " ");
                keyInfo.Add(test);
            }
        }

        private void OK_Button_Click(object sender, RoutedEventArgs e)
        {
            int selected_index = 0;
            int bingo_size;
            int upper_star_num;
            int seed;
            int i = 0;

            /* 配置するスターリスト取得 */
            i = 0;
            foreach (var starInfo in normalStarInfo)
            {
                if (starInfo.chk)
                {
                    selected_star_list[selected_index++] = normal_star_list[i];
                }
                i++;
            }

            i = 0;
            foreach (var starInfo in redsStarInfo)
            {
                if (starInfo.chk)
                {
                    selected_star_list[selected_index++] = reds_star_list[i];
                }
                i++;
            }

            i = 0;
            foreach (var starInfo in coinsStarInfo)
            {
                if (starInfo.chk)
                {
                    selected_star_list[selected_index++] = coins_star_list[i];
                }
                i++;
            }

            i = 0;
            foreach (var starInfo in keyInfo)
            {
                if (starInfo.chk)
                {
                    selected_star_list[selected_index++] = key_list[i];
                }
                i++;
            }

            selected_star_num = selected_index;
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

            Random rnd = new Random(seed);
            while (cnt < upper_star_num) 
            {
                temp_index = rnd.Next(0, selected_star_num);

                if (bingo_card_list_index.Contains(temp_index)) 
                {
                    continue;
                }

                bingo_card_list_index[cnt] = temp_index;               /* 同値判定用配列に格納 */
                bingo_card_list[cnt] = selected_star_list[temp_index]; /* ビンゴカードに使用するスター名を格納 */

                System.Diagnostics.Debug.WriteLine(bingo_card_list[cnt]);

                cnt++;
            }

            /* ビンゴカードウィンドウを作成する */
            var bingo_card = new bingoWindow(hack_name, seed, bingo_size, bingo_card_list);
            bingo_card.Show();


            this.Close();
        }

        private void Reload_Button_Click(object sender, RoutedEventArgs e)
        {
            /* テキストファイルからデータを読み出す */
            if (result_t.NG == textRead())
            {
                MessageBox.Show("config.txtの形式が正しくありません。");
                Application.Current.Shutdown();
            }

            normalStarInfo.Clear();
            redsStarInfo.Clear();
            coinsStarInfo.Clear();
            keyInfo.Clear();

            int i;
            for (i = 0; i < normal_star_num; i++)
            {
                StarInfo test = new StarInfo();
                test.chk = true;
                test.name = normal_star_list[i].Replace("@", " ");
                normalStarInfo.Add(test);
            }

            for (i = 0; i < reds_star_num; i++)
            {
                StarInfo test = new StarInfo();
                test.chk = true;
                test.name = reds_star_list[i].Replace("@", " ");
                redsStarInfo.Add(test);
            }

            for (i = 0; i < coins_star_num; i++)
            {
                StarInfo test = new StarInfo();
                test.chk = true;
                test.name = coins_star_list[i].Replace("@", " ");
                coinsStarInfo.Add(test);
            }


            for (i = 0; i < key_num; i++)
            {
                StarInfo test = new StarInfo();
                test.chk = true;
                test.name = key_list[i].Replace("@", " ");
                keyInfo.Add(test);
            }


        }
    }

}

