using MegaCasting.Wpf.ViewModel;
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

namespace MegaCasting.Wpf.View
{
    /// <summary>
    /// Interaction logic for ArtisteView.xaml
    /// </summary>
    public partial class ArtisteView : UserControl
    {
        public ArtisteView()
        {
            InitializeComponent();
            this.DataContext = new ArtisteListViewModel();
        }

        private void Insert_Click(object sender, RoutedEventArgs e) => ((ArtisteListViewModel)this.DataContext).AddArtiste();
        private void Update_Click(object sender, RoutedEventArgs e) => ((ArtisteListViewModel)this.DataContext).UpdateArtiste();
        private void Remove_Click(object sender, RoutedEventArgs e) => ((ArtisteListViewModel)this.DataContext).RemoveArtiste();
    }
}