using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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

namespace GuessTheLetter
{
    /// <summary>
    /// Логика взаимодействия для Guess.xaml
    /// </summary>
    public partial class Guess : Page
    {
        private char randT;
        private bool GameEnded;
        public Guess()
        {
            InitializeComponent();
            NewGame();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Menu());
        }

        private void Click_Rand(object sender, RoutedEventArgs e)
        {
            if (GameEnded == true)
            {
                NewGame();
                return;

            }
            var button = (Button)sender;
            string name = randT.ToString();
            SoundPlayer simpleSound = new SoundPlayer(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + $"/{name}.wav");
            simpleSound.Play();

        }
        private void NewGame()
        {
            
            Button0.Background = Brushes.White;
            Button1.Background = Brushes.White;
            Button2.Background = Brushes.White;
            GameEnded = false;
            Random rand = new Random();
            randT = (char)rand.Next('А', 'Я' + 1);
            int randVal = rand.Next(0, 3);
            if (randVal == 0)
            {
                Button0.Content = randT;
                Button1.Content = (char)rand.Next('А', 'Я' + 1);
                Button2.Content = (char)rand.Next('А', 'Я' + 1);
            }
            if (randVal == 1)
            {
                Button1.Content = randT;
                Button0.Content = (char)rand.Next('А', 'Я' + 1);
                Button2.Content = (char)rand.Next('А', 'Я' + 1);
            }
            if (randVal == 2)
            {
                Button2.Content = randT;
                Button1.Content = (char)rand.Next('А', 'Я' + 1);
                Button0.Content = (char)rand.Next('А', 'Я' + 1);
            }
        }
        private void Button0_Click(object sender, RoutedEventArgs e)
        {
            if (GameEnded == true)
            {
                NewGame();
                return;

            }
            var button = (Button)sender;
            if (Button0.Content.ToString() == randT.ToString())
            {
                Button0.Background = Brushes.Green;
                GameEnded = true;
            }
            else
            {
                Button0.Background = Brushes.Red;
            }
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            if (GameEnded == true)
            {
                NewGame();
                return;

            }
            var button = (Button)sender;
            if (Button1.Content.ToString() == randT.ToString())
            {
                Button1.Background = Brushes.Green;
                GameEnded = true;
            }
            else
            {
                Button1.Background = Brushes.Red;
            }
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            if (GameEnded == true)
            {
                NewGame();
                return;
            }
            var button = (Button)sender;
            if (Button2.Content.ToString() == randT.ToString())
            {
                Button2.Background = Brushes.Green;
                GameEnded = true;
            }
            else
            {
                Button2.Background = Brushes.Red;
            }
        }
    }
}
