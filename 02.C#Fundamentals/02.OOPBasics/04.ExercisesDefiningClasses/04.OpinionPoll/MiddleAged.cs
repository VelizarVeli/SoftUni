using System.Collections.Generic;
using System.Linq;

class MiddleAged
{
    private List<Person> middleAged;

    public MiddleAged()
    {
        this.middleAged = new List<Person>();
    }

    public void AddMember(Person member)
    {
        middleAged.Add(member);
    }

    public List<Person> GetMiddleAged()
    {
        return middleAged.OrderBy(a => a.Name).Where(a => a.Age > 30).ToList();
    }
}