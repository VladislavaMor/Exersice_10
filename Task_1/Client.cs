using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    public class Client
    {
        private string lastName;
        private string firstName;
        private string patronymic;
        private string phoneNumber;
        private string pasport;
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public string PhoneNumber { get; set; }
        public string Passport { get; set; }
        public string TimeChange { get; set; }
        public string TypeData { get; set; }
        public string TypeChange { get; set; }
        public string User { get; set; }

        public Client(string lastname, string firstname, string patronymic, string phonenumber, string passport)
        {
            this.LastName = lastname;
            this.FirstName = firstname;
            this.Patronymic = patronymic;
            this.PhoneNumber = phonenumber;
            this.Passport = passport;
            this.TimeChange = DateTime.Now.ToString();
            this.TypeData = String.Empty;
            this.TypeChange = "Добавление записи";
            this.User = String.Empty;    
        }
        public Client() { }

        public void consultantChange(Consultant consultant)
        {
            LastName = consultant.LastName;
            FirstName = consultant.FirstName;
            Patronymic = consultant.Patronymic;
            PhoneNumber = consultant.PhoneNumber;
            Passport = consultant.Passport;
        }


    }
}
