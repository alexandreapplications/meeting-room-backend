using System;
using System.Collections.Generic;
using System.Text;

namespace AlexandreApps.Meeting_Room.Core.Models.Places
{
    public class PlaceAvailabilityModel
    {
        public DateTime? InitialDate { get; set; }
        public DateTime? FinalDate { get; set; }
        public int WeekDay { get; set; }
        public int InitialTime { get; set; }
        public int FinalTime { get; set; }
    }
}
