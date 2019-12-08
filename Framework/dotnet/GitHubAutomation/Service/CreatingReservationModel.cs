using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GitHubAutomation.Model;
using GitHubAutomation.Utils;

namespace GitHubAutomation.Service
{
    class CreatingReservationModel
    {
        public static Reservation WithReservationProperties()
        {
            return new Reservation(TestDataReader.GetData("ReservationCode"), TestDataReader.GetData("PassengerName"));
        }
    }
}
