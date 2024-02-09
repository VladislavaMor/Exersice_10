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
using System.Windows.Shapes;
using static Task_1.SearchPage;


namespace Task_1
{
    public partial class ListIform : Window
    {
        public ListIform()
        {
            InitializeComponent();
            if (!flag)
            {
                lvClientsInfo.ItemsSource = Managers;
            }
            else
            {
                lvClientsInfo.ItemsSource = Consultants;
            }
        }
        static List<Client> clientsInfo = GetDataFromXml();
        List<Consultant> Consultants = TransformToConsultant(clientsInfo);
        List<Manager> Managers = TransformToManager(clientsInfo);

        public static List<Manager> TransformToManager(List<Client> clientsInfo)
        {
            List<Manager> managers = new List<Manager>();
            foreach (Client client in clientsInfo)
            {
                Manager manager = new Manager();
                manager.GetInformation(client);
                managers.Add(manager);
            }
            return managers;
        }
        public static List<Consultant> TransformToConsultant(List<Client> clientsInfo)
        {
            List<Consultant> consultants = new List<Consultant>();
            foreach(Client client in clientsInfo)
            {
                Consultant consultant = new Consultant();
                consultant.GetInformation(client);
                consultants.Add(consultant);
            }
            return consultants;
        }

    }
}
