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

namespace To_Do_List
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        StackPanel StackPanel1 = new StackPanel();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
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
                Text = "Название квеста",
                TextWrapping = TextWrapping.Wrap, // Включаем перенос текста
                TextAlignment = TextAlignment.Center // Выравнивание текста по центру
            };

            newButton.Content = textBlock;

            StackPanel1.Children.Add(newButton);
            figny.Content = StackPanel1;

        }
    }
}
