using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Desktop01.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Desktop01
{
    public  partial class MainWindowVM : ObservableObject
    {
        [ObservableProperty]
        public  ObservableCollection<User> users;
        [ObservableProperty]
        public User selectedUser=null;

        [ObservableProperty]
        public ObservableCollection<User2> users2;
        [ObservableProperty]
        public User2 selectedUser2 = null;

        public void CloseMainWindow()
        {
            Application.Current.MainWindow.Close();
        }




        [RelayCommand]
        public void messeag()
        {

            MessageBox.Show($"{selectedUser.FirstName} GPA VALUE MUST BE BETWEEN 0 AND 4.", "ERROR");
        }

        [RelayCommand]
        public void AddStudent()
        {
            var vm = new AddUserVM();
            vm.title = "ADD USER";
            AddUserWindow window = new AddUserWindow(vm);
            window.ShowDialog();

         

                if (vm.Student != null && !string.IsNullOrEmpty(vm.Student.FirstName))
                {
                    users.Add(vm.Student);
                }
        }

        [RelayCommand]
        public void Delete()
        {
            if (selectedUser != null)
            {
                string name = selectedUser.FirstName;
                users.Remove(selectedUser);
                MessageBox.Show($"{name} is deleted successfully.", "DELETED \a ");
                
            }
            else
            {
                MessageBox.Show("PLEASE SELECT A STUDENT TO DELETE.", "ERROR");


            }
        }
        [RelayCommand]
        public void ExecuteEditStudentCommand()
        {
            if (selectedUser != null)
            {
                var vm = new AddUserVM(selectedUser);
                vm.title = "EDIT USER";

               
                var window = new AddUserWindow(vm);
                

                window.ShowDialog();


                int index = users.IndexOf(selectedUser);
                users.RemoveAt(index);
                users.Insert(index, vm.Student);



            }
            else
            {
                MessageBox.Show("PLEASE SELECT A STUDENT", "WARNING!");
            }
        }
            
        public  MainWindowVM()
        {
            users = new ObservableCollection<User>();
            BitmapImage image1 = new BitmapImage(new Uri("/Model/Images/1.png", UriKind.Relative));
            users.Add(new User(24, "Nirasha", "Morais", "23/09/1999",image1,"Computer","Dr.Chathura",3.2));
            BitmapImage image2 = new BitmapImage(new Uri("/Model/Images/2.png", UriKind.Relative));
            users.Add(new User(24, " Mahesha", "Morais", "23/09/1999",image2,"Civil","Dr. Kashyapa",3.4));
            BitmapImage image3 = new BitmapImage(new Uri("/Model/Images/3.png", UriKind.Relative));
            users.Add(new User(26, "Praveen", "Shyamal", "22/12/1997", image3, "Electrical"," Prof.Liam",2.8));
            BitmapImage image4= new BitmapImage(new Uri("/Model/Images/4.png", UriKind.Relative));
            users.Add(new User(23, "Shihan", "Adrian", "18/2/2000 ", image4, "Mechanical","Dr.Shone",3.64));
            BitmapImage image5 = new BitmapImage(new Uri("/Model/Images/4.png", UriKind.Relative));
            users.Add(new User(23, "Diluk", "Sahan", "28/5/2000", image5, "Electrical", "Dr.Sampath", 3.81));
            BitmapImage image6 = new BitmapImage(new Uri("/Model/Images/5.png", UriKind.Relative));
            users.Add(new User(26, "Shakila", "Anthony", "18/1/1997", image6, "Marine", "Dr.Kaushalya", 3.45));
            BitmapImage image7 = new BitmapImage(new Uri("/Model/Images/6.png", UriKind.Relative));
            users.Add(new User(23, "Shaveena", "Miriam", "16/7/2000", image7, "Civil", "Prof.Thiran", 3.33));
            BitmapImage image8 = new BitmapImage(new Uri("/Model/Images/7.png", UriKind.Relative));
            users.Add(new User(24, "Shaveena", "Miriam", "13/3/1999", image8, "Computer", "Dr.Kalupahana", 3.79));

        }
        [RelayCommand]
        public void AddInfo()
        {
            var vm = new MainWindow2VM();
            vm.title2 = "MORE INFORMATION";
            MainWindow2 window = new MainWindow2(vm);
            window.ShowDialog();

            if (vm.Student2 != null && vm.Student2.Nationality != null)
            {
                users2.Add(vm.Student2);
            }
        }

    }
}
