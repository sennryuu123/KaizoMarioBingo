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

namespace BINGOgame
{
    /// <summary>
    /// configWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class bingoWindow6 : Window
    {
        string Hack_name;
        int Seed;
        int Bingo_size;
        string[] Bingo_card_list = new string[256];

        /* タイマースタート */
        System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();

        public bingoWindow6(string hack_name, int seed, int bingo_size, string[] bingo_card_list)
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
            System.Diagnostics.Debug.WriteLine(bingo_card_list[0]);
            System.Diagnostics.Debug.WriteLine(bingo_card_list[bingo_size * bingo_size-1]);
        }

        private void Start_Button_Click(object sender, RoutedEventArgs e)
        {
            TextBlock_0_0.Text = Bingo_card_list[0].Replace("@", "\n");
            TextBlock_0_1.Text = Bingo_card_list[1].Replace("@", "\n");
            TextBlock_0_2.Text = Bingo_card_list[2].Replace("@", "\n");
            TextBlock_0_3.Text = Bingo_card_list[3].Replace("@", "\n");
            TextBlock_0_4.Text = Bingo_card_list[4].Replace("@", "\n");
            TextBlock_0_5.Text = Bingo_card_list[5].Replace("@", "\n");

            TextBlock_1_0.Text = Bingo_card_list[6].Replace("@", "\n");
            TextBlock_1_1.Text = Bingo_card_list[7].Replace("@", "\n");
            TextBlock_1_2.Text = Bingo_card_list[8].Replace("@", "\n");
            TextBlock_1_3.Text = Bingo_card_list[9].Replace("@", "\n");
            TextBlock_1_4.Text = Bingo_card_list[10].Replace("@", "\n");
            TextBlock_1_5.Text = Bingo_card_list[11].Replace("@", "\n");

            TextBlock_2_0.Text = Bingo_card_list[12].Replace("@", "\n");
            TextBlock_2_1.Text = Bingo_card_list[13].Replace("@", "\n");
            TextBlock_2_2.Text = Bingo_card_list[14].Replace("@", "\n");
            TextBlock_2_3.Text = Bingo_card_list[15].Replace("@", "\n");
            TextBlock_2_4.Text = Bingo_card_list[16].Replace("@", "\n");
            TextBlock_2_5.Text = Bingo_card_list[17].Replace("@", "\n");

            TextBlock_3_0.Text = Bingo_card_list[18].Replace("@", "\n");
            TextBlock_3_1.Text = Bingo_card_list[19].Replace("@", "\n");
            TextBlock_3_2.Text = Bingo_card_list[20].Replace("@", "\n");
            TextBlock_3_3.Text = Bingo_card_list[21].Replace("@", "\n");
            TextBlock_3_4.Text = Bingo_card_list[22].Replace("@", "\n");
            TextBlock_3_5.Text = Bingo_card_list[23].Replace("@", "\n");
                                                 
            TextBlock_4_0.Text = Bingo_card_list[24].Replace("@", "\n");
            TextBlock_4_1.Text = Bingo_card_list[25].Replace("@", "\n");
            TextBlock_4_2.Text = Bingo_card_list[26].Replace("@", "\n");
            TextBlock_4_3.Text = Bingo_card_list[27].Replace("@", "\n");
            TextBlock_4_4.Text = Bingo_card_list[28].Replace("@", "\n");
            TextBlock_4_5.Text = Bingo_card_list[29].Replace("@", "\n");
                                                 
            TextBlock_5_0.Text = Bingo_card_list[30].Replace("@", "\n");
            TextBlock_5_1.Text = Bingo_card_list[31].Replace("@", "\n");
            TextBlock_5_2.Text = Bingo_card_list[32].Replace("@", "\n");
            TextBlock_5_3.Text = Bingo_card_list[33].Replace("@", "\n");
            TextBlock_5_4.Text = Bingo_card_list[34].Replace("@", "\n");
            TextBlock_5_5.Text = Bingo_card_list[35].Replace("@", "\n");

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
            var on_color  = new SolidColorBrush(Color.FromRgb(0xff, 0xff, 0x33));

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
