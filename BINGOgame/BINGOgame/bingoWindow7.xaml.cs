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
using System.Windows.Shapes;

using System.ComponentModel;
using System.Windows.Threading;
using System.Diagnostics;
using System.Threading;

namespace BINGOgame
{
    /// <summary>
    /// configWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class bingoWindow7 : Window
    {
        string Hack_name;
        int Seed;
        int Bingo_size;
        List<BINGOgame.MainWindow.STAR_INFO> Bingo_card_list = new List<BINGOgame.MainWindow.STAR_INFO>();
        MemoryManager mm;
        Thread magicThread;
        bool[] starGetFlag;
        public List<TextBlock> BingoTextList = new List<TextBlock>();
        static string[] processNames = {
            "project64", "project64d",
            "mupen64-rerecording",
            "mupen64-pucrash",
            "mupen64_lua",
            "mupen64-wiivc",
            "mupen64-RTZ",
            "mupen64-rerecording-v2-reset",
            "mupen64-rrv8-avisplit",
            "mupen64-rerecording-v2-reset",
            // "retroarch" 
        };

        /* タイマースタート */
        System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();

        public bingoWindow7(string hack_name, int seed, int bingo_size, List<BINGOgame.MainWindow.STAR_INFO> bingo_card_list)
        {
            InitializeComponent();

            TextBlock_Seed.Text = seed.ToString();
            this.Title = hack_name + " BINGO";

            Hack_name = hack_name;
            Seed = seed;
            Bingo_size = bingo_size;
            Bingo_card_list = bingo_card_list;

            System.Diagnostics.Debug.WriteLine("\n\n\nBINGO CARD");
            System.Diagnostics.Debug.WriteLine(seed.ToString());
            System.Diagnostics.Debug.WriteLine(bingo_size.ToString());
            System.Diagnostics.Debug.WriteLine(bingo_card_list[0].name);
            System.Diagnostics.Debug.WriteLine(bingo_card_list[bingo_size * bingo_size - 1].name);

            BingoTextList.Add(TextBlock_0_0);
            BingoTextList.Add(TextBlock_0_1);
            BingoTextList.Add(TextBlock_0_2);
            BingoTextList.Add(TextBlock_0_3);
            BingoTextList.Add(TextBlock_0_4);
            BingoTextList.Add(TextBlock_0_5);
            BingoTextList.Add(TextBlock_0_6);

            BingoTextList.Add(TextBlock_1_0);
            BingoTextList.Add(TextBlock_1_1);
            BingoTextList.Add(TextBlock_1_2);
            BingoTextList.Add(TextBlock_1_3);
            BingoTextList.Add(TextBlock_1_4);
            BingoTextList.Add(TextBlock_1_5);
            BingoTextList.Add(TextBlock_1_6);

            BingoTextList.Add(TextBlock_2_0);
            BingoTextList.Add(TextBlock_2_1);
            BingoTextList.Add(TextBlock_2_2);
            BingoTextList.Add(TextBlock_2_3);
            BingoTextList.Add(TextBlock_2_4);
            BingoTextList.Add(TextBlock_2_5);
            BingoTextList.Add(TextBlock_2_6);

            BingoTextList.Add(TextBlock_3_0);
            BingoTextList.Add(TextBlock_3_1);
            BingoTextList.Add(TextBlock_3_2);
            BingoTextList.Add(TextBlock_3_3);
            BingoTextList.Add(TextBlock_3_4);
            BingoTextList.Add(TextBlock_3_5);
            BingoTextList.Add(TextBlock_3_6);

            BingoTextList.Add(TextBlock_4_0);
            BingoTextList.Add(TextBlock_4_1);
            BingoTextList.Add(TextBlock_4_2);
            BingoTextList.Add(TextBlock_4_3);
            BingoTextList.Add(TextBlock_4_4);
            BingoTextList.Add(TextBlock_4_5);
            BingoTextList.Add(TextBlock_4_6);

            BingoTextList.Add(TextBlock_5_0);
            BingoTextList.Add(TextBlock_5_1);
            BingoTextList.Add(TextBlock_5_2);
            BingoTextList.Add(TextBlock_5_3);
            BingoTextList.Add(TextBlock_5_4);
            BingoTextList.Add(TextBlock_5_5);
            BingoTextList.Add(TextBlock_5_6);

            BingoTextList.Add(TextBlock_6_0);
            BingoTextList.Add(TextBlock_6_1);
            BingoTextList.Add(TextBlock_6_2);
            BingoTextList.Add(TextBlock_6_3);
            BingoTextList.Add(TextBlock_6_4);
            BingoTextList.Add(TextBlock_6_5);
            BingoTextList.Add(TextBlock_6_6);

            Thread thread = new Thread(new ThreadStart(bingoCtrlFromPj64));
            thread.Start();

            starGetFlag = new bool[bingo_size * bingo_size];

            for (int i = 0; i < starGetFlag.Length; i++)
            {
                starGetFlag[i] = false;
            }
        }

        private Process FindEmulatorProcess()
        {
            foreach (string name in processNames)
            {
                Process process = Process.GetProcessesByName(name).Where(p => !p.HasExited).FirstOrDefault();
                if (process != null)
                    return process;
            }

            return null;
        }

        public async void bingoCtrlFromPj64()
        {
        LABEL1:
            /* PJ64の起動を待つ */
            while (true)
            {
                Process process = FindEmulatorProcess();
                mm = new MemoryManager(process);

                if (!mm.ProcessActive())
                {
                    /* 起動したら抜ける */
                    break;
                }

                await Task.Delay(1000);
            }

            /* ハックをロードする */
            while (true)
            {
                if (mm.GetTitle().Contains("-"))
                {
                    /* ロードしたら抜ける */
                    break;
                }

                await Task.Delay(1000);
            }

            magicThread = new Thread(doMagicThread);
            magicThread.Start();

            while (true)
            {
                if (mm.isReadyToRead())
                    break;

                await Task.Delay(1000);
            }

            /* スター取得監視＆点灯処理開始 */
            byte[] stars = new byte[0x70];
            while (true)
            {
                if (!timer.IsRunning)
                {
                    continue;
                }

                if (mm.ProcessActive())
                {
                    /* 終了したらスレッドの先頭に戻る */
                    goto LABEL1;
                }

                if (!mm.isReadyToRead())
                {
                    /* 終了したらスレッドの先頭に戻る */
                    goto LABEL1;
                }

                /* スター更新 */
                mm.PerformRead();
                stars = mm.GetStars();

                int i;
                int offset;
                byte bit;
                for (i = 0; i < Bingo_card_list.Count; i++)
                {
                    offset = Bingo_card_list[i].offset;
                    bit = (byte)(1 << (Bingo_card_list[i].num - 1));

                    if ((stars[offset] & bit) == bit)
                    {
                        starGetFlag[i] = true;
                    }
                    else
                    {
                        starGetFlag[i] = false;
                    }
                }
                await Task.Delay(1000);
            }
        }

        private void doMagicThread()
        {
            bool isActive = !mm.ProcessActive();
            while (mm != null && isActive && !mm.isMagicDone())
            {
                try
                {
                    mm.doMagic();
                }
                catch (Exception) { }
            }
        }

        private void Start_Button_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < BingoTextList.Count; i++)
            {
                BingoTextList[i].Text = Bingo_card_list[i].course + " Star" + Bingo_card_list[i].num + "\n" + Bingo_card_list[i].name;
            }

