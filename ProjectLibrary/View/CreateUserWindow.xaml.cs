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
using System.Windows.Shapes;
using ProjectLibrary.Model;

namespace ProjectLibrary.View
{
    /// <summary>
    /// Logika interakcji dla klasy CreateUserWindow.xaml
    /// </summary>
    public partial class CreateUserWindow : Window
    {
        public CreateUserWindow()
        {
            InitializeComponent();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Collections.UsersList.Add(new User { Name = NameBox.Text, Surname =SurnameBox.Text, Login =LoginBox.Text});
            this.Close();
        }
    }
}
