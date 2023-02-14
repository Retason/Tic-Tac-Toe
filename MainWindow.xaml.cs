using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Reflection;
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

namespace Tic_tac_toe
{
    public partial class MainWindow : Window
    {
        private string value = "X";
        private int xWins = 0;
        private int oWins = 0;
        private static readonly Brush DEFAULTBRUSH = new SolidColorBrush(Color.FromArgb(255, 142, 142, 166));

        public MainWindow()
        {
            InitializeComponent();
        }

        //Действия в меню
        private void Restart_Click(object sender, RoutedEventArgs e)
        {
            ResetButtons();
            xWins = 0;
            oWins = 0;
            lbXWins.Content = "X: 0";
            lbOWins.Content = "O: 0";
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        // Кнопки

        private void bt_Click(object sender, RoutedEventArgs e)
        {
            Button bt = (Button)sender;
            bt.Foreground = Brushes.Black;
            bt.IsEnabled = false;

            if (isWin(btA1, btA2, btA3)) GameOver(btA1.Content.ToString());
            if (isWin(btB1, btB2, btB3)) GameOver(btB1.Content.ToString());
            if (isWin(btC1, btC2, btC3)) GameOver(btC1.Content.ToString());
            if (isWin(btA1, btB2, btC1)) GameOver(btA1.Content.ToString());
            if (isWin(btA2, btB2, btC2)) GameOver(btA2.Content.ToString());
            if (isWin(btA3, btB3, btC3)) GameOver(btA3.Content.ToString());
            if (isWin(btA1, btB2, btC3)) GameOver(btA1.Content.ToString());
            if (isWin(btA1, btB2, btC1)) GameOver(btA1.Content.ToString());
            if (isWin(btC1, btB2, btA3)) GameOver(btA3.Content.ToString());
            if (isWin(btA1, btB1, btC1)) GameOver(btA1.Content.ToString());

            if (!btA1.IsEnabled && !btA2.IsEnabled && !btA3.IsEnabled &&
                !btB1.IsEnabled && !btB2.IsEnabled && !btB3.IsEnabled &&
                !btC1.IsEnabled && !btC2.IsEnabled && !btC3.IsEnabled &&
                !btA1.IsEnabled && !btB2.IsEnabled && !btC3.IsEnabled &&
                !btC1.IsEnabled && !btB2.IsEnabled && !btA3.IsEnabled &&
                !btA1.IsEnabled && !btB1.IsEnabled && !btC1.IsEnabled)
                GameOver("");

            if (value == "X") 
                value = "O";
                else 
                    value = "X";
        }

        private void GameOver(string who)
        {
            if (lbWinner.Visibility == Visibility.Visible) return;
            if (who == "X")
            {
                lbWinner.Content = "Выиграл X!";
                lbXWins.Content = $"X: {++xWins}";
            }
            else if (who == "O")
            {
                lbWinner.Content = "Выиграл 0!";
                lbOWins.Content = $"O: {++oWins}";
            }
            else lbWinner.Content = "Ничья!";
            lbWinner.Visibility = Visibility.Visible;
            WaitSecAndRestart();
        }

        private async void WaitSecAndRestart()
        {
            await Task.Delay(1000);
            lbWinner.Visibility = Visibility.Hidden;
            ResetButtons();
        }

        private void ResetButtons()
        {
            ResetButton(btA1);
            ResetButton(btA2);
            ResetButton(btA3);
            ResetButton(btB1);
            ResetButton(btB2);
            ResetButton(btB3);
            ResetButton(btC1);
            ResetButton(btC2);
            ResetButton(btC3);
        }

        private void ResetButton(Button bt)
        {
            bt.Content = "";
            bt.IsEnabled = true;
            bt.Foreground = DEFAULTBRUSH;
        }

        private bool isWin(Button bt1, Button bt2, Button bt3)
        { return !bt1.IsEnabled && bt1.Content == bt2.Content && bt1.Content == bt3.Content; }

        private void bt_Enter(object sender, RoutedEventArgs e)
        {
            Button bt = (Button)sender;
            bt.Content = value;
        }

        private void bt_Leave(object sender, RoutedEventArgs e)
        {
            Button bt = (Button)sender;
            if (bt.IsEnabled)
                bt.Content = "";
        }
    }
}
