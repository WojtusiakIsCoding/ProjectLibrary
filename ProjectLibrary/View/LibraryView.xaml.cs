using ProjectLibrary.Model;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;

namespace ProjectLibrary.View
{
    /// <summary>
    /// Logika interakcji dla klasy LibraryView.xaml
    /// </summary>
    public partial class LibraryView : Page
    {
       
        public LibraryView(User user)
        {
            InitializeComponent();
            Name.Text = user.Name;
            Surname.Text =user.Surname;
            BorrowedList.ItemsSource = Collections.UsersList[Collections.UsersList.IndexOf(user)].itemlist;
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

        private void Borrow_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(Collections.pages[1]);
        }

        public void Return_Click(object sender, RoutedEventArgs e)
        {
           var item = (Item) BorrowedList.SelectedItem;
           if(item !=null ){ 
            
            switch (item.Group)
            {
                case GroupType.book:
                    {
                        foreach (var element in Collections.BooksList)
                        {
                            if (element.Title == item.Title)
                            {
                                var index = Collections.BooksList.IndexOf(element);
                                Collections.BooksList[index].Quantity++;
                                    // Finding element by item.ID(GUID) not working

                                }
                            }


                        
                        Collections.UsersList[Collections.UsersList.IndexOf(LoggedUser)].itemlist.Remove(item);
                        break;
                    }
                case GroupType.magazine:
                    {
                            foreach (var element in Collections.MagazinesList)
                            {
                                if (element.Title == item.Title)
                                {
                                    var index = Collections.MagazinesList.IndexOf(element);
                                    Collections.MagazinesList[index].Quantity++;

                                }
                            }
                            Collections.UsersList[Collections.UsersList.IndexOf(LoggedUser)].itemlist.Remove(item);
                        break;
                    }
                case GroupType.movie:
                    {
                            foreach (var element in Collections.MoviesList)
                            {
                                if (element.Title == item.Title)
                                {
                                    var index = Collections.MoviesList.IndexOf(element);
                                    Collections.MoviesList[index].Quantity++;

                                }
                            }
                            Collections.UsersList[Collections.UsersList.IndexOf(LoggedUser)].itemlist.Remove(item);
                        break;
                    }
                case GroupType.scientific:
                    {
                            foreach (var element in Collections.ScientificsList)
                            {
                                if (element.Title == item.Title)
                                {
                                    var index = Collections.ScientificsList.IndexOf(element);
                                    Collections.ScientificsList[index].Quantity++;

                                }
                            }
                            Collections.UsersList[Collections.UsersList.IndexOf(LoggedUser)].itemlist.Remove(item);
                        break;
                    }
            }
            }
        }
    }
}
