using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ProjectLibrary.Model
{
    public class Item:INotifyPropertyChanged
    {   private string _title;
        private string _author;
        private int _quantity;
        private int _year;
        private GroupType _group;
        private Nullable<int> _releaseNumber;
        public string Title { get { return _title; } set {
                if (_title != value)
                {
                    _title = value;
                    NotifyPropertyChanged(nameof(Title));

                }
            } }
        public string Author
        {
            get { return _author; }
            set
            {
                if (_author != value)
                {
                    _author = value;
                    NotifyPropertyChanged(nameof(Author));

                }
            }
        }
        public int Quantity
        {
            get { return _quantity; }
            set
            {
                if (_quantity != value)
                {
                    _quantity = value;
                    NotifyPropertyChanged(nameof(Quantity));

                }
            }
        }
        public int Year
        {
            get { return _year; }
            set {
                if (_year != value)
                {
                    _year = value;
                    NotifyPropertyChanged(nameof(Year));

                }
            }
        }
        
        public Nullable<int> ReleaseNumber
        {
            get { return _releaseNumber; }
            set
            {
                if (_releaseNumber != value)
                {
                    _releaseNumber = value;
                    NotifyPropertyChanged(nameof(ReleaseNumber));

                }
            }
        }
        public Guid Id { get { return Guid.NewGuid();  } }
        public GroupType Group
        {
            get { return _group; }
            set
            {
                if (_group != value)
                {
                    _group = value;
                    NotifyPropertyChanged(nameof(Title));

                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        public override string ToString()
        {
            return this.Title;
        }
        


    }
    public enum GroupType
    {
        book,
        magazine,
        movie,
        scientific
    }

}