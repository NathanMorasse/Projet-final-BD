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
    /// Logique d'interaction pour Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();

            List<Top3Lev> top3lev = new List<Top3Lev>();

            top3lev.Add(new Top3Lev("Bob", 10, 30));
            top3lev.Add(new Top3Lev("Serge", 9, 25));
            top3lev.Add(new Top3Lev("Pierre", 7, 26));

            TopLevels.ItemsSource = top3lev;

            List<Top3Latest> top3latests = new List<Top3Latest>();

            top3latests.Add(new Top3Latest("Bob", 10, DateTime.Now));
            top3latests.Add(new Top3Latest("Serge", 10, DateTime.Now));
            top3latests.Add(new Top3Latest("Pierre", 10, DateTime.Now));

            RecentChange.ItemsSource = top3latests;
        }

        public class Top3Lev
        {
            public string Name { get; set; }
            public int Level { get; set; }
            public int Health { get; set; }

            public Top3Lev(string name, int level, int health)
            {
                Name = name;
                Level = level;
                Health = health;
            }
        }

        public class Top3Latest
        {
            public string Name { get; set; }
            public int Level { get; set; }
            public DateTime DateModif { get; set; }

            public Top3Latest(string name, int level, DateTime dateModif)
            {
                Name = name;
                Level = level;
                DateModif = dateModif;
            }
        }
    }
}
