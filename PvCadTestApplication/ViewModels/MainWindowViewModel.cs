using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace PvCadTestApplication.ViewModels
{
    class MainWindowViewModel : BaseViewModel
    {

        public ICommand _Check { get; private set; }

        private void CheckExecute(object parameter)
        {
            Console.WriteLine("メソッド実行");
        }

        public ICommand Check
        {
            get
            {
                return _Check;
            }
            
        }
        public MainWindowViewModel()
        {
            
        }
    }
}
