using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAutomation.Models;

namespace TestAutomation.Service
{
    class CreatingPassanger
    {
        public static Passanger WithAllProperties()
        {
            return new Passanger(TestDataReader.GetData("FirstName"), TestDataReader.GetData("LastName"), TestDataReader.GetData("DateOfBirth"), TestDataReader.GetData("DocumentNumber"), TestDataReader.GetData("PhoneNumber"),
                TestDataReader.GetData("Email"), TestDataReader.GetData("ConfirmEmail"));
        }
        public static Passanger WithoutPhoneNumber()
        {
            return new Passanger(TestDataReader.GetData("FirstName"), TestDataReader.GetData("LastName"), TestDataReader.GetData("DateOfBirth"), TestDataReader.GetData("DocumentNumber"),"",
                TestDataReader.GetData("Email"), TestDataReader.GetData("ConfirmEmail"));
        }
        public static Passanger OnlyDateofBirth()
        {
            return new Passanger("", "", TestDataReader.GetData("DateOfBirth"), "", "", "", "");
        }
        public static Passanger OnlyDateofBirthChild()
        {
            return new Passanger("", "", TestDataReader.GetData("DateOfBirthChild"), "", "", "", "");
        }
    }
}