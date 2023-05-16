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
    /// Logique d'interaction pour InventoryPage.xaml
    /// </summary>
    public partial class InventoryPage : Page
    {
        public InventoryPage()
        {
            InitializeComponent();

            List<Test> t = new List<Test>();

            t.Add(new Test("Avion"));
            t.Add(new Test("Bob"));
            t.Add(new Test("Épée"));
            t.Add(new Test("Roger"));
            t.Add(new Test("Voiture"));
            t.Add(new Test("Lance"));
            t.Add(new Test("Concombre"));

            Objects.ItemsSource = t;

            List<Test2> i = new List<Test2>();

            i.Add(new Test2("Avion", 50, "1D8", 2));
            i.Add(new Test2("Avion", 50, "1D8", 2));
            i.Add(new Test2("Avion", 50, "1D8", 2));
            i.Add(new Test2("Avion", 50, "1D8", 2));
            i.Add(new Test2("Avion", 50, "1D8", 2));
            i.Add(new Test2("Avion", 50, "1D8", 2));
            i.Add(new Test2("Avion", 50, "1D8", 2));

            Inventory.ItemsSource = i;
        }

        public class Test
        {
            public string Name { get; set; }

            public Test(string name)
            {
                Name = name;
            }
        }

        public class Test2
        {
            public string Name { get; set; }
            public double Weight { get; set; }
            public string Dice { get; set; }
            public int Quantity { get; set; }

            public Test2(string name, double weight, string dice, int quantity)
            {
                Name = name;
                Weight = weight;
                Dice = dice;
                Quantity = quantity;
            }
        }
    }
}
