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
    /// Logique d'interaction pour CharacterPage.xaml
    /// </summary>
    public partial class CharacterPage : Page
    {
        public CharacterPage(VMPersonnage dataContext)
        {
            InitializeComponent();
            VMPersonnage vm = dataContext;
            this.DataContext = vm;
            sub_frame.Navigate(new StatsPage((VMPersonnage)this.DataContext));
        }

        private void Stats_Click(object sender, RoutedEventArgs e)
        {
            sub_frame.Navigate(new StatsPage((VMPersonnage)this.DataContext));
        }

        private void Charateristic_Click(object sender, RoutedEventArgs e)
        {
            sub_frame.Navigate(new CharPage((VMPersonnage)this.DataContext));
        }

        private void Inventory_Click(object sender, RoutedEventArgs e)
        {
            sub_frame.Navigate(new InventoryPage((VMPersonnage)this.DataContext));
        }

        private void Abilities_Click(object sender, RoutedEventArgs e)
        {
            sub_frame.Navigate(new AbilityPage((VMPersonnage)this.DataContext));
        }

        private void sub_frame_Navigated(object sender, NavigationEventArgs e)
        {

        }
    }
}
