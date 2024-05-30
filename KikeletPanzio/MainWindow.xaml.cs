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
        List<Foglalas> foglalasok = new List<Foglalas>();
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
                lbxSzobak.Items.Add(item);
            }
        }


        private void Regisztral_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(tbxUgyfelNev.Text))
            {
                MessageBox.Show("Kérem adja meg az ügyfél nevét.");
                return;
            }

            if (dpSzulIdo.SelectedDate == null)
            {
                MessageBox.Show("Kérem adja meg az ügyfél születési dátumát.");
                return;
            }

            string name = tbxUgyfelNev.Text;
            DateTime birthDate = dpSzulIdo.SelectedDate.Value;
            string email = tbxEmail.Text;
            bool isVip = !string.IsNullOrWhiteSpace(email);

            VendegAdat ujVendeg = new VendegAdat(name, birthDate, email, isVip);
            vendegek.Add(ujVendeg);

            UgyfelHozzad();
            tbxUgyfelID.Text = ujVendeg.Id;

            tbxUgyfelNev.Clear();
            tbxUgyfelID.Clear();
            dpSzulIdo.SelectedDate = null;
            tbxEmail.Clear();
        }

        private void UgyfelHozzad()
        {
            cbxUgyfelek.Items.Clear();
            lbRegisztraltUgyfel.Items.Clear();
            foreach (var vendeg in vendegek)
            {
                lbRegisztraltUgyfel.Items.Add($"Név: {vendeg.Name}\nSzületési év: {vendeg.SzulIdo.ToShortDateString()}\nVIP: {vendeg.Vip}\nAzonosító: {vendeg.Id}");
                cbxUgyfelek.Items.Add(vendeg);
            }

        }
        private void btnFoglal_Click_1(object sender, RoutedEventArgs e)
        {
            if (dpErkezesDatum.SelectedDate == null || dpTavozasDatum.SelectedDate == null)
            {
                MessageBox.Show("Kérem válassza ki az érkezés és távozás dátumát!");
                return;
            }

            DateTime erkezesDatum = dpErkezesDatum.SelectedDate.Value;
            DateTime tavozasDatum = dpTavozasDatum.SelectedDate.Value;

            if (erkezesDatum >= tavozasDatum)
            {
                MessageBox.Show("Érkezés dátumának kisebbnek kell lennie, mint a távozás dátuma!");
                return;
            }

            if (!int.TryParse(tbxFoszam.Text, out int foglaltFerohely) || foglaltFerohely <= 0)
            {
                MessageBox.Show("Kérem adjon meg egy érvényes főszámot!");
                return;
            }

            var selectedSzoba = lbxSzobak.SelectedItem as Szoba;
            if (selectedSzoba == null)
            {
                MessageBox.Show("Kérem válasszon ki egy szobát!");
                return;
            }

            var selectedVendeg = cbxUgyfelek.SelectedItem as VendegAdat;
            if (selectedVendeg == null)
            {
                MessageBox.Show("Kérem válasszon ki egy ügyfelet!");
                return;
            }

            int foglaltEjszakak = (int)(tavozasDatum - erkezesDatum).TotalDays;
            if (foglaltEjszakak <= 0)
            {
                MessageBox.Show("Hibás érkezés vagy távozás dátum!");
                return;
            }

            if (foglaltFerohely > selectedSzoba.FeroHely)
            {
                MessageBox.Show("A kiválasztott szoba nem rendelkezik elegendő férőhellyel.");
                return;
            }

            double szobaAr = selectedSzoba.EjszakaAr * foglaltEjszakak;
            double kedvezmeny = selectedVendeg.Vip ? 0.03 : 0.0;  // 3% kedvezmény VIP ügyfeleknek
            double osszkoltseg = szobaAr * (1 - kedvezmeny);

            Foglalas ujFoglalas = new Foglalas
            {
                Szoba = selectedSzoba,
                Vendeg = selectedVendeg,
                ErkezesDatum = erkezesDatum,
                TavozasDatum = tavozasDatum,
                Foszam = foglaltFerohely,
                Osszkoltseg = osszkoltseg
            };

            foglalasok.Add(ujFoglalas);

            string foglalasAdatok = $"Ügyfél ID: {selectedVendeg.Id}, Név: {selectedVendeg.Name}, " +
                $"Szoba: {selectedSzoba.SzobaSzam}, Főszám: {foglaltFerohely}, " +
                $"Érkezés: {erkezesDatum.ToShortDateString()}, Távozás: {tavozasDatum.ToShortDateString()}, " +
                $"Éjszakák száma: {foglaltEjszakak}, Összköltség: {osszkoltseg} HUF";

            lbFoglaltSzobak.Items.Add(foglalasAdatok);

            tbxEjszakakSzama.Text = foglaltEjszakak.ToString();

            dpErkezesDatum.SelectedDate = null;
            dpTavozasDatum.SelectedDate = null;
            tbxFoszam.Clear();
            lbxSzobak.SelectedItem = null;

            Statisztika();
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateEjszakakSzama();
        }

        private void UpdateEjszakakSzama()
        {
            if (dpErkezesDatum.SelectedDate != null && dpTavozasDatum.SelectedDate != null)
            {
                DateTime erkezesDatum = dpErkezesDatum.SelectedDate.Value;
                DateTime tavozasDatum = dpTavozasDatum.SelectedDate.Value;

                if (erkezesDatum < tavozasDatum)
                {
                    int ejszakakSzama = (int)(tavozasDatum - erkezesDatum).TotalDays;
                    tbxEjszakakSzama.Text = ejszakakSzama.ToString();
                }
                else
                {
                    tbxEjszakakSzama.Text = "0";
                }
            }
            else
            {
                tbxEjszakakSzama.Text = "0";
            }
        }


        private void Statisztika()
        {
            // Összes bevétel
            double osszesBevetel = 0;
            foreach (var foglalas in foglalasok)
            {
                osszesBevetel += foglalas.Osszkoltseg;
            }
            txtOsszesBevetel.Text = $"{osszesBevetel} HUF";

            // Legtöbbet kiadott szoba
            Dictionary<int, double> szobaBevetelek = new Dictionary<int, double>();
            foreach (var foglalas in foglalasok)
            {
                if (!szobaBevetelek.ContainsKey(foglalas.Szoba.SzobaSzam))
                {
                    szobaBevetelek.Add(foglalas.Szoba.SzobaSzam, 0);
                }
                szobaBevetelek[foglalas.Szoba.SzobaSzam] += foglalas.Osszkoltseg;
            }
            int legtobbBevetelSzobaSzam = -1;
            double legtobbBevetel = 0;
            foreach (var item in szobaBevetelek)
            {
                if (item.Value > legtobbBevetel)
                {
                    legtobbBevetel = item.Value;
                    legtobbBevetelSzobaSzam = item.Key;
                }
            }
            if (legtobbBevetelSzobaSzam != -1)
            {
                txtLegtobbetKiadottSzoba.Text = $"Szoba száma: {legtobbBevetelSzobaSzam}";
            }

            // Fizetett összeg szerint csökkenő sorrend
            lbFizetettOsszegSzerint.Items.Clear();
            foreach (var item in foglalasok)
            {
                lbFizetettOsszegSzerint.Items.Add($"{item.Vendeg.Name}: {item.Osszkoltseg} HUF");
            }
        }
    }
}
