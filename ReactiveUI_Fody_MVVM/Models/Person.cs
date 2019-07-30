using ReactiveUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ReactiveUI_Fody_MVVM.Models
{
    public class Person : ReactiveObject
    {
        private string _FirstName;
        public string FirstName
        {
            get => _FirstName;
            set => this.RaiseAndSetIfChanged(ref _FirstName, value);
        }

        private string _LastName;
        public string LastName
        {
            get => _LastName;
            set => this.RaiseAndSetIfChanged(ref _LastName, value);
        }

               
        private string _FullName;
        public string FullName
        {
            get => _FullName;
            set => this.RaiseAndSetIfChanged(ref _FullName, value);
        }

        private void UpdateFullName()
        {
            FullName = FirstName + " " + LastName;
        }


        public Person(string FirstName, string LastName)
        {
            _FirstName = FirstName;
            _LastName = LastName;
            this.WhenAnyValue(person => person.FirstName, person => person.LastName).Subscribe(_ => UpdateFullName());
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


    }
}
