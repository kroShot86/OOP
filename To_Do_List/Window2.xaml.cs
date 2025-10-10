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
using static To_Do_List.Window2;

namespace To_Do_List
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {

        public class Quest
        {
            public string Name { get; set; }
            public string Description { get; set; }

            public Quest(string name, string description)
            {
                Name = name;
                Description = description;
            }
        }

        

        public Window1 window1;

        public Window2(Window1 owner)
        {
            InitializeComponent();
            window1 = owner;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NameKv.Visibility = Visibility.Visible;
            NameKv.Focus();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpisKv.Visibility = Visibility.Visible;
            OpisKv.Focus();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            window1.Activate();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (NameKv.Text != "")
            {
                Quest newQuest = new Quest(NameKv.Text, OpisKv.Text);
                window1.quests.Add(newQuest);

                Button newButton = new Button
                {
                    HorizontalAlignment = HorizontalAlignment.Center, // Выравнивание по горизонтали
                    VerticalAlignment = VerticalAlignment.Center,
                    Background = null,
                    Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF37F7EA")),
                    FontSize = 24,
                };
                TextBlock textBlock = new TextBlock
                {
                    Text = NameKv.Text,
                    TextWrapping = TextWrapping.Wrap, // Включаем перенос текста
                    TextAlignment = TextAlignment.Center // Выравнивание текста по центру
                };

                newButton.Content = textBlock;
                newButton.Click += (s, args) => { window1.Podrobnosti.Text = newQuest.Description; };
                newButton.MouseDoubleClick += (s, args) =>
                {
                    if (window1.StackPanel1.Children.Contains(newButton))
                    {
                        window1.StackPanel1.Children.Remove(newButton);
                        window1.StackPanel2.Children.Add(newButton);
                    }
                    
                };
                window1.StackPanel1.Children.Add(newButton);
                window1.figny.Content = window1.StackPanel1;
                window1.figny1.Content = window1.StackPanel2;

                window1.Activate();
                this.Close();
                    
            }
        }
    }
}
