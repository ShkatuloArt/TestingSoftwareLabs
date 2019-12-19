using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomation.Models
{
    public class SignIn
    {
        public string MemberId { get; set; }
        public string Password { get; set; }

        public SignIn(string memberId, string password)
        {
            this.MemberId = memberId;
            this.Password = password;
        }
    }
}