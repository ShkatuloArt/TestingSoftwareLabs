using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomation.Models
{
    public class Passanger
    {
        public string PassangerFirstName { get; set; }
        public string PassangerLastName { get; set; }
        public string PassangerDateOfBirth { get; set; }
        public string PassangerDocumentNumber { get; set; }
        public string PassangerPhoneNumber { get; set; }
        public string PassangerEmail { get; set; }
        public string PassangerEmailConfirm { get; set; }

        public Passanger(string passangerFirstName, string passangerLastName, string passangerDateOfBirth, string passangerDocumentNumber, string passangerPhoneNumber, string passangerEmail, string passangerEmailConfirm )
        {
            this.PassangerFirstName = passangerFirstName;
            this.PassangerLastName = passangerLastName;
            this.PassangerDateOfBirth = passangerDateOfBirth;
            this.PassangerDocumentNumber = passangerDocumentNumber;
            this.PassangerPhoneNumber = passangerPhoneNumber;
            this.PassangerEmail = passangerEmail;
            this.PassangerEmailConfirm = passangerEmailConfirm;
        }
    }
}

