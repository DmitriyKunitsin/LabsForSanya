using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassStructNamespace
{
    internal class Human
    {
        public const string type = "Person";
        string firstName;
        string lastName;
        int oldYear;
        private string email;
        private string phone;
        // эквивалентно public string Phone { get { return phone; } }
        public string Phone => phone;
        
        public string FullCardName
        {
            get
            {
                return GetFullInfo(firstName, lastName, oldYear);
            }
        }

        public string FullName
        {
            get { return GetFullName(firstName, lastName); }
        }
        public int OldYear
        {
            get
            {
                return oldYear;
            }
            init
            {
                oldYear = 18;
            }
        }

        public string Email { get => email; set => email = value; }
        public string FirstName { get; set; } = "Test";

        public string LastName { get; set; } = "Testovich";

        public Human(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }
        public Human(string firstName, string lastName, int years)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.OldYear = years;
        }
        public Human(int years) => OldYear = years;

        public Human() { }


        private string GetFullName(string firstName, string lastName)
        {
            return firstName + " " + lastName + " " + type;
        }

        private string GetFullInfo(string firstName, string lastName, int oldYears)
        {
            firstName = FirstName;
            lastName = LastName;
            oldYears = OldYear;
            return firstName + " " + lastName + " " + oldYears;
        }

    }
}
