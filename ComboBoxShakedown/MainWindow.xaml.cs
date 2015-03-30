using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ComboBoxShakedown
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new ViewModel();
        }

        private void TopButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel vm = (ViewModel)DataContext;

            vm.SelectedModel = ((ObservableCollection<ShakedownModel>)vm.MyList.Source).SingleOrDefault(s => s.ID == 3);
        }

        private void BottomButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel vm = (ViewModel)DataContext;

            vm.SelectedID = 8;
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel vm = (ViewModel)DataContext;

            vm.SelectedID = null;
        }
    }
}
