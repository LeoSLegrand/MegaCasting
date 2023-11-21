﻿using MegaCasting.DBLib.Class;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Doc.Children.Clear();
            this.Doc.Children.Add(new DiffuseurView());
        }
    }
}
