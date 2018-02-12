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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ChurchTimer.Presentation.ViewModels;

namespace ChurchTimer.Presentation.Views
{
    /// <summary>
    /// Interaction logic for BasicTimerView.xaml
    /// </summary>
    public partial class BasicTimerView : UserControl
    {
        private BasicTimerViewModel viewModel;

        public BasicTimerView()
        {
            InitializeComponent();

            this.ViewModel = new BasicTimerViewModel();
        }

        public BasicTimerViewModel ViewModel
        {
            get { return this.viewModel; }

            set
            {
                this.viewModel = value;
                this.DataContext = value;
            }
        }
    }
}
