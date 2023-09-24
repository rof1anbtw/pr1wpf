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


namespace PR1Wpf
{
    public partial class MainWindow : Window
    {


        
        int[] arr = new int[9];
        Button[] but = new Button[9];
        private bool gameEnded = false;


        public MainWindow()
        {
            InitializeComponent();        
            but[0] = button1;
            but[1] = button2;
            but[2] = button3;
            but[3] = button4;
            but[4] = button5;
            but[5] = button6;
            but[6] = button7;
            but[7] = button8;
            but[8] = button9;

            TbResult.Text = " ";
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (gameEnded) return;

            for (int i = 0; i < but.Length; i++)
            {
                if (sender == but[i] && but[i].IsEnabled == true)
                {
                    but[i].Content = "X";
                    but[i].IsEnabled = false;
                    arr[i] = 1;
                }
            }

            CheckGameResult();

            if (!gameEnded) Bot();
            
            CheckGameResult();
        }

        private void CheckGameResult()
        {
            if ((arr[0] == 1 && arr[1] == 1 && arr[2] == 1) ||
                (arr[3] == 1 && arr[4] == 1 && arr[5] == 1) ||
                (arr[6] == 1 && arr[7] == 1 && arr[8] == 1) ||
                (arr[0] == 1 && arr[3] == 1 && arr[6] == 1) ||
                (arr[1] == 1 && arr[4] == 1 && arr[7] == 1) ||
                (arr[2] == 1 && arr[5] == 1 && arr[8] == 1) ||
                (arr[0] == 1 && arr[4] == 1 && arr[8] == 1) ||
                (arr[2] == 1 && arr[4] == 1 && arr[6] == 1))
            {
                TbResult.Text = "Вы победили";
                DisableAllButtons();
            }
            else if ((arr[0] == 2 && arr[1] == 2 && arr[2] == 2) ||
                     (arr[3] == 2 && arr[4] == 2 && arr[5] == 2) ||
                     (arr[6] == 2 && arr[7] == 2 && arr[8] == 2) ||
                     (arr[0] == 2 && arr[3] == 2 && arr[6] == 2) ||
                     (arr[1] == 2 && arr[4] == 2 && arr[7] == 2) ||
                     (arr[2] == 2 && arr[5] == 2 && arr[8] == 2) ||
                     (arr[0] == 2 && arr[4] == 2 && arr[8] == 2) ||
                     (arr[2] == 2 && arr[4] == 2 && arr[6] == 2))
            {
                TbResult.Text = "Вы проиграли";
                DisableAllButtons();
            }
            else if (!arr.Contains(0))
            {
                TbResult.Text = "Ничья";
                DisableAllButtons();
            }

            if (gameEnded) return;
            else if (!arr.Contains(0))
            {
                TbResult.Text = "Ничья";
                DisableAllButtons();
                gameEnded = true;
            }
        }

        private void DisableAllButtons()
        {
            for (int i = 0; i < but.Length; i++)
            {
                but[i].IsEnabled = false;
            }
        }

        private void Bot()
        {
            Random random = new Random();
            int index = -1; 
            for (int i = 0; i < but.Length; i++)
            {
                if (but[i].IsEnabled)
                {
                    index = i;
                    break;
                }
            }
            if (index != -1)
            {
                but[index].Content = "O";
                but[index].IsEnabled = false;
                arr[index] = 2;
            }
            else
            {
                TbResult.Text = "Ничья";
                DisableAllButtons();
                gameEnded = true;
            }
        }

        private void Sbros_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < but.Length; i++)
            {
                arr[i] = 0;
                but[i].Content = " ";
                but[i].IsEnabled = true;
                TbResult.Text = " ";
            }

            gameEnded = false; 
        }
    }

}