            timer.Start(); /* 時刻表示用タイマー */
            SetupTimer();  /* 定期処理用タイマー */
            TextBlock_Timer.Text = timer.Elapsed.ToString(@"hh\:mm\:ss");
        }

        private void End_Button_Click(object sender, RoutedEventArgs e)
        {
            if (!timer.IsRunning)
            {
                return;
            }

            /* タイマーストップ */
            timer.Stop();
            _timer.Stop();
        }

        // タイマメソッド
        private void MyTimerMethod(object sender, EventArgs e)
        {
            TextBlock_Timer.Text = timer.Elapsed.ToString(@"hh\:mm\:ss");

            var off_color = new SolidColorBrush(Color.FromRgb(0xff, 0xff, 0xff));
            var on_color = new SolidColorBrush(Color.FromRgb(0xff, 0xff, 0x33));

            for (int i = 0; i < BingoTextList.Count; i++)
            {
                if (starGetFlag[i])
                {
                    BingoTextList[i].Background = on_color;
                }
                else
                {
                    BingoTextList[i].Background = off_color;
                }
            }
        }

        // タイマのインスタンス
        private DispatcherTimer _timer;

        // タイマを設定する
        private void SetupTimer()
        {
            // タイマのインスタンスを生成
            _timer = new DispatcherTimer(); // 優先度はDispatcherPriority.Background
                                            // インターバルを設定
            _timer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            // タイマメソッドを設定
            _timer.Tick += new EventHandler(MyTimerMethod);
            // タイマを開始
            _timer.Start();
        }

        private void TextBlock_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock temp;
            var off_color = new SolidColorBrush(Color.FromRgb(0xff, 0xff, 0xff));
            var on_color = new SolidColorBrush(Color.FromRgb(0xff, 0xff, 0x33));

            if (!timer.IsRunning)
            {
                return;
            }

            temp = (TextBlock)sender;

            if (((SolidColorBrush)temp.Background).Color == off_color.Color)
            {
                temp.Background = on_color;
            }
            else
            {
                temp.Background = off_color;
            }
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {

            if (MessageBox.Show("ルール設定画面に戻ります\n" +
                                "よろしいですか？\n",
                                "Warning",
                                MessageBoxButton.YesNo,
                                MessageBoxImage.Warning)
                                == MessageBoxResult.Yes)
            {
                var main_window = new MainWindow();
                main_window.Show();
                this.Close();
            }
            else
            {
                return;
            }
        }
    }
}
