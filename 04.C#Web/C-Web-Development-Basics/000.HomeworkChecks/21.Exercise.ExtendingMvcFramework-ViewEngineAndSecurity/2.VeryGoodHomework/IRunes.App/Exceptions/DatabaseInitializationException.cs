using System;

namespace IRunes.App.Exceptions
{
    public class DatabaseInitializationException : Exception
    {
	public override string Message => "Database could not be initialized!";
    }
}
