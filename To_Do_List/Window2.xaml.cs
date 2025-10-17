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

using Newtonsoft.Json;
using System.IO;

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

        private void Name_kw(object sender, RoutedEventArgs e)
        {
            NameKv.Visibility = Visibility.Visible;
            NameKv.Focus();
        }
        private void Opis_kw(object sender, RoutedEventArgs e)
        {
            OpisKv.Visibility = Visibility.Visible;
            OpisKv.Focus();
        }

        private void Otmena(object sender, RoutedEventArgs e)
        {
            window1.Activate();
            this.Close();
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            if (NameKv.Text != "")
            {
                Quest newQuest = new Quest(NameKv.Text, OpisKv.Text);
                window1.quests.Add(newQuest);
                window1.AddQuestButton(newQuest);

                window1.Activate();
                this.Close();

            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }
    }
}
