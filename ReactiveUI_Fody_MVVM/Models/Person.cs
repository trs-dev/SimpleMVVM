using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ReactiveUI_Fody_MVVM.Models
{
    public class Person : ReactiveObject
    {
        [Reactive] public string FirstName { get; set; }
        [Reactive] public string LastName { get; set; }


        private readonly ObservableAsPropertyHelper<string> _FullName;
        public string FullName => _FullName.Value;

        
        public Person(string _FirstName, string _LastName)
        {
            FirstName = _FirstName;
            LastName = _LastName;

            _FullName = this.WhenAnyValue(person => person.FirstName, person => person.LastName)
                .Select(t => t.Item1 + " " + t.Item2)
                .ToProperty(this, vm => vm.FullName);
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
