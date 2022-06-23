using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace ProjectLibrary.Model
{
    public class User:INotifyPropertyChanged
    {
        private string _name;
        private string _surname;
        public string Name { get { return _name; } set {
                if (_name != value)
                {
                    _name = value;
                    NotifyPropertyChanged(nameof(Name));

                }
            } 
        }
        public string Surname { get { return _surname; } set {
                if (_surname != value)
                {
                    _surname = value;
                    NotifyPropertyChanged(nameof(Surname));

                }
            } }
        public string Login { get; set; }
        public Guid ID { get { return Guid.NewGuid(); } }
        public ObservableCollection<Item> itemlist = new ObservableCollection<Item>();
       
       

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
