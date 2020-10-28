using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        public Family()
        {
            People = new List<Person>(); 
        }
        public List<Person> People { get; set; }

        public void AddMember(Person member)
        {
            People.Add(member);
        }

        public Person GetOldestMember()
        {
           Person oldestPerson= People.OrderByDescending(n => n.Age).First();
            return oldestPerson;
           
        }

        public Person[] GetPeople()
        {
            var people = People.Where(x => x.Age > 30).OrderBy(X => X.Name).ToArray();
            return people;
        }
    }
}
