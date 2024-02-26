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

namespace x_and_o
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Button[,] but1 = new Button[3, 3];
        byte hod = 0;
        public MainWindow()
        {

            InitializeComponent();
        }

        private void Grid1_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    this.but1[i, j] = new Button();
                    but1[i, j].Margin = new Thickness(10, 10, 10, 10);
                    but1[i, j].Tag = Convert.ToString(i) + Convert.ToString(j);
                    but1[i, j].FontSize = 49;
                    Grid.SetRow(but1[i, j], i + 1);
                    Grid.SetColumn(but1[i, j], j);
                    Grid1.Children.Add(but1[i, j]);
                    but1[i, j].Click += MainButtonClick;

                }
            }

        }

        private void MainButtonClick(object sender, RoutedEventArgs e)
        {
            String Stroka;
            Char StrokaR;
            Char StrokaC;


            Stroka = Convert.ToString(((Button)sender).Tag);
            StrokaR = Stroka[0];
            StrokaC = Stroka[1];

            if (Convert.ToString(((Button)sender).Content) == "")
            {
                hod++;
                if (hod % 2 == 0)
                {
                    ((Button)sender).Content = "O";

                }
                else
                {
                    ((Button)sender).Content = "X";
                }
                Proverka(StrokaR, StrokaC);

            }

        }
        private void Proverka(char strokar, char strokac)
        {
            // Преобразуем координаты из char в int
            int row = Convert.ToInt32(strokar.ToString());
            int col = Convert.ToInt32(strokac.ToString());

            // Получаем контент кнопки и проверяем, не является ли он null
            object buttonContent = but1[row, col].Content;
            if (buttonContent != null)
            {
                string content = buttonContent.ToString();

                // Проверяем,содержимые кнопок в строке
                if (but1[row, 0].Content?.ToString() == content &&
                    but1[row, 1].Content?.ToString() == content &&
                    but1[row, 2].Content?.ToString() == content)
                {
                    MessageBox.Show($"Игрок {(content == "O" ? "O" : "X")} выиграл!");
                    RestartGame();
                    return;
                }

                // Проверяем, содержимые кнопок в столбце
                if (but1[0, col].Content?.ToString() == content &&
                    but1[1, col].Content?.ToString() == content &&
                    but1[2, col].Content?.ToString() == content)
                {
                    MessageBox.Show($"Игрок {(content == "O" ? "O" : "X")} выиграл!");
                    RestartGame();
                    return;
                }

                // Проверяем, не являются ли содержимые кнопок на прав-лев диагонали одинаковыми
                if (row == col && but1[0, 0].Content?.ToString() == content &&
                    but1[1, 1].Content?.ToString() == content &&
                    but1[2, 2].Content?.ToString() == content)
                {
                    MessageBox.Show($"Игрок {(content == "O" ? "O" : "X")} выиграл!");
                    RestartGame();
                    return;
                }

                // Проверяем, не являются ли содержимые кнопок на лев-прав диагонали одинаковыми
                if (row + col == 2 && but1[0, 2].Content?.ToString() == content &&
                    but1[1, 1].Content?.ToString() == content &&
                    but1[2, 0].Content?.ToString() == content)
                {
                    MessageBox.Show($"Игрок {(content == "O" ? "O" : "X")} выиграл!");
                    RestartGame();
                    return;
                }
            }

            // Проверка на ничью
            if (hod == 9)
            {
                MessageBox.Show("Ничья!");
                RestartGame();
                return;
            }
        }



        private void RestartGame()
        {
            foreach (Button button in but1)
            {
                button.Content = "";
            }
            hod = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RestartGame();
        }
    }
}
