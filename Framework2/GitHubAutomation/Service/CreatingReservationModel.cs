using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAutomation.Models;

namespace TestAutomation.Service
{
    class CreatingReservationModel
    {
        public static Reservation WithReservationProperties()
        {
            return new Reservation(TestDataReader.GetData("ReservationCode"), TestDataReader.GetData("PassengerName"));
        }
    }
}
