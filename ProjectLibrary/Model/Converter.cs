using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;


namespace ProjectLibrary.Model
{

    public static class Converter
    {
        public static void ConvertToChild(ObservableCollection <Item> itemsList)
        {

            foreach(Item item in itemsList)
            {
                if(item.Group == GroupType.book)
                {

                    Collections.BooksList.Add(new Book() { Title = item.Title,
                    Author = item.Author,
                    ReleaseNumber = item.ReleaseNumber,
                    Year = item.Year,
                    Quantity = item.Quantity});

                }else if(item.Group == GroupType.magazine)
                {  Collections.MagazinesList.Add(new Magazine()
                {
                    Title = item.Title,
                    Author = item.Author,
                    ReleaseNumber = item.ReleaseNumber,
                    Year = item.Year,
                    Quantity = item.Quantity
                });

                }
                else if(item.Group == GroupType.movie)
                {  
                    Collections.MoviesList.Add(new Movie()
                    {
                        Title = item.Title,
                        Author = item.Author,
                        ReleaseNumber = item.ReleaseNumber,
                        Year = item.Year,
                        Quantity = item.Quantity
                    }); ;
                }else if(item.Group == GroupType.scientific)
                {
                    Collections.ScientificsList.Add(new ScientificPub()
                    {
                        Title = item.Title,
                        Author = item.Author,
                        ReleaseNumber = item.ReleaseNumber,
                        Year = item.Year,
                        Quantity = item.Quantity
                    }); 
                }
                else
                {
                    throw new InvalidOperationException();
                    
                }
            }
            
        }
    }
}
