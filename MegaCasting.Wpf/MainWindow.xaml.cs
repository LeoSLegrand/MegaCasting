using MegaCasting.DBLib.Class;
using MegaCasting.Wpf.View;
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
namespace MegaCasting.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            using (MegaCastingContext mg = new())
            {
                var test = mg.Diffuseurs.ToList().First();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e) //Liste Diffuseur
        {
            this.Doc.Children.Clear();
            this.Doc.Children.Add(new DiffuseurView());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) //Ajouter Artiste
        {
            this.Doc.Children.Clear();
            this.Doc.Children.Add(new ArtisteView());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) //Liste Artiste
        {
            this.Doc.Children.Clear();
            this.Doc.Children.Add(new ArtisteListView());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e) //Ajouter offre Casting
        {
            this.Doc.Children.Clear();
            this.Doc.Children.Add(new OffreCastingView());
        }

        private void Button_Click_4(object sender, RoutedEventArgs e) //Ajouter Diffuseur
        {
            this.Doc.Children.Clear();
            this.Doc.Children.Add(new DiffuseurFormView());
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            this.Doc.Children.Clear();
            this.Doc.Children.Add(new OffreCastingListe());
        }
    }
}
