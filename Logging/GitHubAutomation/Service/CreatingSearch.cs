using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAutomation.Models;

namespace TestAutomation.Service
{
    class CreatingSearch
    {
        public static Search WithAllProperties()
        {
            return new Search(TestDataReader.GetData("DepartureCity"), TestDataReader.GetData("ArrivalCity"));
        }
    }
}
