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

namespace mvvmClient.SpecialUserControl
{
    /// <summary>
    /// Interaktionslogik für CalenderColumnPicker.xaml
    /// </summary>
    public partial class CalenderColumnPicker : UserControl
    {
        public static readonly DependencyProperty SelectedDateProperty =
        DependencyProperty.Register("SelectedDate", typeof(DateTime), typeof(CalenderColumnPicker));

        public CalenderColumnPicker()
        {
            InitializeComponent();
        }

        public DateTime SelectedDate
        {
            get { return (DateTime)GetValue(SelectedDateProperty); }
            set { SetValue(SelectedDateProperty, value); }
        }
    }
}
