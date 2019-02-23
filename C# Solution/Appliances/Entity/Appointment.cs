using System;
using System.Collections.Generic;
using System.Text;

namespace Appliances.Entity
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public TimeSlot TimeSlot { get; set; }
        public Job Job { get; set; }
        public Engineer Engineer { get; set; }
    }
}
