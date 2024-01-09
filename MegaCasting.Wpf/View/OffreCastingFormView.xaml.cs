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
    /// Interaction logic for OffreCastingView.xaml
    /// </summary>
    public partial class OffreCastingView : UserControl
    {
        public OffreCastingView()
        {
            InitializeComponent();
        }

        public void clear()
        {
            name.Clear();
            age.Clear();
            gender.Clear();
            city.Clear();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            clear();
        }
    }
}
