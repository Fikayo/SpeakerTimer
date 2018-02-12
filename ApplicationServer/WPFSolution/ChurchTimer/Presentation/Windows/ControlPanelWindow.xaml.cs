﻿using ChurchTimer.Application.Controllers;
using ChurchTimer.Presentation.ViewModels;
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

namespace ChurchTimer.Presentation.Windows
{
    /// <summary>
    /// Interaction logic for ControlPanelWindow.xaml
    /// </summary>
    public partial class ControlPanelWindow : Window
    {
        public ControlPanelWindow(TimerViewController controller)
        {
            InitializeComponent();
            this.DataContext = this.ViewModel = new ControlPanelViewModel(this, controller);
        }

        public WindowViewModel ViewModel { get; private set; }
    }
}