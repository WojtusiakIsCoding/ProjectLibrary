using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Controls;

namespace ProjectLibrary.Model
{
    public static class Collections
    {
        public static ObservableCollection<Item> ItemsList = new ObservableCollection<Item>();
        public static ObservableCollection<User> UsersList = new ObservableCollection<User>();
        public static ObservableCollection<Book> BooksList = new ObservableCollection<Book>();
          
        public static ObservableCollection<Magazine> MagazinesList = new ObservableCollection<Magazine>();
        public static ObservableCollection<Movie> MoviesList = new ObservableCollection<Movie>();
        public static ObservableCollection<ScientificPub> ScientificsList = new ObservableCollection<ScientificPub>();
        public static List<Page> pages = new List<Page>();
       

    }
}
