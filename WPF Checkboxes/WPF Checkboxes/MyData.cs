using System;
using System.Collections.Generic;
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
        All = 127
    }
    public class MyData
    {
        public MyData() { }
        public DayOfWeek Dow { get; set; } = DayOfWeek.All;
    }
}
