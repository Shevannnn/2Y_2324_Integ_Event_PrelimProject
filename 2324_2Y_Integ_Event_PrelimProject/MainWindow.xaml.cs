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

namespace _2324_2Y_Integ_Event_PrelimProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int rNum = 0;
        int uNum = 0;
        static CSVManager _cm = new CSVManager();

        public MainWindow()
        {
            InitializeComponent();
            Random rnd = new Random();
            rNum = rnd.Next(1, 256);
            lbl_num.Content = rNum.ToString();
            string FileName = "Easy_Lboard.csv";
            List<Pdata> lboardData = _cm.GetPdata(FileName);
            List<Pinfo> dataList = new List<Pinfo>();

            foreach (Pdata data in lboardData)
            {
                dataList.Add(new Pinfo { Column1 = data.Name, Column2 = data.Score, Column3 = data.Playtime });
            }

            //    List<Pinfo> dataList = new List<Pinfo>
            //{
            //    new Pinfo { Column1 = "Name", Column2 = "Score", Column3 = "Playtime" },
            //    new Pinfo { Column1 = "Name", Column2 = "Score", Column3 = "Playtime" },
            //    new Pinfo { Column1 = "Name", Column2 = "Score", Column3 = "Playtime" },
            //    new Pinfo { Column1 = "Name", Column2 = "Score", Column3 = "Playtime" },
            //    new Pinfo { Column1 = "Name", Column2 = "Score", Column3 = "Playtime" },
            //    new Pinfo { Column1 = "Name", Column2 = "Score", Column3 = "Playtime" },
            //    new Pinfo { Column1 = "Name", Column2 = "Score", Column3 = "Playtime" },
            //    new Pinfo { Column1 = "Name", Column2 = "Score", Column3 = "Playtime" },
            //    new Pinfo { Column1 = "Name", Column2 = "Score", Column3 = "Playtime" },
            //    new Pinfo { Column1 = "Name", Column2 = "Score", Column3 = "Playtime" },

            //    // Add more data as needed
            //};

            //foreach (Pinfo pinfo in dataList)
            //{
            //    new Pinfo { Column1 = pinfo.Name };
            //}

            Leaderboard.ItemsSource = dataList;
        }

        private void btn_start_Click(object sender, RoutedEventArgs e)
        {
            Opening.Visibility = Visibility.Collapsed;
            Difficulty.Visibility = Visibility.Visible;
        }

        private void btn_lBoard_Click(object sender, RoutedEventArgs e)
        {
            Opening.Visibility = Visibility.Collapsed;
            lBoard.Visibility = Visibility.Visible;
        }

        private void btn_lBoard_easy_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_lBoard_med_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_lBoard_hard_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            if (btn1.Content.ToString() == "0")
            {
                btn1.Content = "1";
                uNum += 1;
            }
            else
            {
                btn1.Content = "0";
                uNum -= 1;
            }
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            if (btn2.Content.ToString() == "0")
            {
                btn2.Content = "1";
                uNum += 2;
            }
            else
            {
                btn2.Content = "0";
                uNum -= 2;
            }
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            if (btn4.Content.ToString() == "0")
            {
                btn4.Content = "1";
                uNum += 4;
            }
            else
            {
                btn4.Content = "0";
                uNum -= 4;
            }
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            if (btn8.Content.ToString() == "0")
            {
                btn8.Content = "1";
                uNum += 8;
            }
            else
            {
                btn8.Content = "0";
                uNum -= 8;
            }
        }

        private void btn16_Click(object sender, RoutedEventArgs e)
        {
            if (btn16.Content.ToString() == "0")
            {
                btn16.Content = "1";
                uNum += 16;
            }
            else
            {
                btn16.Content = "0";
                uNum -= 16;
            }
        }

        private void btn32_Click(object sender, RoutedEventArgs e)
        {
            if (btn32.Content.ToString() == "0")
            {
                btn32.Content = "1";
                uNum += 32;
            }
            else
            {
                btn32.Content = "0";
                uNum -= 32;
            }
        }

        private void btn64_Click(object sender, RoutedEventArgs e)
        {
            if (btn64.Content.ToString() == "0")
            {
                btn64.Content = "1";
                uNum += 64;
            }
            else
            {
                btn64.Content = "0";
                uNum -= 64;
            }
        }

        private void btn128_Click(object sender, RoutedEventArgs e)
        {
            if (btn128.Content.ToString() == "0")
            {
                btn128.Content = "1";
                uNum += 128;
            }
            else
            {
                btn128.Content = "0";
                uNum -= 128;
            }
        }

        private void btn_check_Click(object sender, RoutedEventArgs e)
        {
            if (uNum == rNum)
            {
                MessageBox.Show("Win");
            }
            else
                MessageBox.Show("Lose");
        }
    }
}
