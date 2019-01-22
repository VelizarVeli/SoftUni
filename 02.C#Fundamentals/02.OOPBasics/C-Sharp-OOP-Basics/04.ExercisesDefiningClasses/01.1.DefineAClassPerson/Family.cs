using System.Collections.Generic;
using System.Linq;

public class Family
{
    private List<Person> people = new List<Person>();

    public List<Person> People
    {
        get { return people; }
        set { people = new List<Person>(); }
    }

    public void AddMember(Person member)
    {
        people.Add(member);
    }

    public Person GetOldestMember()
    {
        return this.people.OrderByDescending(a => a.Age).FirstOrDefault();
    }
}