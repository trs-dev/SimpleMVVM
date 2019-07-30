using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ReactiveUI_MVVM.Models
{
    public class Person : INotifyPropertyChanged
    {
        private string _FirstName;
        public string FirstName
        {
            get { return _FirstName; }
            set
            {
                if (value == _FirstName) return;
                _FirstName = value;
                OnPropertyChanged();
                OnPropertyChanged("FullName");
            }
        }

        private string _LastName;
        public string LastName
        {
            get { return _LastName; }
            set
            {
                if (value == _LastName) return;
                _LastName = value;
                OnPropertyChanged();
                OnPropertyChanged("FullName");
            }
        }


        public Person(string FirstName, string LastName)
        {
            _FirstName = FirstName;
            _LastName = LastName;
        }

        public string FullName
        {
            get { return FirstName + " " + LastName; }

        }


        public static List<Person> GetPersons()
        {
            var result = new List<Person> {
                new Person("John", "Smith"),
                new Person("Bill", "Gates"),
                new Person("Max", "Luis")
            };
            return result;
        }





        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
