using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAutomation.Models;

namespace TestAutomation.Service
{
    class CreatingSignIn
    {
        public static SignIn WithUserProperties()
        {
            return new SignIn(TestDataReader.GetData("MemberId"), TestDataReader.GetData("Password"));
        }
    }
}
