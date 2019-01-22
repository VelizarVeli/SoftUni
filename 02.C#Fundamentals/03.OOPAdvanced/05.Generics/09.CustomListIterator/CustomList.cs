using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CustomList<T> : ICustomList<T>, IEnumerable<T>
    where T : IComparable<T>
{
    private IList<T> customList;

    public CustomList()
    {
        this.customList = new List<T>();
    }

    public void Add(T element)
    {
        this.customList.Add(element);
    }

    public T Remove(int index)
    {
        T removedElement = this.customList[index];

        this.customList.RemoveAt(index);

        return removedElement;
    }

    public bool Contains(T element)
    {
        if (this.customList.Contains(element))
        {
            return true;
        }

        return false;
    }

    public void Swap(int index1, int index2)
    {
        T temp = this.customList[index1];
        this.customList[index1] = this.customList[index2];
        this.customList[index2] = temp;
    }

    public int CountGreaterThan(T element)
    {
        int counter = 0;

        foreach (var item in this.customList)
        {
            if (item.CompareTo(element) > 0)
            {
                counter++;
            }
        }

        return counter;
    }

    public T Max()
    {
        T maxElement = this.customList.Max();

        return maxElement;
    }

    public T Min()
    {
        T minElement = this.customList.Min();

        return minElement;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        foreach (var item in this.customList)
        {
            sb.AppendLine(item.ToString());
        }

        return sb.ToString().TrimEnd();
    }

    public IEnumerator<T> GetEnumerator()
    {
        return this.customList.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.customList.GetEnumerator();
    }

    public void Sort()
    {
        this.customList = this.customList
            .OrderBy(x => x)
            .ToList();
    }
}