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

namespace Ex_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Employee> hospitalStalffList = new ObservableCollection<Employee>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnGetEmployees_Click(object sender, RoutedEventArgs e)
        {
            //Create employee objects
            //Employee emp1 = new Employee("Tom", "123 MeadowLane", "071 91 1234567");
            //Employee emp2 = new Employee("Sally", "5a Seaview", "086 0101555");
            //Employee emp3 = new Employee("Jo", "Ash Lane", "085 1234567");

            //Create nurse objects
            Nurse nurse1 = new Nurse("Mary", "Hospital road", "071 91 777 6666", 1, "Paediatrics");
            Nurse nurse2 = new Nurse("Sue", "Hospital road", "071 91 777 8888", 2, "Casualty");

            //Create doctor objects
            Doctor doc1 = new Doctor("George", "Calry", "071 91 66554433", PositionType.Junior);
            Doctor doc2 = new Doctor("Alison", "John Street", "071 91 55 222", PositionType.Senior);

            //Add objects to the list
            //hospitalStalffList.Add(emp1);
            //hospitalStalffList.Add(emp2);
            //hospitalStalffList.Add(emp3);

            hospitalStalffList.Add(nurse1);
            hospitalStalffList.Add(nurse2);

            hospitalStalffList.Add(doc1);
            hospitalStalffList.Add(doc2);


            //Display objects in list
            lbxEmployees.ItemsSource = hospitalStalffList;
        }

        private void WriteToFile(ObservableCollection<Employee> staff)
        {
            string[] employees = new string[staff.Count];
            Employee e;

            for (int i = 0; i < staff.Count; i++)
            {
                e = staff.ElementAt(i);
                employees[i] = e.FileFormat();
            }
            File.WriteAllLines(@"H:\Employees.txt", employees);
        }

        private void BtnSaveEmployees_Click(object sender, RoutedEventArgs e)
        {
            WriteToFile(hospitalStalffList);
        }

        private void BtnGetType_Click(object sender, RoutedEventArgs e)
        {
            int employees = 0, doctors = 0, nurses = 0;
            foreach (Employee emp in hospitalStalffList)
            {
                //Method One

                //if (emp is Nurse)
                //    nurses++;
                //else if (emp is Doctor)
                //    doctors++;
                //else if (emp is Employee)
                //    employees++;

                //Method Two
                //if (emp as Nurse != null)
                //    nurses++;
                //else if (emp as Doctor != null)
                //    doctors++;
                //else if (emp as Employee != null)
                //    employees++;

                //Method Three
                Type type = emp.GetType();
                if (type.Name == "Employee")
                    employees++;
                else if (type.Name == "Nurse")
                    nurses++;
                else if (type.Name == "Doctor")
                    doctors++;
            }
            string message = string.Format($"Employees: {employees} Doctors: {doctors} Nurses: {nurses}");
            MessageBox.Show(message);
        }

        private void BtnGetPay_Click(object sender, RoutedEventArgs e)
        {
            //determine what was selected
            Employee selectedEmployee = lbxEmployees.SelectedItem as Employee;

            if(selectedEmployee != null)
            {
                //calculate oay using GetMOnthlyPay
                decimal pay = selectedEmployee.GetMonthlySalary();

                //Get Type
                Type type = selectedEmployee.GetType(); //Includes namespace in name
                string typeName = type.Name; //Just gives the class name

                //Show Message
                MessageBox.Show(string.Format($"Monthly pay of selected {typeName} is {pay:C}"));
            }
            else
            {
                MessageBox.Show("Nothing was selected");
            }

        }
    }
}
