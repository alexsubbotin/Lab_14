using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subb_Lab_14
{
    // Monarchy class (inherits State class)
    class Monarchy : State
    {
        // Name of current rulling clan
        protected string currentRullingClanName; 

        // currentRulingClanNam property
        public string CurrentRullingClanName
        {
            get
            {
                return currentRullingClanName;
            }
            set
            {
                currentRullingClanName = value;
            }
        }

        // Constructor without parameters
        public Monarchy() : base() 
        {
            CurrentRullingClanName = "";
        }
        // Constructor with parameters
        public Monarchy(string Name, string lName, int Pop, int Age, string Cont,
            string curr):base(Name, lName, Pop, Age, Cont) 
        {
            CurrentRullingClanName = curr;
        }

        // Redefinition of the Show method
        public override void Show() 
        {
            Console.WriteLine(" Monarchical state's name: {0}\n Monarch's name: {1}\n Monarchical state's population: {2}\n " +
                "Monarchical state's age: {3}\n Continent: {4}\n " +
                "Current rulling clan: {5}\n", 
                Name, LeaderName, Population, Age, Continent, CurrentRullingClanName);
        }

        // Property that returns an object of the base class.
        public State BaseState
        {
            get
            {
                return new State(this.Name, this.LeaderName, this.Population, this.Age, this.Continent);
            }
        }

        // Function to generate a random object.
        public static Random rnd = new Random();
        public static Monarchy Generate(int a)
        {
            Monarchy monarchy = new Monarchy();

            string[] continents = { "Asia", "Africa", "America", "Oceania", "Europe" };

            // Creating the element.
            for (int i = 0; i < rnd.Next(4, 20); i++)
            {
                monarchy.Name += (char)rnd.Next(65, 91);
                monarchy.LeaderName += (char)rnd.Next(97, 123);
                monarchy.Age += rnd.Next(0, 150);
                monarchy.Population += rnd.Next(0, 1000);
                monarchy.CurrentRullingClanName += (char)rnd.Next(65, 91);
            }

            monarchy.Continent = continents[rnd.Next(0, 5)];

            return monarchy;
        }
    }
}
