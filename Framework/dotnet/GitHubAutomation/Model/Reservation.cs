using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubAutomation.Model
{
    public class Reservation
    {
        public string ReservationCode { get; set; }
        public string PassengerName { get; set; }

        public Reservation(string reservationCode, string passengerName)
        {
            this.ReservationCode = reservationCode;
            this.PassengerName = passengerName;
        }
    }
}
