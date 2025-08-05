using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentModel
{
    [Serializable]
    public class Agent
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public string City {  get; set; }

        public string Gender { get; set; }
        public double PremiumAmount {  get; set; }

        public Agent() { }

        public Agent(int id, string firstName, string lastName, string city, string gender, double premiumAmount)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            City = city;
            Gender = gender;
            PremiumAmount = premiumAmount;
        }

        public override string ToString()
        {
            return "The Agent id is" + Id
                + "The Agent FirstName is" + FirstName
                + "The Agent LastName is" + LastName
                + "The Agent City is" + City
                + "The Agent Gender is" + Gender
                + "The Agemt PremiumAmount" + PremiumAmount;
        }
    }
}
