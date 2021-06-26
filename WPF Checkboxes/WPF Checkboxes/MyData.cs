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
        None = 0,
        Sun = 1,
        Mon = 2,
        Tue = 4,
        Wed = 8,
        Thu = 16,
        Fri = 32,
        Sat = 64,
        MonThruFri = Mon | Tue | Wed | Thu | Fri,
        Weekends = Sat | Sun,
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
