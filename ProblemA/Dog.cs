using System.Collections.Generic;

namespace ProblemA
{
    public class Dog
    {
        public Dog()
        {
            Address = new List<Address>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public bool IsInsured { get; set; }
        public List<Address> Address { get; set; }
    }
}
