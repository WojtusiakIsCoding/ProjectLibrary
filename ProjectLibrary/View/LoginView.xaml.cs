using ProjectLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;
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

namespace ProjectLibrary.View
{
    /// <summary>
    /// Logika interakcji dla klasy LoginView.xaml
    /// </summary>
    public partial class LoginView : Page
    {
        public LoginView()
        {
            InitializeComponent();
            
            UsersList.ItemsSource = Collections.UsersList;
        }

        private void exit_button_Click(object sender, RoutedEventArgs e)
        {
            Serializer.Serialize(Collections.ItemsList, "Items.json");
            Serializer.Serialize(Collections.UsersList, "Users.json");
            Window window = Window.GetWindow(this);
            window.Close();
        }

        private void login_button_Click(object sender, RoutedEventArgs e)

        {    
            var user = (User)UsersList.SelectedItem;
            if (user.Login != "Admin" && user !=null)
            {
                LibraryView libraryView = new LibraryView(user);
                BorrowView borrowView = new BorrowView(user);
                Collections.pages.Add(libraryView);
                Collections.pages.Add(borrowView);
                
               

                this.NavigationService.Navigate(libraryView);
            }
            else
            {   AdminPanelView panel = new AdminPanelView();
                this.NavigationService.Navigate(panel);
                
            }
     


        }

        private void create_user_Click(object sender, RoutedEventArgs e)
        {
            Window window = new CreateUserWindow();
            window.Show();
        }
    }
}
