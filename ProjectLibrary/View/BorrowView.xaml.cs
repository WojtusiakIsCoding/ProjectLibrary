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
using System.Collections.ObjectModel;

namespace ProjectLibrary.View
{
    /// <summary>
    /// Logika interakcji dla klasy BorrowView.xaml
    /// </summary>
    public partial class BorrowView : Page
    {
        
        public BorrowView(User user)
        {
            InitializeComponent();
            Name.Text = user.Name;
            Surname.Text = user.Surname;
            List.ItemsSource = Collections.BooksList;
            LoggedUser = user;
        }
        public User LoggedUser;
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Serializer.Serialize(Collections.UsersList, "Users.json");
            var exitToMenu = new LoginView();
            this.NavigationService.Navigate(exitToMenu);
            Collections.pages.Clear();
        }


        private void Summary_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(Collections.pages[0]);
        }

       

        private void Borrow_Click(object sender, RoutedEventArgs e)
        {
            var item = (Item)List.SelectedItem;
            if (item !=null &&item.Quantity>0) {
               
                var index = Collections.UsersList.IndexOf(LoggedUser);
                Collections.UsersList[index].itemlist.Add(new Item { 
                    Author = item.Author, Title=item.Title, Group = item.Group, Year = item.Year, ReleaseNumber = item.ReleaseNumber});
                if (item.Group == GroupType.book) 
                {
                    Collections.BooksList[Collections.BooksList.IndexOf((Book)item)].Quantity--;
                }
                else if(item.Group == GroupType.magazine) 
                { Collections.MagazinesList[Collections.MagazinesList.IndexOf((Magazine)item)].Quantity--; }
                else if(item.Group == GroupType.movie)
                { Collections.MoviesList[Collections.MoviesList.IndexOf((Movie)item)].Quantity--; }
                else if(item.Group == GroupType.scientific) 
                { Collections.ScientificsList[Collections.ScientificsList.IndexOf((ScientificPub)item)].Quantity--; }
            }
        }

        private void Book_Click(object sender, RoutedEventArgs e)
        {
            List.ItemsSource = Collections.BooksList;
        }

        private void Magazine_Click(object sender, RoutedEventArgs e)
        {
            List.ItemsSource = Collections.MagazinesList;
        }

        private void Movie_Click(object sender, RoutedEventArgs e)
        {
            List.ItemsSource = Collections.MoviesList;
        }

        private void Scientific_Click(object sender, RoutedEventArgs e)
        {
            List.ItemsSource = Collections.ScientificsList;
        }
    }
}
