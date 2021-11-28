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
using System.Collections.ObjectModel;

namespace BINGOgame
{
    /// <summary>
    /// configWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class bingoWindow : Window
    {
        string hackName;
        int seedNum;
        int bingoSize;
        List<BINGOgame.MainWindow.STAR_INFO> bingoCardList = new List<BINGOgame.MainWindow.STAR_INFO>();
        MemoryManager mm = new MemoryManager(null);
        Thread magicThread = null;
        bool[] starGetFlag;
        public List<TextBlock> BingoTextList = new List<TextBlock>();
        int maxCol = 0; /* 1マスにスター名を入れた時の最大改行数 */
        double defaultHeight;
        double defaultWidth;
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

        string[] MySplit(string str, int count)
        {
            var list = new List<string>();
            int length = (int)Math.Ceiling((double)str.Length / count);

            if (length == 0)
            {
                list.Add("");
            }
            else
            {
                for (int i = 0; i < length; i++)
                {
                    int start = count * i;
                    if (str.Length <= start)
                    {
                        break;
                    }
                    if (str.Length < start + count)
                    {
                        list.Add(str.Substring(start));
                    }
                    else
                    {
                        list.Add(str.Substring(start, count));
                    }
                }
            }

            return list.ToArray();
        }

        public bingoWindow(
            string hack_name,
            int seed_num,
            int bingo_size,
            List<BINGOgame.MainWindow.STAR_INFO> bingo_card_list,
            double window_rate)
        {
            Application.Current.MainWindow = this;
            InitializeComponent();

            defaultHeight = 840 * window_rate;
            defaultWidth  = 640 * window_rate;

            TextBlock_Seed.Text = seed_num.ToString();
            this.Title = hack_name + " BINGO";

            hackName = hack_name;
            seedNum = seed_num;
            bingoSize = bingo_size;
            bingoCardList = bingo_card_list;

            /* ここでビンゴカード用Gridを作成する */
            for (int row = 0; row < bingo_size; row++)
            {
                ColumnDefinition col_def = new ColumnDefinition();
                RowDefinition row_def = new RowDefinition();
                Grid_Bingo_Card.ColumnDefinitions.Add(col_def);
                Grid_Bingo_Card.RowDefinitions.Add(row_def);
            }

            /* ここでTextBlockを作成する */
            for (int row = 0; row < bingo_size; row++)
            {
                for (int col = 0; col < bingo_size; col++)
                {
                    TextBlock text_block = new TextBlock();
                    text_block.Foreground = Brushes.White;
                    text_block.Background = Brushes.White;
                    text_block.HorizontalAlignment = (HorizontalAlignment)3;
                    text_block.VerticalAlignment = (VerticalAlignment)3;
                    text_block.TextAlignment = (TextAlignment)2;
                    text_block.Height = double.NaN;
                    text_block.Width = double.NaN;
                    text_block.FontSize = 20;

                    Viewbox view_box = new Viewbox();
                    view_box.Stretch = (Stretch)1;
                    view_box.SetValue(Grid.RowProperty, row);
                    view_box.SetValue(Grid.ColumnProperty, col);

                    view_box.Child = text_block;
                    Grid_Bingo_Card.Children.Add(view_box);

                    BingoTextList.Add(text_block);
                }
            }

            /* TextBlockにスター名を入力する */
            string[] temp;
            string name;
            int i, j;

            for (i = 0; i < BingoTextList.Count; i++)
            {
                BingoTextList[i].Text = bingoCardList[i].course + " Star" + bingoCardList[i].num + "\n" + bingoCardList[i].name;
                temp = MySplit(bingoCardList[i].name, 10);

                name = temp[0];
                for (j = 1; j < temp.Length; j++)
                {
                    name += "\n";
                    name += temp[j];
                }

                if (i == 0)
                {
                    maxCol = j;
                }
                else 
                {
                    if (maxCol < j) 
                    {
                        maxCol = j;
                    }
                }

                BingoTextList[i].Text = bingoCardList[i].course + " Star" + bingoCardList[i].num + "\n" + name;
            }
            maxCol++; /* コース名分 */

            /* ここでボーダーを引く */
            for (int row = 0; row < bingo_size; row++) 
            {
                for (int col = 0; col < bingo_size; col++) 
                {
                    Border Border = new Border();
                    Border.BorderBrush = Brushes.Black;
                    Border.BorderThickness = new Thickness(1);
                    Border.SetValue(Grid.RowProperty, row);
                    Border.SetValue(Grid.ColumnProperty, col);
                    Grid_Bingo_Card.Children.Add(Border);
                }
            }

            Thread thread = new Thread(new ThreadStart(bingoCtrlFromPj64));
            thread.Start();

            starGetFlag = new bool[bingo_size * bingo_size];

            for (i = 0; i < starGetFlag.Length; i++)
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
                if (mm.ProcessActive())
                {
                    /* 終了したらスレッドの先頭に戻る */
                    goto LABEL1;
                }

                if (mm.GetTitle().Contains("-"))
                {
                    /* ロードしたら抜ける */
                    break;
                }

                await Task.Delay(1000);
            }

            /* ROMとRAM周りの初期化処理をしているっぽい？ */
            /* stardisplayのソースコードと同じ処理にしている */
            magicThread = new Thread(doMagicThread);
            magicThread.Start();

            while (true)
            {
                if (mm.ProcessActive())
                {
                    /* 終了したらスレッドの先頭に戻る */
                    goto LABEL1;
                }

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
                for (i = 0; i < bingoCardList.Count; i++)
                {
                    offset = bingoCardList[i].offset;
                    bit = (byte)(1 << (bingoCardList[i].num - 1));

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
            double max_height;
            double max_width;
            double font_size = 0;

            max_height = (Application.Current.MainWindow.Height / 1.5 * (5.0 / 7.0)) / bingoSize;
            max_width = (Application.Current.MainWindow.Width   / 1.5 * (30.0 / 32.0)) / bingoSize;
            font_size = max_height / (maxCol + 2);

            for (int i = 0; i < BingoTextList.Count; i++)
            {
                BingoTextList[i].Foreground = Brushes.Black;
                BingoTextList[i].FontSize = font_size;
                BingoTextList[i].Height = max_height;
                BingoTextList[i].Width = max_width;
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

#if false
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
#endif

        private void Seed_Copy_Button_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(TextBlock_Seed.Text);
        }

        private void Time_Copy_Button_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(TextBlock_Timer.Text);
        }

        private void Resize_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Height = defaultHeight;
            this.Width  = defaultWidth;
        }

        void Bingo_Window_Closing(object sender, CancelEventArgs e)
        {
            if (!timer.IsRunning)
            {
                return;
            }

            /* タイマーストップ */
            timer.Stop();
            _timer.Stop();
        }
    }
}
