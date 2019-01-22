using System;
using System.Collections.Generic;
using System.Text;


public class BankAccount
{
    int id;

    public int Id
    {
        get { return id; }
        set { id = value; }
    }


    decimal balance;
    public decimal Balance
    {
        get { return balance; }
        set { balance = value; }
    }
}