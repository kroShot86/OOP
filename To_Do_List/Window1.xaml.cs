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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public List<Quest> quests = new List<Quest>();
        public static Window2 window2;
        public Window1()
        {
            InitializeComponent();
        }


        public StackPanel StackPanel1 = new StackPanel();
        public StackPanel StackPanel2 = new StackPanel();

        private void Button_Click(object sender, RoutedEventArgs e)
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
