using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
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

namespace KikeletPanzio
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Szoba> szobak = new List<Szoba>();
        List<VendegAdat> vendegek = new List<VendegAdat>();
        public MainWindow()
        {
            InitializeComponent();
            szobak.Add(new Szoba { szobaSzam = 1, feroHely = 2, ejszakaAr = 7000 });
            szobak.Add(new Szoba { szobaSzam = 2, feroHely = 1, ejszakaAr = 6500 });
            szobak.Add(new Szoba { szobaSzam = 3, feroHely = 3, ejszakaAr = 8300 });
            szobak.Add(new Szoba { szobaSzam = 4, feroHely = 4, ejszakaAr = 11500 });
            szobak.Add(new Szoba { szobaSzam = 5, feroHely = 2, ejszakaAr = 7000 });
            szobak.Add(new Szoba { szobaSzam = 6, feroHely = 2, ejszakaAr = 7000 });
            SzobaHozzad();
        }
        private void SzobaHozzad() 
        {
            lbxSzobak.Items.Clear();
            foreach (var item in szobak)
            {
                lbxSzobak.Items.Add($"Szobaszám: {item.szobaSzam}\n Férőhely: {item.feroHely}\nÁr (Ft/Fő/Éj): {item.ejszakaAr}");
            }
        }


        private void Regisztral_Click(object sender, RoutedEventArgs e)
        {
            string id = tbxUgyfelID.Text;
            string name = tbxUgyfelNev.Text;
            DateTime birthDate = dpSzulIdo.SelectedDate ?? DateTime.Now;
            string email  =tbxEmail.Text;
            bool isVip = cbxVIP.IsChecked ?? false;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email)) 
            {
                MessageBox.Show("Kérem adja meg az összes adatot.");
                return;
            }


           VendegAdat ujVendeg = new VendegAdat( id, name, birthDate, email, isVip );
           vendegek.Add(ujVendeg);                
           UgyfelHozzad();
                
           tbxUgyfelNev.Clear();
           dpSzulIdo.SelectedDate = null;
           tbxEmail.Clear();
           tbxUgyfelID.Clear();
           cbxVIP.IsChecked = false;
        }

        private void UgyfelHozzad() 
        {
            lbRegisztraltUgyfel.Items.Clear();
            foreach (var item in vendegek)
            {
                lbRegisztraltUgyfel.Items.Add($"Azonosító: {item.Id}\nNév: {item.Name}\nE-mail: {item.Email}\nVIP: {item.Vip}");
            }
        }
    }
}
