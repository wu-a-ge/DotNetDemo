﻿using System;
using System.Windows;
using System.Windows.Controls;

namespace VS2010.SilverlightApp.Test
{
    public partial class ErrorWindow : ChildWindow
    {
        public ErrorWindow(Exception e)
        {
            InitializeComponent();
            if (e != null)
            {
                ErrorTextBox.Text = e.Message + Environment.NewLine + Environment.NewLine + e.StackTrace;
            }
        }

        public ErrorWindow(Uri uri)
        {
            InitializeComponent();
            if (uri != null)
            {
                ErrorTextBox.Text = "未找到页面: \"" + uri.ToString() + "\"";
            }
        }

        public ErrorWindow(string message, string details)
        {
            InitializeComponent();
            ErrorTextBox.Text = message + Environment.NewLine + Environment.NewLine + details;
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}