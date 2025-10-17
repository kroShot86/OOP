using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using static To_Do_List.Window2;
using System.Windows.Media;

namespace To_Do_List
{
    public partial class Window1 : Window
    {
        public List<Quest> quests = new List<Quest>();
        public static Window2 window2;

        public Window1()
        {
            InitializeComponent();
            LoadQuests();
            this.Closing += Window_Closing;
        }

        public StackPanel StackPanel1 = new StackPanel();
        public StackPanel StackPanel2 = new StackPanel();



        private void LoadQuests()
        {
            if (File.Exists("quests.json"))
            {
                var json = File.ReadAllText("quests.json");
                quests = JsonConvert.DeserializeObject<List<Quest>>(json);

                foreach (var quest in quests)
                {
                    AddQuestButton(quest);
                }
            }
        }

        public void AddQuestButton(Quest quest)
        {
            Button newButton = new Button
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Background = null,
                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF37F7EA")),
                FontSize = 24,
            };
            TextBlock textBlock = new TextBlock
            {
                Text = quest.Name,
                TextWrapping = TextWrapping.Wrap,
                TextAlignment = TextAlignment.Center
            };

            newButton.Content = textBlock;
            newButton.Click += (s, args) => { Podrobnosti.Text = quest.Description; };
            newButton.MouseDoubleClick += (s, args) =>
            {
                if (StackPanel1.Children.Contains(newButton))
                {
                    StackPanel1.Children.Remove(newButton);
                    StackPanel2.Children.Add(newButton);
                    quests.Remove(quest);
                }
                else
                {
                    StackPanel2.Children.Remove(newButton);
                }
            };

            StackPanel1.Children.Add(newButton);
            figny.Content = StackPanel1;
            figny1.Content = StackPanel2;
        }

        private void SaveQuests()
        {
            var json = JsonConvert.SerializeObject(quests);
            File.WriteAllText("quests.json", json);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveQuests();
        }

        private void New_kw(object sender, RoutedEventArgs e)
        {
            if (window2 == null || !window2.IsVisible)
            {

                window2 = new Window2(this);
                window2.Owner = this;
                window2.Show();
            }
        }
    }
}
