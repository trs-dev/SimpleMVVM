using ClassicMVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace ClassicMVVM.ViewModels
{
    internal class PersonViewModel : INotifyPropertyChanged
    {

        Person _SelectedPerson;

        public Person SelectedPerson
        {
            get { return _SelectedPerson; }
            set
            {
                _SelectedPerson = value;
                OnPropertyChanged();
            }
        }


        public ObservableCollection<Person> Persons { get; private set; }


        public PersonViewModel()
        {
            Persons = new ObservableCollection<Person>(Person.GetPersons());
        }



        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
