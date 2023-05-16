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
using ProjetFinale.ViewModels;

namespace ProjetFinale.Views
{
    /// <summary>
    /// Logique d'interaction pour ObjectsList.xaml
    /// </summary>
    public partial class ObjectsList : Page
    {
        public ObjectsList()
        {
            InitializeComponent();
            this.DataContext = new VMItem();
            //List<Test> test = new List<Test>();

            //test.Add(new Test("Pomme", 50));
            //test.Add(new Test("Avion", 10));
            //test.Add(new Test("Auto", 30));
            //test.Add(new Test("Épée", 55));
            //test.Add(new Test("Roger", 20));
            //test.Add(new Test("Toutou", 15));
            //test.Add(new Test("Poire", 15));

            //Objects.ItemsSource = test;
        }

        public ObjectsList(VMItem dataContext)
        {
            InitializeComponent();
            VMItem vm = dataContext;
            this.DataContext = vm;
        }

        //public class Test
        //{
        //    public string Name { get; set; }
        //    public double Weight { get; set; }

        //    public Test(string name, double weight)
        //    {
        //        Name = name;
        //        Weight = weight;
        //    }
        //}

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddObject((VMItem)this.DataContext));
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EnableDisable(object sender, SelectionChangedEventArgs e)
        {
            if(Objects.SelectedItem != null)
            {
                Delete.IsEnabled = true;
            }
            else
            {
                Delete.IsEnabled = false;
            }
        }
    }
}
