﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using MainApplication = System.Windows.Application;

namespace ChurchTimer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : MainApplication
    {
        void App_Startup(object sender, StartupEventArgs e)
        {
            var controller = new ChurchTimer.Application.Controllers.TimerViewController();
            var window = new ChurchTimer.Presentation.Windows.ControlPanelWindow(controller);
            //var awindow = new ChurchTimer.Presentation.Windows.PresentationWindow(controller);
            window.Show();
            //awindow.Show();

            controller.Settings.Metadata.Title = "New Timer";
            controller.Settings.VisualSettings.CounterMode = Application.TimerCounterMode.CountDownToMinus;
            controller.Settings.DurationSettings.Duration = 60;
            controller.Settings.DurationSettings.FirstWarningTime = 30;
            //controller.Settings.DurationSettings.SecondWarningTime = 5;
            controller.Settings.Metadata.BlinkingWhenExpired = true;
            controller.PublishSettings();

            controller.StartTimer();
            controller.EnabledBlinking();

            var timerMessage = new ChurchTimer.Application.TimerMessageSettings();
            timerMessage.MessageDuration = 12000;
            timerMessage.TimerMessage = "Hello, this is a nice message; I hope you like it. Have a lovely day at work. :-)";
            timerMessage.MessageFontSize = 100;

            controller.BroadcastMessage(timerMessage);
        }
    }
}