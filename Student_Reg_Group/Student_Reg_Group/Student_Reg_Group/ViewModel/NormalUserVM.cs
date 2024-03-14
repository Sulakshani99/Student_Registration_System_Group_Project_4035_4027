using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Student_Reg_Group.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Media;

namespace Student_Reg_Group.ViewModel
{
    public partial class NormalUserVM: ObservableObject
    {
        [ObservableProperty]
        public string firstName;
        [ObservableProperty]
        public string lastName;
        [ObservableProperty]
        public int age;
        [ObservableProperty]
        public int id;
        [ObservableProperty]
        public double gpa;

        [ObservableProperty]
        public string normalusername;
        [ObservableProperty]
        public int normaluserpassword;
        [ObservableProperty]
        public int normaluserid;
        public UserType usertype;
        [ObservableProperty]

        
        ObservableCollection<NormalUser> normalusers;


        public string NormalUsername { get; set; }
        public int NormalUserPassword { get; set; }
        public UserType Usertype { get; set; }
        // public int NormalUserId { get; set; }
        /*
        public string NormalUsername
        {
            get { return normalusername; }
            set { normalusername = value; }
        }
        public int NormalUserPassword
        {
            get { return normaluserpassword; }
            set { normaluserpassword = value; }
        }
        public int NormalUserId
        {
            get { return normaluserid; }
            set { normaluserid = value; }
        }
        public UserType UserType
        {
            get { return usertype; }
            set { usertype = value; }
        }

        */
        public void ShowCustomMessageBox(string message)
        {
            var messageBox = new Window()
            {
                WindowStyle = WindowStyle.None,
                ResizeMode = ResizeMode.NoResize,
                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#545d6a")),
                Foreground = Brushes.White,
                Width = 300,
                Height = 150,
                Topmost = true,
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };

            var contentStackPanel = new StackPanel();

            var messageTextBlock = new TextBlock()
            {
                Text = message,
                FontSize = 16,
                Padding = new Thickness(20),
                TextWrapping = TextWrapping.Wrap,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            var closeButton = new Button()
            {
                Content = "Close",
                Width = 80,
                Height = 30,
                Margin = new Thickness(10),
                Background = Brushes.LightGray,
                Foreground = Brushes.Black
            };

            closeButton.Click += (sender, e) =>
            {
                messageBox.Close();
            };

            contentStackPanel.Children.Add(messageTextBlock);
            contentStackPanel.Children.Add(closeButton);

            messageBox.Content = contentStackPanel;

            messageBox.Show();
        }





        [RelayCommand]
        public void InsertNormalUser()
        {
            NormalUser n = new NormalUser()
            {
                NormalUsername = NormalUsername,
                NormalUserPassword = NormalUserPassword,
                //UserType = UserType
            };
            using (var db = new NormalUserContext())
            {
                db.NormalUsers.Add(n);
                db.SaveChanges();
                //MessageBox.Show($"Added");
                ShowCustomMessageBox("User name and Password added to the database successfully!");
            }

        }

        [RelayCommand]
        public void LoginNormal()
        {
            using (var dbContext = new NormalUserContext())
            {
                var n = dbContext.NormalUsers.FirstOrDefault(a => a.NormalUsername == NormalUsername);

                if (n != null)
                {
                    
                        // Verify the password against the stored password

                        if (VerifyPassword(n.NormalUserPassword, NormalUserPassword))
                        {
                            // Password is correct, perform the login action
                            // You can navigate to the appropriate view here

                            NormalUserWindow NormalUserWindow = new NormalUserWindow();
                            NormalUserWindow.Show();
                        }
                        else
                        {
                        // Incorrect password, show error message
                        // MessageBox.Show($"Error2");
                        ShowCustomMessageBox("Incorrect Password!");
                    }
                
                }
                
                else
                {
                    // User not found, show error message
                    // MessageBox.Show($"Error1");
                    ShowCustomMessageBox("Error");
                }


            }
        }


        private bool VerifyPassword(int storedPassword, int enteredPassword)
        {

            return storedPassword == enteredPassword;
        }




        [ObservableProperty]
        ObservableCollection<Person> persons;

        public Person? SelectedPerson { get; set; }

        [RelayCommand]
        public void InsertPerson()
        {
            Person p = new Person()
            {
                FirstName = FirstName,
                LastName = LastName,
                Age = Age,
                Id=Id,
                Gpa=Gpa
            };
            using (var db = new PersonContext())
            {
                db.Persons.Add(p);
                db.SaveChanges();
            }
            LoadPerson();

            // Clear the properties
            Id = 0;
            FirstName = string.Empty;
            LastName = string.Empty;
            Gpa = 0;

             ShowCustomMessageBox("Student added successfully!");


        }


        [RelayCommand]
        public void DeletePerson()
        {
            if (SelectedPerson != null)
            {
                using (var db = new PersonContext())
                {
                    db.Persons.Remove(SelectedPerson);
                    db.SaveChanges();
                }
                LoadPerson();
            }
            else
            {
                // MessageBox.Show("Please select a person to delete.", "Delete Person", MessageBoxButton.OK, MessageBoxImage.Warning);
                ShowCustomMessageBox("Please select a person to delete");
            }
        }


        /*
        
        [RelayCommand]
        public void EditPerson()
        {
            if (SelectedPerson == null)
            {
                MessageBox.Show("Please select a person to update.");
                return;
            }
            using (var db = new PersonContext())
            {

                //var selectedPerson = db.Persons.FirstOrDefault(p => p.Id == SelectedPerson.Id);

                if (SelectedPerson != null)
                {
                    InsertPerson();

                    SelectedPerson.FirstName = FirstName;  
                    LastName= SelectedPerson.LastName;
                    Id = SelectedPerson.Id;
                    Age = SelectedPerson.Age;
                    Gpa = SelectedPerson.Gpa;
                        



                    db.Persons.Add(SelectedPerson);

                    db.SaveChanges();
                    //Id = 0;
                    FirstName = "";
                    LastName = "";
                    Id= 0;
                    Age = 0;
                    Gpa= 0;



                    LoadPerson();
                }
                else
                {
                    MessageBox.Show("Selected person not found in database.");
                }
            }
        }

        */


        public Person GetPersonById(int id)
        {
            using (var db = new PersonContext())
            {
                return db.Persons.FirstOrDefault(p => p.Id == id);
            }
        }
        [RelayCommand]
        private void ReadPerson()
        {
            if (id == 0)
            {
                //MessageBox.Show("Please enter a valid ID.");
                ShowCustomMessageBox("Please enter a valid ID");
                return;
            }

            Person person = GetPersonById(id);

            if (person != null)
            {
                //MessageBox.Show($"Id: {person.Id}\nPerson_Name: {person.FirstName}");
                ShowCustomMessageBox($"Id: {person.Id}\nPerson_Name: {person.FirstName}");
            }
            else
            {
                //MessageBox.Show("Person not found.");
                ShowCustomMessageBox("Person not found");
            }
        }




        public void LoadPerson()
        {
            using (var db = new PersonContext())
            {
                var list = db.Persons.ToList();
                Persons = new ObservableCollection<Person>(list);
            }
        }
        public NormalUserVM()
        {
            LoadPerson();
        }
    }

    



}

