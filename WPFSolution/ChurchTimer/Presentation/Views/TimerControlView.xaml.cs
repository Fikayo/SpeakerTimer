using ChurchTimer.Application.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls;
using ChurchTimer.Presentation.ViewModels;

namespace ChurchTimer.Presentation.Views
{
    /// <summary>
    /// Interaction logic for TimerControlView.xaml
    /// </summary>
    public partial class TimerControlView : UserControl
    {
        private TimerControlViewModel viewModel;

        public TimerControlView()
        {
            InitializeComponent();

            this.viewModel = new TimerControlViewModel();
            this.DataContext = this.viewModel;
        }

        public TimerViewController Controller
        {
            get { return this.viewModel.Controller; }

            set
            {
                this.viewModel.Controller = value;
                this.timerPreview.ViewModel.Controller = value;
            }
        }
    }
}
