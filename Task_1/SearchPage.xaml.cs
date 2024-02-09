using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml;

namespace Task_1
{
    /// <summary>
    /// Логика взаимодействия для SearchPage.xaml
    /// </summary>
    public partial class SearchPage : Window
    {
        public SearchPage()
        {
            InitializeComponent();
            if (flag==false)
            {
                btnAdd.Visibility = Visibility.Hidden;
            }
            else btnAdd.Visibility = Visibility.Visible;
        }

        public static bool flag = false;

        public static List<Client> GetDataFromXml()
        {
                List<Client> clientsInfo = new List<Client>();
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load("Repository.xml");
                // получим корневой элемент
                XmlElement xRoot = xDoc.DocumentElement;
                if (xRoot != null)
                {
                    foreach (XmlElement xnode in xRoot)
                    {
                        Client client = new Client();

                        foreach (XmlNode childnode in xnode.ChildNodes)
                        {
                            // если узел - company
                            if (childnode.Name == "LastName") client.LastName = childnode.InnerText;
                            if (childnode.Name == "FirstName") client.FirstName = childnode.InnerText;
                            if (childnode.Name == "Patronymic") client.Patronymic = childnode.InnerText;
                            if (childnode.Name == "PhoneNumber") client.PhoneNumber = childnode.InnerText;
                            if (childnode.Name == "Passport") client.Passport = childnode.InnerText;
                            if (childnode.Name == "TimeChange") client.TimeChange = childnode.InnerText;
                            if (childnode.Name == "TypeData") client.TypeData = childnode.InnerText;
                            if (childnode.Name == "TypeChange") client.TypeChange = childnode.InnerText;
                            if (childnode.Name == "User") client.User = childnode.InnerText;
                    }
                        clientsInfo.Add(client);
                    }
                }
                return clientsInfo;
        }

        public static void PutToXML(List<Client> clientsInfo)
        {
            string xmlFilePath = "Repository.xml";
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);
            XmlElement xRoot = xmlDoc.DocumentElement;

            foreach (Client client in clientsInfo)
            {   
                XmlElement newPerson = xmlDoc.CreateElement("Client");

                XmlElement lastNameElement = xmlDoc.CreateElement("LastName");
                lastNameElement.InnerText = client.LastName;
                newPerson.AppendChild(lastNameElement);

                XmlElement firstNameElement = xmlDoc.CreateElement("FirstName");
                firstNameElement.InnerText = client.FirstName;
                newPerson.AppendChild(firstNameElement);

                XmlElement patronymicElement = xmlDoc.CreateElement("Patronymic");
                patronymicElement.InnerText = client.Patronymic;
                newPerson.AppendChild(patronymicElement);

                XmlElement phoneNumberElement = xmlDoc.CreateElement("PhoneNumber");
                phoneNumberElement.InnerText = client.PhoneNumber;
                newPerson.AppendChild(phoneNumberElement);

                XmlElement passportElement = xmlDoc.CreateElement("Passport");
                passportElement.InnerText = client.Passport;
                newPerson.AppendChild(passportElement);

                XmlElement TimeChangeElement = xmlDoc.CreateElement("TimeChange");
                TimeChangeElement.InnerText = client.TimeChange;
                newPerson.AppendChild(TimeChangeElement);

                XmlElement TypeDataElement = xmlDoc.CreateElement("TypeData");
                TypeDataElement.InnerText = client.TypeData;
                newPerson.AppendChild(TypeDataElement);

                XmlElement TypeChangeElement = xmlDoc.CreateElement("TypeChange");
                TypeChangeElement.InnerText = client.TypeChange;
                newPerson.AppendChild(TypeChangeElement);

                XmlElement UserElement = xmlDoc.CreateElement("User");
                UserElement.InnerText = client.User;
                newPerson.AppendChild(UserElement);

                xRoot?.AppendChild(newPerson);
                xmlDoc.Save(xmlFilePath);
            }
            MessageBox.Show("Данные успешно изменены.");
        }

        /// <summary>
        /// Открытие формы добавления клиентов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
        }

        private void btnGetFromDB_Click(object sender, RoutedEventArgs e)
        {
            List<Client> clients = GetDataFromXml();
            
            MessageBox.Show("Данные успешно считаны.");
        }

        /// <summary>
        /// Показать список клиентов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ListIform listIform = new ListIform();
            listIform.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Change change = new Change();
            change.Show();
        }

        private void cbPersonal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbPersonal.Text == "Менеджер")
            {
                flag = true;
                btnAdd.Visibility = Visibility.Hidden;
            }
            else
            {
                flag = false;
                btnAdd.Visibility = Visibility.Visible;
            }
        }
    }


    
}
