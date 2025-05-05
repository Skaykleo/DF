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

namespace DigitalFishing
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

    {
        List<Pigiste> lesPigistes = new List<Pigiste>();
        List<Magazine> lesMagazines = new List<Magazine>();
        List<Contrat> lesContrats = new List<Contrat>();
        List<Magazine> filtreMagazine = new List<Magazine>();
        List<Pigiste> filtrePigiste = new List<Pigiste>();
        private void LoadMagazine()
        {
            lesMagazines = bdd.SelectMagazine();
            dtgMagazine.ItemsSource = lesMagazines;
        }
        private void LoadPigiste()
        {
            lesPigistes = bdd.SelectPigiste();
            dtgPigiste.ItemsSource = lesPigistes;
        }
        private void LoadContrat()
        {
            lesContrats = bdd.SelectContrat();
            dtgContrat.ItemsSource = lesContrats;
        }
        // Crée une liste de Magazine, de Pigiste et de Contrat dont le nombre n'est pas défini
        public MainWindow()
        {
            InitializeComponent();
            bdd.Initialize();
            LoadMagazine();
            LoadPigiste();
            LoadContrat();

            cboMagazine.ItemsSource = lesMagazines;
            cboPigiste.ItemsSource = lesPigistes;
            cboFiltreMagazine.ItemsSource = lesMagazines;
            cboFiltrePigiste.ItemsSource = lesPigistes;
        }

        private void dtgContrat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            

            if (dtgContrat.SelectedItem == null) return;
            Contrat selectedContrat = dtgContrat.SelectedItem as Contrat;

            try
            {
                //Remplissage des Textboxs avec les données de l'objet Contrat selectedContrat récupéré dans le Datagrid dtgContrat
                txtNumContrat.Text = Convert.ToString(selectedContrat.Num);
                txtLettreAccordContrat.Text = selectedContrat.LettreAccord;
                txtMontantBrutContrat.Text = Convert.ToString(selectedContrat.MontantBrut);
                txtMontantNetContrat.Text = Convert.ToString(selectedContrat.MontantNet);
                cboEtatContrat.SelectedIndex = selectedContrat.Etat;

                // Coche et décoche des 2 cases à cocher chkFacture et chkAgessa
                if (selectedContrat.Facture == true)
                { chkFacture.IsChecked = true; }
                else
                { chkFacture.IsChecked = false; }

                if (selectedContrat.DeclarationAgessa == true)
                { chkAgessa.IsChecked = true; }
                else
                { chkAgessa.IsChecked = false; }


                // Sélection du pigiste concerné dans la Combobox
                //cboPigiste.SelectedItem = selectedContrat.PigisteContrat;

                int i = 0;
                bool trouve = false;

                while (i < cboPigiste.Items.Count && trouve == false)
                {
                    if (Convert.ToString(cboPigiste.Items[i]) == Convert.ToString(selectedContrat.LePigiste))
                    {
                        trouve = true;
                        cboPigiste.SelectedIndex = i;

                    }
                    i++;
                }

                // Sélection du magazine concerné dans la Combobox
                //cboPigiste.SelectedItem = selectedContrat.PigisteContrat;

                i = 0;
                trouve = false;

                while (i < cboMagazine.Items.Count && trouve == false)
                {
                    if (Convert.ToString(cboMagazine.Items[i]) == Convert.ToString(selectedContrat.LeMagazine))
                    {
                        trouve = true;
                        cboMagazine.SelectedIndex = i;

                    }
                    i++;
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Erreur sur la mise à jour du formulaire lors du changement dans le Datagrid dtgContrat");
            }
        }

        private void dtgMagazine_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dtgMagazine.SelectedItem == null) return;
            Magazine selectedMagazine = dtgMagazine.SelectedItem as Magazine;

            try
            {
                //Remplissage des Textboxs avec les données de l'objet Magazine selectedMagazine récupéré dans le Datagrid dtgMagazine
                txtNumMagazine.Text = Convert.ToString(selectedMagazine.Num);
                dtpBouclageMagazine.Text = Convert.ToString(selectedMagazine.DateBouclage);
                dtpParutionMagazine.Text = Convert.ToString(selectedMagazine.DateParution);
                dtpPaiementMagazine.Text = Convert.ToString(selectedMagazine.DatePaiement);
                txtBudgetMagazine.Text = Convert.ToString(selectedMagazine.Budget);
            }
            catch (Exception)
            {
                Console.WriteLine("Erreur sur la mise à jour du formulaire lors du changement dans le Datagrid dtgMagazine");
            }
        }

        private void dtgPigiste_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dtgPigiste.SelectedItem == null) return;
            Pigiste selectedPigiste = dtgPigiste.SelectedItem as Pigiste;

            try
            {
                //Remplissage des Textboxs avec les données de l'objet Pigiste selectedPigiste récupéré dans le Datagrid dtgPigiste
                txtNumPigiste.Text = Convert.ToString(selectedPigiste.Num);
                txtNomPigiste.Text = Convert.ToString(selectedPigiste.Nom);
                txtPrenomPigiste.Text = Convert.ToString(selectedPigiste.Prenom);
                txtAdressePigiste.Text = Convert.ToString(selectedPigiste.Adresse);
                txtCPPigiste.Text = Convert.ToString(selectedPigiste.Cp);
                txtVillePigiste.Text = Convert.ToString(selectedPigiste.Ville);
                txtNumSecuPigiste.Text = Convert.ToString(selectedPigiste.NumSecu);
                txtMailPigiste.Text = Convert.ToString(selectedPigiste.Mail);
                txtContratCadrePigiste.Text = Convert.ToString(selectedPigiste.ContratCadre);
            }
            catch (Exception)
            {
                Console.WriteLine("Erreur sur la mise à jour du formulaire lors du changement dans le Datagrid dtgPigiste");
            }
        }

        private void btnAjouterMagazine_Click(object sender, RoutedEventArgs e)
        {
            bdd.InsertMagazine(dtpBouclageMagazine.Text,dtpPaiementMagazine.Text, dtpParutionMagazine.Text, Convert.ToDouble(txtBudgetMagazine.Text));
            LoadMagazine();
        }

        private void btnModifierMagazine_Click(object sender, RoutedEventArgs e)
        {
            bdd.UpdateMagazine(Convert.ToInt32(txtNumMagazine.Text),dtpBouclageMagazine.Text,dtpParutionMagazine.Text,dtpPaiementMagazine.Text,Convert.ToDouble(txtBudgetMagazine.Text));

            int index = lesMagazines.IndexOf((Magazine)dtgMagazine.SelectedItem);

            lesMagazines[index].DateBouclage = dtpBouclageMagazine.Text;
            lesMagazines[index].DateParution = dtpParutionMagazine.Text;
            lesMagazines[index].DatePaiement = dtpPaiementMagazine.Text;
            lesMagazines[index].Budget = Convert.ToInt32(txtBudgetMagazine.Text);
            LoadMagazine();
        }

        private void btnSupprimerMagazine_Click(object sender, RoutedEventArgs e)
        {
            bdd.DeleteMagazine(Convert.ToInt32(txtNumMagazine.Text));
            LoadMagazine();
        }

        private void btnAjouterPigiste_Click(object sender, RoutedEventArgs e)
        {
            bdd.InsertPigiste(txtNomPigiste.Text, txtPrenomPigiste.Text, txtAdressePigiste.Text, txtCPPigiste.Text, txtVillePigiste.Text, txtMailPigiste.Text, txtNumSecuPigiste.Text, txtContratCadrePigiste.Text);
            LoadPigiste();
        }

        private void btnModifierPigiste_Click(object sender, RoutedEventArgs e)
        {
            bdd.UpdatePigiste(Convert.ToInt32(txtNumPigiste.Text), txtNomPigiste.Text, txtPrenomPigiste.Text, txtAdressePigiste.Text,txtCPPigiste.Text,txtVillePigiste.Text,txtMailPigiste.Text,txtNumSecuPigiste.Text,txtContratCadrePigiste.Text);

            int index = lesPigistes.IndexOf((Pigiste)dtgPigiste.SelectedItem);

            lesPigistes[index].Num = Convert.ToInt32(txtNumPigiste.Text);
            lesPigistes[index].Nom = txtNomPigiste.Text;
            lesPigistes[index].Prenom = txtPrenomPigiste.Text;
            lesPigistes[index].Adresse =txtAdressePigiste.Text;
            lesPigistes[index].Cp = txtCPPigiste.Text;
            lesPigistes[index].Ville = txtVillePigiste.Text;
            lesPigistes[index].Mail = txtMailPigiste.Text;
            lesPigistes[index].NumSecu = txtNumSecuPigiste.Text;
            lesPigistes[index].ContratCadre = txtContratCadrePigiste.Text;
            LoadPigiste();
        }

        private void btnSupprimerPigiste_Click(object sender, RoutedEventArgs e)
        {
            bdd.DeletePigiste(Convert.ToInt32(txtNumPigiste.Text));
            LoadPigiste();
        }    

        private void btnAjouterContrat_Click(object sender, RoutedEventArgs e)
        {
            bool Facture;
            bool Agessa;
            if (Convert.ToBoolean(chkFacture.IsChecked))
            {
                Facture = true;
            }
            else
            {
                Facture = false;
            }
            if (Convert.ToBoolean(chkAgessa.IsChecked))
            {
                Agessa = true;
            }
            else
            {
                Agessa = false;
            }

            Pigiste modifpigiste = cboPigiste.SelectedItem as Pigiste;
            Magazine modifmagazine = cboMagazine.SelectedItem as Magazine;

            bdd.InsertContrat(txtLettreAccordContrat.Text,Convert.ToDouble(txtMontantBrutContrat.Text),Convert.ToDouble(txtMontantNetContrat.Text),Convert.ToInt32(cboEtatContrat.SelectedIndex), Facture, Agessa, modifpigiste,modifmagazine);
            LoadContrat();
        }

        private void btnModifierContrat_Click(object sender, RoutedEventArgs e)
        {
            bool Facture;
            bool Agessa;
            if (Convert.ToBoolean(chkFacture.IsChecked))
            {
                Facture = true;
            }
            else
            {
                Facture = false;
            }
            if (Convert.ToBoolean(chkAgessa.IsChecked))
            {
                Agessa = true;
            }
            else
            {
                Agessa = false;
            }

            Pigiste modifpigiste = cboPigiste.SelectedItem as Pigiste;
            Magazine modifmagazine = cboMagazine.SelectedItem as Magazine;
            bdd.UpdateContrat(Convert.ToInt32(txtNumContrat.Text),txtLettreAccordContrat.Text, Convert.ToDouble(txtMontantBrutContrat.Text), Convert.ToDouble(txtMontantNetContrat.Text), Convert.ToInt32(cboEtatContrat.SelectedIndex), Facture, Agessa, modifpigiste.Num, modifmagazine.Num);
            LoadContrat();
        }

        private void btnSupprimerContrat_Click(object sender, RoutedEventArgs e)
        {    
            bdd.DeleteContrat(Convert.ToInt32(txtNumContrat.Text));
            LoadContrat();
        }

        private void cboFiltreMagazine_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBoxMagazine = sender as ComboBox;
            Magazine selectedMagazine = comboBoxMagazine.SelectedItem as Magazine;
            filtreMagazine.Add(bdd.SearchMagazine(Convert.ToInt32(selectedMagazine.Num)));
            dtgContrat.ItemsSource = filtreMagazine;
        }

        private void cboFiltrePigiste_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBoxPigiste = sender as ComboBox;
            Pigiste selectedPigiste = comboBoxPigiste.SelectedItem as Pigiste;
            filtrePigiste.Add(bdd.SearchPigiste(Convert.ToInt32(selectedPigiste.Num)));
            dtgContrat.ItemsSource = filtrePigiste;
        }
    }
}
