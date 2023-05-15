using ProjetFinale.ViewModels;
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

namespace ProjetFinale.Views
{
    /// <summary>
    /// Logique d'interaction pour AbilitiesList.xaml
    /// </summary>
    public partial class AbilitiesList : Page
    {
        public AbilitiesList()
        {
            InitializeComponent();
            this.DataContext = new VMAbilities();
            //List<Test> test = new List<Test>();

            //test.Add(new Test("Feu", "Sors", "1D8"));
            //test.Add(new Test("Soin", "Sors", "1D6"));
            //test.Add(new Test("Coup de bate", "Bachir", "5D20"));

            //Abilities.ItemsSource = test;
        }

        //public class Test
        //{
        //    public string Name { get; set; }
        //    public string Type { get; set; }
        //    public string Dice { get; set; }

        //    public Test(string name, string type, string dice)
        //    {
        //        Name = name;
        //        Type = type;
        //        Dice = dice;
        //    }
        //}

        private void Look_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
