using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Xml;

namespace Task_1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Client> clients = new List<Client>();

        public MainWindow()
        {
            InitializeComponent();
        }

        static void ClearTextBoxes()
        {
            MainWindow mW = new MainWindow();
            mW.tbLastName.Clear();
            mW.textBoxFirstName.Clear();
            mW.textBoxPatronymic.Clear();
            mW.textBoxPhoneNumber.Clear();
            mW.textBoxPassport.Clear();
        }

        private void btnAddInf_Click(object sender, RoutedEventArgs e)
        {

            Client client = new Client(tbLastName.Text, 
                                       textBoxFirstName.Text, 
                                       textBoxPatronymic.Text, 
                                       textBoxPhoneNumber.Text, 
                                       textBoxPassport.Text);
            clients.Add(client);

            string xmlFilePath = "Repository.xml";
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);
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

            XmlElement rootElement = xmlDoc.DocumentElement;
            rootElement?.AppendChild(newPerson);
            xmlDoc.Save(xmlFilePath);

            MessageBox.Show("Запись о клиенте успешно добавлена!");
            ClearTextBoxes();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SearchPage searchPage = new SearchPage();
            searchPage.Show();
            Hide();
        }
    }
}