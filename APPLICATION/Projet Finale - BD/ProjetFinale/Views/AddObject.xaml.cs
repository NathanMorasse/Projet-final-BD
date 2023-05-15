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
    /// Logique d'interaction pour AddObject.xaml
    /// </summary>
    public partial class AddObject : Page
    {
        public AddObject(VMItem dataContext)
        {
            InitializeComponent();
            VMItem vm = dataContext;
            this.DataContext = vm;
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProjetFinale.Views.ObjectsList((VMItem)this.DataContext));
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProjetFinale.Views.ObjectsList());
        }
    }
}
