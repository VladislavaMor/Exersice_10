using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Task_1.SearchPage;

namespace Task_1
{
    public class Consultant: IChangeProperty
    { 
        public string LastName { get;  set; }
        public string FirstName { get; set; }
        public string Patronymic { get;  set; }
        public string PhoneNumber { get; set; }
        public string Passport { get; set; }



        public virtual void  GetInformation(Client client)
        {
            LastName = client.LastName;
            FirstName = client.FirstName;
            Patronymic = client.Patronymic;
            PhoneNumber = client.PhoneNumber;
            if (client.Passport != "") Passport = "***********";
            else Passport = client.Passport;
    
        }
        public void ChangeProperty(string PhoneProperty, string newProperty, int count)
        {
            List<Client> clientsInfo = GetDataFromXml();
            foreach (Client c in clientsInfo)
            {
                if (c.PhoneNumber == PhoneProperty)
                {
                    if (count == 4) c.PhoneNumber = newProperty;
                    c.TimeChange = DateTime.Now.ToString();
                    c.TypeData =  $"Запись о {c.LastName} {c.FirstName} {c.Patronymic}";
                    c.TypeChange = $"Изменение номера телефона";
                    c.User = "Консультант";
                }
            }
            PutToXML(clientsInfo);
        }
    }
}
