using Mietmaschienenservice_Dienstproxy.Client.L2.Proxy.ClientProxy;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client.L3.Dienstclient.ConsolenClient
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter Client name");
            string str = Console.ReadLine();
            MietserviceClient modell = new MietserviceClient();
            MietserviceClient modell1 = new MietserviceClient();
            MietserviceClient modell2 = new MietserviceClient();
            for(int i=0;i<5;i++)
            {
                Console.WriteLine(modell.Call(str)  + "\n");
                Console.WriteLine(modell1.Call(str) + "\n");
                Console.WriteLine(modell2.Call(str) + "\n");
            }

            Console.WriteLine("Ende");
            Console.ReadLine();

            Kunde DieserKunde = new Kunde();
            DieserKunde.Kundenname = "Simon";
            DieserKunde.Kundengesamtumsatz = 0;

            ObservableCollection<Kunde> neuerKunde = new ObservableCollection<Kunde>() { DieserKunde };
            
            String Statistik = modell.SaveKundenSet(ref neuerKunde);
            Console.WriteLine("\nStatistik: " + Statistik + "\n");

            try
            {
                ObservableCollection<Kunde> angelegteKunden = modell.GetAllKunden();

                foreach (Kunde testKundendaten in angelegteKunden)
                {
                    Console.WriteLine(testKundendaten);                   
                }
                Console.ReadLine();
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(DieserKunde.ToString() + " | " + ex.Message.ToString());
                Console.ReadLine();
            }
            modell.Close();
        }
    }
}
