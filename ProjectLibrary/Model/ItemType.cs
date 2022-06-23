using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectLibrary.Model
{
    public class Book:Item
    {
       public Book()
        {
            Group = GroupType.book;
            
           
            
        }
        
    }
    public class Magazine : Item
    {
       
        public Magazine()
        {
            Group = GroupType.magazine;
           
            
        }
       
    }
    public class Movie : Item
    {
        public Movie()
        {
            Group = GroupType.movie;
            
           
        }
        
    }
    public class ScientificPub: Item
    {
       
        public ScientificPub()
        {

            Group = GroupType.scientific;
            
        }

        
    }
}
