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
using EnglishExams.Infrastructure;
using EnglishExams.ViewModels;

namespace EnglishExams.Views
{
    /// <summary>
    /// Interaction logic for TestList.xaml
    /// </summary>
    public partial class TestListView : UserControl
    {
        public TestListView()
        {
            InitializeComponent();
        }

        private void ListBoxHander(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;

            var st = ButtonHelper.GetUnitName(button);

            var dc = DataContext as TestListViewModel;

            dc.
        }
    }
}
