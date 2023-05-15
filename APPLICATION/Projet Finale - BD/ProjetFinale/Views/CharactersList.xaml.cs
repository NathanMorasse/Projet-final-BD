using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ProjetFinale.ViewModels;
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
    /// Logique d'interaction pour CharactersList.xaml
    /// </summary>
    public partial class CharactersList : Page
    {
        public CharactersList()
        {
            InitializeComponent();
            this.DataContext = new VMPersonnage();

            //List<Test> tests = new List<Test>();

            //tests.Add(new Test("Bob", 30, 6));
            //tests.Add(new Test("Serge", 10, 10));
            //tests.Add(new Test("Pierre", 20, 30));
            //tests.Add(new Test("Jocelyn", 35, 60));
            //tests.Add(new Test("Robert", 31, 16));

            //Characters.ItemsSource = tests;
        }

        //public class Test
        //{
        //    public string Name { get; set; }
        //    public int Level { get; set; }
        //    public int Health { get; set; }

        //    public Test(string name, int level, int health)
        //    {
        //        Name = name;
        //        Level = level;
        //        Health = health;
        //    }
        //}

        private void Add_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Look_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
