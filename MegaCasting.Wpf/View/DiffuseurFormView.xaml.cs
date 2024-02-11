using Azure;
using MegaCasting.Wpf.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using MegaCasting.Wpf.ViewModel;






namespace MegaCasting.Wpf.View
{
    /// <summary>
    /// Interaction logic for DiffuseurFormView.xaml
    /// </summary>
    public partial class DiffuseurFormView : UserControl
    {
        public DiffuseurFormView()
        {
            InitializeComponent();
            this.DataContext = new DiffuseurViewModel();
        }

        private void Insert_Click(object sender, RoutedEventArgs e) => ((DiffuseurViewModel)this.DataContext).AddDiffuseur();

        private void Update_Click(object sender, RoutedEventArgs e) => ((DiffuseurViewModel)this.DataContext).UpdateDiffuseur();
        private void Remove_Click(object sender, RoutedEventArgs e) => ((DiffuseurViewModel)this.DataContext).RemoveDiffuseur();
    }
}

