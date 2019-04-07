using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ex_5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<BankAccount> accountList = new ObservableCollection<BankAccount>();

        public MainWindow()
        {
            InitializeComponent();

            //Create BankAccount objects
            BankAccount ba1 = new BankAccount("123456", "Shane C", 2000m);
            BankAccount ba2 = new BankAccount("987654", "Catriona K", 4000m);

            //Create Savings objects
            SavingsAccount save1 = new SavingsAccount("159753", "Robyn F", 1000m);
            SavingsAccount save2 = new SavingsAccount("456123", "Ava F", 500m);

            

            //Add objects to the list
            accountList.Add(ba1);
            accountList.Add(ba2);
            

            accountList.Add(save1);
            accountList.Add(save2);
            


            //Display objects in list
            lbxBankAccounts.ItemsSource = accountList;

            //Display selected account
            
            BankAccount selectedAccount = lbxBankAccounts.SelectedItem as BankAccount;
            if (selectedAccount == null)
            {
                
                tbkListDetails.Text = "";
            }
            else
            {
                string displayAccount = selectedAccount.ToString();
                tbkListDetails.Text = string.Format(displayAccount);
            }

        }

        //private void TbkListDetails_Displaydetails(object sender, ContextMenuEventArgs e)
        //{
        //    BankAccount selectedAccount = lbxBankAccounts.SelectedItem as BankAccount;

        //    string displayAccount = selectedAccount.ToString();
        //    tbkListDetails.Text = string.Format(displayAccount);
        //}

        private void WriteToFile(ObservableCollection<BankAccount> listOfAccounts)
        {
            string[] accounts = new string[listOfAccounts.Count];
            BankAccount ba;

            for (int i = 0; i < listOfAccounts.Count; i++)
            {
                ba = listOfAccounts.ElementAt(i);
                accounts[i] = ba.FileFormat();
            }
            File.WriteAllLines(@"H:\accounts.txt", accounts);
        }

       

        private void btnSaveAccounts_Click(object sender, RoutedEventArgs e)
        {
            WriteToFile(accountList);
        }

        private void LbxBankAccounts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
               BankAccount SelectedAccount = lbxBankAccounts.SelectedItem as BankAccount;
            if (SelectedAccount is SavingsAccount)
            {
                SavingsAccount SelectedSaveAccount = SelectedAccount as SavingsAccount;
                tbkListDetails.Text = String.Format("Name:{0} \n Account Numebr:{1} \n Amount:{2} ", SelectedSaveAccount.AccountNumber, SelectedSaveAccount.AccountOwner, SelectedSaveAccount.Total);
            }
            else
            {
                tbkListDetails.Text = String.Format("Account Number: {0} \n Name:{1} \n Amount:{2}", SelectedAccount.AccountNumber, SelectedAccount.AccountOwner, SelectedAccount.Total);
            }
                        
            
           
        }

        private void BtnAddInterest_Click(object sender, RoutedEventArgs e)
        {
            SavingsAccount SelectedSaveAccount = lbxBankAccounts.SelectedItem as SavingsAccount;
            SelectedSaveAccount.Total = SelectedSaveAccount.AddInterest();
        }

        private void BtnWithdraw_Click(object sender, RoutedEventArgs e)
        {
            BankAccount selectedAccount = lbxBankAccounts.SelectedItem as BankAccount;
            string withdrawal = txBxAmount.ToString();
            decimal withdrawAmount = decimal.Parse(withdrawal);
            selectedAccount.Total = selectedAccount.Total - withdrawAmount;
        }
    }
}
