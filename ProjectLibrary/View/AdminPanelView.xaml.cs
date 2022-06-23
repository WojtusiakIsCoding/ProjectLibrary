using ProjectLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Linq;

namespace ProjectLibrary.View
{
    /// <summary>
    /// Logika interakcji dla klasy AdminPanelView.xaml
    /// </summary>
    public partial class AdminPanelView : Page
    {
        public AdminPanelView()
        {
            InitializeComponent();
            Listbox.ItemsSource = Collections.ItemsList;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void All_Click(object sender, RoutedEventArgs e)
        {
            Listbox.ItemsSource = Collections.ItemsList;
        }

        private void Books_Click(object sender, RoutedEventArgs e)
        {
            Listbox.ItemsSource = Collections.BooksList;
        }

        private void Magazines_Click(object sender, RoutedEventArgs e)
        {
            Listbox.ItemsSource= Collections.MagazinesList;
        }

        private void Movies_Click(object sender, RoutedEventArgs e)
        {
            Listbox.ItemsSource = Collections.MoviesList;
        }

        private void Scientifics_Click(object sender, RoutedEventArgs e)
        {
            Listbox.ItemsSource = Collections.ScientificsList;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if(Author.Text != "" && Title.Text !="" && Year.Text != "" && Quantity.Text !="" && Edition.Text !="")
            {
                if(Book.IsChecked == true)
                {
                    Collections.BooksList.Add(new Book
                    {
                        Title = Title.Text,
                        Author = Author.Text,
                        Year = int.Parse(Year.Text),
                        ReleaseNumber = int.Parse(Edition.Text),
                        Quantity = int.Parse(Quantity.Text)
                    });
                    Collections.ItemsList.Add(Collections.BooksList.Last());
                    Clear_Textbox();
                }else if(Magazine.IsChecked == true)
                {
                    Collections.MagazinesList.Add(new Magazine
                    {
                        Title = Title.Text,
                        Author = Author.Text,
                        Year = int.Parse(Year.Text),
                        ReleaseNumber = int.Parse(Edition.Text),
                        Quantity = int.Parse(Quantity.Text)
                    });
                    Clear_Textbox();
                    Collections.ItemsList.Add(Collections.MagazinesList.Last());
                }
                else if(Movie.IsChecked == true)
                {
                    Collections.MoviesList.Add(new Movie
                    {
                        Title = Title.Text,
                        Author = Author.Text,
                        Year = int.Parse(Year.Text),
                        ReleaseNumber = int.Parse(Edition.Text),
                        Quantity = int.Parse(Quantity.Text)
                    }) ;
                    Clear_Textbox();
                    Collections.ItemsList.Add(Collections.MoviesList.Last());
                }
                else if(Scientific.IsChecked == true)
                {
                    Collections.ScientificsList.Add(new ScientificPub
                    {
                        Title = Title.Text,
                        Author = Author.Text,
                        Year = int.Parse(Year.Text),
                        ReleaseNumber = int.Parse(Edition.Text),
                        Quantity = int.Parse(Quantity.Text)
                    });
                    Clear_Textbox();
                    Collections.ItemsList.Add(Collections.ScientificsList.Last());

                }
            }
            else
            {
                _ = MessageBox.Show("Nie wpisano wszystkich niezbędnych danych");
            }
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void Clear_Textbox()
        {
            Title.Clear();
            Author.Clear();
            Edition.Clear();
            Quantity.Clear();
            Year.Clear();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var item = (Item)Listbox.SelectedItem;
            if(item != null)
            {
                Collections.ItemsList.Remove(item);
                if(item.Group == GroupType.book)
                {
                    Collections.BooksList.Remove((Book)this.Listbox.SelectedItem);
                
                
                    
                }else if(item.Group == GroupType.magazine)
                {
                    Collections.MagazinesList.Remove((Magazine)this.Listbox.SelectedItem);
                }
                else if(item.Group == GroupType.movie)
                {
                    Collections.MoviesList.Remove((Movie)this.Listbox.SelectedItem);
                }
                else if(item.Group == GroupType.scientific)
                {
                    Collections.ScientificsList.Remove((ScientificPub)this.Listbox.SelectedItem);
                }
            }
            
        }
    }
}
