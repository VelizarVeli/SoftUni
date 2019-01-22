using System;

class Test<T>
{
    T _value;

    public Test(T t)
    {
        // The field has the same type as the parameter.
        this._value = t;
    }

    public void Write()
    {
        Console.WriteLine(this._value);
    }
}