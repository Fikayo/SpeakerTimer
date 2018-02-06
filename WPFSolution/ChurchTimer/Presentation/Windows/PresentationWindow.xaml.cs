namespace ChurchTimer.Presentation.Windows
{
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
    using System.Windows.Shapes;
    using ChurchTimer.Application.Controllers;
    using ChurchTimer.Presentation.ViewModels;

    /// <summary>
    /// Interaction logic for PresentationWindow.xaml
    /// </summary>
    public partial class PresentationWindow : Window
    {
        public PresentationWindow(TimerViewController controller)
        {
            InitializeComponent();
            this.DataContext = new WindowViewModel(this);
            this.timerView.ViewModel.Controller = controller;
        }
    }
}
