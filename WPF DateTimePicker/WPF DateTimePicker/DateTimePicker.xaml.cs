using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_DateTimePicker
{
    /// <summary>
    /// Interaction logic for DateTimePicker.xaml
    /// </summary>
    public partial class DateTimePicker : UserControl, INotifyPropertyChanged
    {
        public DateTimePicker()
        {
            InitializeComponent();

        }

        #region Properties
        public DateTime? SelectedDate
        {
            get
            {
                return (DateTime?)GetValue(SelectedDateProperty);
            }
            set
            {
                SetValue(SelectedDateProperty, value);
                NotifyPropertyChanged();
            }
        }

        public static readonly DependencyProperty SelectedDateProperty =
            DependencyProperty.Register("SelectedDate", typeof(Nullable<DateTime>), typeof(DateTimePicker),
                new PropertyMetadata(DateTime.Now, new PropertyChangedCallback(OnSelectedDateChanged),
                    new CoerceValueCallback(CoerceDate)));

        private const string DateFormat = "yyyy-MMM-dd ddd HH:mm";

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public static void OnSelectedDateChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            if (!(o is DateTimePicker dtp)) return; //Return if o is not a DateTimePicker
            if (e == null || e.NewValue == null)
            { //If null value date
                dtp.txtDateTime.Text = "";
            }
            else
            {
                DateTime d = (DateTime)e.NewValue;
                dtp.txtDateTime.Text = d.ToString(DateFormat);
                dtp.calView.SelectedDate = d;
                dtp.calView.DisplayDate = d;
            }
        }
        #endregion
        private static object CoerceDate(DependencyObject d, object value)
        {
            //Method reserved for future use in validating date (i.e Min/Max date)
            return value;
        }

        private void calView_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            CalendarButton.IsChecked = false;
            if (!calView.SelectedDate.HasValue) return;
            DateTime d = calView.SelectedDate.Value;
            DateTime? t = SelectedDate; //Preserve time component
            SelectedDate = new DateTime(d.Year, d.Month, d.Day, t.Value.Hour, t.Value.Minute, t.Value.Second);
        }

        private void txtDateTime_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            int idx = txtDateTime.SelectionStart;
            //Focuses on the date component that was clicked on
            SelDateComponent(idx); 
        }

        /// <summary>
        /// Selects the date/time component user at idx.
        /// </summary>
        /// <param name="idx"></param>
        private void SelDateComponent(int idx)
        {
            //Check for out of bounds
            if (idx >= DateFormat.Length) idx = DateFormat.Length - 1;

            //Find first letter of the DateFormat that is being selected
            char c = DateFormat.Substring(idx, 1)[0];
            int first = DateFormat.IndexOf(c); 

            //Get the length of the component (i.e HH or yyyy)
            int last = DateFormat.LastIndexOf(c) + 1;
            int len = last - first;

            //Select the date component
            txtDateTime.Focus();
            txtDateTime.Select(first, len);
        }

        private void txtDateTime_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            int idx = txtDateTime.SelectionStart;
            e.Handled = true; //Prevents advancing cursor
            switch(e.Key)
            {
                case Key.Up:
                    SelectedDate = AddToDate(idx, 1);//Increment
                    SelDateComponent(idx);
                    break;
                case Key.Down:
                    SelectedDate = AddToDate(idx, -1);//Decrement
                    SelDateComponent(idx);
                    break;
            }
          
        }

        private DateTime AddToDate(int idx, int val)
        {
            //Get the date being displayed
            DateTime d = DateTime.Parse(txtDateTime.Text);
            //First letter of the DateFormat selected
            char c = DateFormat[idx];

            //TODO: Need a try/catch for invalid dates;
            switch (c)
            {
                case 'y':
                    d = d.AddYears(val);
                    break;
                case 'M':
                    d = d.AddMonths(val);
                    break;
                case 'd':
                    d = d.AddDays(val);
                    break;
                case 'h':
                case 'H':
                    d = d.AddHours(val);
                    break;
                case 'm':
                    d = d.AddMinutes(val);
                    break;
                case 's':
                    d = d.AddSeconds(val);
                    break;
                case 'f':
                    d = d.AddMilliseconds(val);
                    break;
            }
            return d;
        }
    }
}