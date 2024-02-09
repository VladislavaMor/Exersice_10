using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Task_1.SearchPage;

namespace Task_1
{
    public class Manager : Consultant
    {
        public override void GetInformation(Client client)
        {
            LastName = client.LastName;
            FirstName = client.FirstName;
            Patronymic = client.Patronymic;
            PhoneNumber = client.PhoneNumber;
            Passport = client.Passport;
        }
        public new void ChangeProperty(string PhoneProperty, string newProperty, int count)
        {
            List<Client> clientsInfo = GetDataFromXml();
            foreach (Client c in clientsInfo)
            {
                if (c.PhoneNumber == PhoneProperty)
                {
                    if (count == 1)
                    {
                        c.LastName = newProperty;
                        c.TypeChange = $"Изменение фамилии";
                    }
                    if (count == 2)
                    {
                        c.FirstName = newProperty;
                        c.TypeChange = $"Изменение имени";
                    }
                    if (count == 3)
                    {
                        c.Patronymic = newProperty;
                        c.TypeChange = $"Изменение отчества";
                    }
                    if (count == 4) 
                    { 
                        c.PhoneNumber = newProperty;
                        c.TypeChange = $"Изменение номера телефона";
                    }
                    if (count == 5)
                    {
                        c.Passport = newProperty;
                        c.TypeChange = $"Изменение паспорта";
                    }
                    c.TimeChange = DateTime.Now.ToString();
                    c.TypeData = $"Запись о {c.LastName} {c.FirstName} {c.Patronymic}";
                    c.User = "Менеджер";
                }
            }
            PutToXML(clientsInfo);
        }
    }
}
