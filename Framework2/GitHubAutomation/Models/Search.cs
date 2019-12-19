using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomation.Models
{
    public class Search
    {
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }

        public Search(string departureCity, string arrivalCity)
        {
            this.DepartureCity = departureCity;
            this.ArrivalCity = arrivalCity;
        }
    }
}