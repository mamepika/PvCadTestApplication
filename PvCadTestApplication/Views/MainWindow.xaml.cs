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
using PvCadTestApplication.Models.Entities;
using PvCadTestApplication.Models.Repositories;
using PvCadTestApplication.Models.Services;
using System.IO;
using PvCadTestApplication.ViewModels;

namespace PvCadTestApplication
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            RoofTopModuleTypeCheckService roofTopModuleTypeCheckService = new RoofTopModuleTypeCheckService();

            roofTopModuleTypeCheckService.Check();
        }
    }
}
