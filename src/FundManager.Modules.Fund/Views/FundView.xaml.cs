﻿using System;
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
using FundManager.Module.Fund.ViewModels;

namespace FundManager.Module.Fund.Views
{
    /// <summary>
    /// Interaction logic for FundView.xaml
    /// </summary>
    public partial class FundView : UserControl
    {
        public FundView(FundViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
