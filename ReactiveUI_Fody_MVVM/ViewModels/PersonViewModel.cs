using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using ReactiveUI_Fody_MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace ReactiveUI_Fody_MVVM.ViewModels
{
    internal class PersonViewModel : ReactiveObject
    {

        [Reactive] public Person SelectedPerson { get; set; }

        public ObservableCollection<Person> Persons { get; private set; }

        public PersonViewModel()
        {
            Persons = new ObservableCollection<Person>(Person.GetPersons());
        }

    }
}
