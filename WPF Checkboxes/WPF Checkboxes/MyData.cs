using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace WPF_Checkboxes
{
    [Flags]
    public enum DayOfWeek
    {
        [Description("None")]
        None = 0,
        [Description("Sunday")]
        Sun = 1,
        [Description("Monday")]
        Mon = 2,
        [Description("Tuesday")]
        Tue = 4,
        [Description("Wednesday")]
        Wed = 8,
        [Description("Thursday")]
        Thu = 16,
        [Description("Friday")]
        Fri = 32,
        [Description("Saturday")]
        Sat = 64,
        [Description("Monday thru Friday")]
        MonThruFri = Mon | Tue | Wed | Thu | Fri,
        [Description("Weekend")]
        Weekends = Sat | Sun,
        [Description("Everyday")]
        Everyday = 127
    }
    public class MyData : INotifyPropertyChanged
    {
        public MyData() { }

        private DayOfWeek dow = DayOfWeek.MonThruFri;
        public DayOfWeek Dow
        {
            get
            {
                return dow;
            }
            set
            {
                dow = value;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
