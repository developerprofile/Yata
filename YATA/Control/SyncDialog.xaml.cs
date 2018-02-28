﻿using Microsoft.Toolkit.Uwp.UI.Animations;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using YATA.Services;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace YATA.Control
{
    public sealed partial class SyncDialog : UserControl
    {
        

        public SyncDialog()
        {
            this.InitializeComponent();
        }
        public static event EventHandler CloseDialogButtonClicked;

        private void ResetScoreButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private async void SyncButton_Click(object sender, RoutedEventArgs e)
        {
            bool canLogin;
            bool synced = false;

            if (!CloudSyncService.serviceStarted)
            {
               canLogin = await App.syncService.Begin();
            }
            else
            {
                canLogin = CloudSyncService.serviceStarted;
            }


            if (canLogin)
            {
                synced = await App.syncService.Sync();
                Debug.WriteLine("Has synced " + synced);
            }
        }

        private void EnableSyncToggleSwitch_Toggled(object sender, RoutedEventArgs e)
        {

        }


        private async void CloseDialogButton_Click(object sender, RoutedEventArgs e)
        {
            CloseDialogButtonClicked?.Invoke(this, EventArgs.Empty);
            await this.Fade(0).StartAsync();
        }
    }
}
