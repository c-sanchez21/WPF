﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;


namespace WPF_Checkboxes
{
    public class DowConverter : IValueConverter
    {
        private DayOfWeek dow; 
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Bit Mask for Sat, Sun, Mon, ...etc
            DayOfWeek mask = (DayOfWeek)parameter; 

            this.dow = (DayOfWeek)value;

            //Return the result
            return ((mask & this.dow) != 0);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            this.dow ^= (DayOfWeek)parameter;
            return this.dow;
        }
    }
}
