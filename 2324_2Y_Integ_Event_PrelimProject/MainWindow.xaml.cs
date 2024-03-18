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
using System.Windows.Threading;

namespace _2324_2Y_Integ_Event_PrelimProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int rNum = 0;
        int uNum = 0;
        int score = 0;
        int uTime = 0;
        int rounds = 0;
        int time = 0;
        string diff = "";
        string FileName = "";
        CSVManager _cm = new CSVManager();
        private DispatcherTimer _timer;
        private DispatcherTimer _uPlaytime;
        List<Pdata> lboardData = new List<Pdata>();

        public MainWindow()
        {
            InitializeComponent();

            _timer = new DispatcherTimer();
            _timer.Interval = new TimeSpan(0, 0, 1);
            _timer.Tick += _timer_Tick;

            _uPlaytime = new DispatcherTimer();
            _uPlaytime.Interval = new TimeSpan(0,0,1);
            _uPlaytime.Tick += _uPlaytime_Tick;
        }

        private void _uPlaytime_Tick(object sender, EventArgs e)
        {
            uTime++;
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            lbl_timer.Content = time.ToString();
            time--;
            if (time == 0)
                GameOver();
        }

        private void btn_start_Click(object sender, RoutedEventArgs e)
        {
            Opening.Visibility = Visibility.Collapsed;
            lbl_diff.Visibility = Visibility.Visible;
            btn_diff.Visibility = Visibility.Visible;
        }

        private void btn_lBoard_Click(object sender, RoutedEventArgs e)
        {
            Opening.Visibility = Visibility.Collapsed;
            lbl_lBoard_panel.Visibility = Visibility.Visible;
            btn_lBoards.Visibility = Visibility.Visible; 
        }

        private void btn_lBoard_easy_Click(object sender, RoutedEventArgs e)
        {
            FileName = "Easy_Lboard.csv";
            GetData();
            lbl_lBoard.Content = "Easy Difficulty Leaderboards";
            lbl_lBoard_panel.Visibility = Visibility.Collapsed;
            btn_lBoards.Visibility = Visibility.Collapsed;
            pnl_lboard_back.Visibility = Visibility.Visible;
            leaderboard.Visibility = Visibility.Visible;
        }

        private void btn_lBoard_med_Click(object sender, RoutedEventArgs e)
        {
            FileName = "Med_Lboard.csv";
            GetData();
            lbl_lBoard.Content = "Medium Difficulty Leaderboards";
            lbl_lBoard_panel.Visibility = Visibility.Collapsed;
            btn_lBoards.Visibility = Visibility.Collapsed;
            pnl_lboard_back.Visibility = Visibility.Visible;
            leaderboard.Visibility = Visibility.Visible;
        }

        private void btn_lBoard_hard_Click(object sender, RoutedEventArgs e)
        {
            FileName = "Hard_Lboard.csv";
            GetData();
            lbl_lBoard.Content = "Hard Difficulty Leaderboards";
            lbl_lBoard_panel.Visibility = Visibility.Collapsed;
            btn_lBoards.Visibility = Visibility.Collapsed;
            pnl_lboard_back.Visibility = Visibility.Visible;
            leaderboard.Visibility = Visibility.Visible;
        }

        private void GetData()
        {
            lboardData.Clear();
            lboardData = _cm.GetPdata(FileName);
            lboardData.Sort((x, y) => y.Score.CompareTo(x.Score));
            int count = 0;
            foreach (Pdata data in lboardData)
            {
                Leaderboard.Items.Add(new { Column1 = data.Name, Column2 = data.Score, Column3 = data.Playtime });
                count++;

                if (count == 10)
                    break;
            }
        }

        private void btn_lboard_back_Click(object sender, RoutedEventArgs e)
        {
            lbl_lBoard_panel.Visibility = Visibility.Visible;
            btn_lBoards.Visibility = Visibility.Visible;
            leaderboard.Visibility = Visibility.Collapsed;
            pnl_lboard_back.Visibility = Visibility.Collapsed;
            Leaderboard.Items.Clear();
        }

        private void btn_backtoop_Click(object sender, RoutedEventArgs e)
        {
            lbl_lBoard_panel.Visibility = Visibility.Collapsed;
            btn_lBoards.Visibility = Visibility.Collapsed;
            Opening.Visibility = Visibility;
        }

        private void btn_diff_back_Click(object sender, RoutedEventArgs e)
        {
            lbl_diff.Visibility = Visibility.Collapsed;
            btn_diff.Visibility = Visibility.Collapsed;
            Opening.Visibility = Visibility.Visible;
        }

        private void btn_easy_Click(object sender, RoutedEventArgs e)
        {
            diff = "easy";
            time = 60;
            StartGame();
        }

        private void btn_med_Click(object sender, RoutedEventArgs e)
        {
            diff = "med";
            time = 45;
            StartGame();
        }

        private void btn_hard_Click(object sender, RoutedEventArgs e)
        {
            diff = "hard";
            time = 30;
            StartGame();
        }

        private void StartGame()
        {
            Random rnd = new Random();
            uNum = 0;
            score = 0;
            uTime = 0;
            rounds = 0;
            _timer.Start();
            _uPlaytime.Start();

            lbl_diff.Visibility = Visibility.Collapsed;
            btn_diff.Visibility = Visibility.Collapsed;

            if (diff == "easy")
            {
                easy_panel.Visibility = Visibility.Visible;
                button_panel.Visibility = Visibility.Visible;
            }
            else if (diff == "med")
            {
                button_panel.Visibility = Visibility.Visible;
            }
            else if (diff == "hard")
            {
                hard_panel.Visibility = Visibility.Visible;
            }

            rNum = rnd.Next(1, 256);
            lbl_num.Content = rNum.ToString();
            lbl_round.Content = $"Round: {rounds + 1}";
            lbl_score.Content = score;
            num_panel.Visibility = Visibility.Visible;
            timer_panel.Visibility = Visibility.Visible;
            pnl_game_back.Visibility = Visibility.Visible;
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            if (btn1.Content.ToString() == "0")
                btn1.Content = "1";
            else
                btn1.Content = "0";
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            if (btn2.Content.ToString() == "0")
                btn2.Content = "1";
            else
                btn2.Content = "0";
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            if (btn4.Content.ToString() == "0")
                btn4.Content = "1";
            else
                btn4.Content = "0";
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            if (btn8.Content.ToString() == "0")
                btn8.Content = "1";
            else
                btn8.Content = "0";
        }

        private void btn16_Click(object sender, RoutedEventArgs e)
        {
            if (btn16.Content.ToString() == "0")
                btn16.Content = "1";
            else
                btn16.Content = "0";
        }

        private void btn32_Click(object sender, RoutedEventArgs e)
        {
            if (btn32.Content.ToString() == "0")
                btn32.Content = "1";
            else
                btn32.Content = "0";
        }

        private void btn64_Click(object sender, RoutedEventArgs e)
        {
            if (btn64.Content.ToString() == "0")
                btn64.Content = "1";
            else
                btn64.Content = "0";
        }

        private void btn128_Click(object sender, RoutedEventArgs e)
        {
            if (btn128.Content.ToString() == "0")
                btn128.Content = "1";
            else
                btn128.Content = "0";
        }

        private void btn_check_Click(object sender, RoutedEventArgs e)
        {
           Random rnd = new Random();

            if (diff == "easy" || diff == "med")
            {
                if (btn1.Content.ToString() == "1")
                    uNum += 1;
                if (btn2.Content.ToString() == "1")
                    uNum += 2;
                if (btn4.Content.ToString() == "1")
                    uNum += 4;
                if (btn8.Content.ToString() == "1")
                    uNum += 8;
                if (btn16.Content.ToString() == "1")
                    uNum += 16;
                if (btn32.Content.ToString() == "1")
                    uNum += 32;
                if (btn64.Content.ToString() == "1")
                    uNum += 64;
                if (btn128.Content.ToString() == "1")
                    uNum += 128;
            }
            else
            {
                if (isValid())
                {
                    uNum = Convert.ToInt32(uString.Text.ToString(), 2);
                }
                else
                {
                    uNum = -1;
                }
            }

            if (uNum == rNum)
            {
                score += 100;
                ResetButtons();
            }
            else
            {
                if (score > 0)
                {
                    score -= 20;
                }
                ResetButtons();
            }

            uNum = 0;
            lbl_score.Content = score.ToString();
            rounds++;
            if (diff == "easy")
            {
                if (rounds < 11)
                    time = 60 - 4 * rounds;
                else
                    time = 40;
            }
            else if (diff == "med")
            {
                if (rounds < 11)
                    time = 45 - 3 * rounds;
                else
                    time = 30;
            }
            else if (diff == "hard")
            {
                if (rounds < 11)
                    time = 30 - 2 * rounds;
                else
                    time = 20;
            }
            rNum = rnd.Next(1, 256);
            lbl_round.Content = $"Round: {rounds + 1}";
            lbl_num.Content = rNum.ToString();
            uString.Text = null;
        }

        private bool isValid()
        {
            bool isNum = false;
            isNum = int.TryParse(uString.Text.ToString(), out uNum);

            if (!isNum) // if not num
                return false;
            
            if (uString.Text.ToString().All(c => c == '0' || c == '1')) // if in binary
            {
                if (uString.Text.ToString().Length < 8) // if less than 8 chars
                {
                    uString.Text = uString.Text.ToString().PadLeft(8, '0');
                    return true;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        private void ResetButtons()
        {
            btn1.Content = "0";
            btn2.Content = "0";
            btn4.Content = "0";
            btn8.Content = "0";
            btn16.Content = "0";
            btn32.Content = "0";
            btn64.Content = "0";
            btn128.Content = "0";
        }

        private void GameOver()
        {
            ResetButtons();
            lbl_uScore.Content = score.ToString();
            lbl_uTime.Content = uTime.ToString() + "s";
            num_panel.Visibility = Visibility.Collapsed;
            button_panel.Visibility = Visibility.Collapsed;
            easy_panel.Visibility = Visibility.Collapsed;
            hard_panel.Visibility = Visibility.Collapsed;
            timer_panel.Visibility = Visibility.Collapsed;
            GameOver_Panel.Visibility = Visibility.Visible;
            FinalStats_Panel.Visibility = Visibility.Visible;
            _uPlaytime.Stop();
        }

        private void btn_submitInfo_Click(object sender, RoutedEventArgs e)
        {
            GameOver_Panel.Visibility = Visibility.Collapsed;
            FinalStats_Panel.Visibility = Visibility.Collapsed;
            Opening.Visibility = Visibility.Visible;

            List<Pdata> Top10 = new List<Pdata>();

            Pdata newPdata = new Pdata();
            newPdata.Name = uName.Text.ToString();
            newPdata.Score = score;
            newPdata.Playtime = uTime;

            if (diff == "easy")
            {
                FileName = "Easy_Lboard.csv";
            }
            else if (diff == "med")
            {
                FileName = "Med_Lboard.csv";
            }
            else if (diff == "hard")
            {
                FileName = "Hard_Lboard.csv";
            }

            lboardData.Clear();
            lboardData = _cm.GetPdata(FileName);
            lboardData.Add(newPdata);
            lboardData.Sort((x, y) => y.Score.CompareTo(x.Score));
            Top10 = lboardData.Take(10).ToList();
            _cm.AddToCSV(Top10, FileName);

            uName.Text = "";
        }

        private void btn_game_back_Click(object sender, RoutedEventArgs e)
        {
            num_panel.Visibility = Visibility.Collapsed;
            button_panel.Visibility = Visibility.Collapsed;
            easy_panel.Visibility = Visibility.Collapsed;
            hard_panel.Visibility = Visibility.Collapsed;
            timer_panel.Visibility = Visibility.Collapsed;
            pnl_game_back.Visibility = Visibility.Collapsed;
            Opening.Visibility = Visibility.Visible;
            
        }
    }
}
