using ReactiveUI;
using ReactiveUI_MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace ReactiveUI_MVVM.ViewModels
{
    internal class PersonViewModel : ReactiveObject
    {

        Person _SelectedPerson;

        public Person SelectedPerson
        {
            get => _SelectedPerson;
            set => this.RaiseAndSetIfChanged(ref _SelectedPerson, value);
        }

        public ObservableCollection<Person> Persons { get; private set; }
        
        public PersonViewModel()
        {
            Persons = new ObservableCollection<Person>(Person.GetPersons());
        }

    }
}
