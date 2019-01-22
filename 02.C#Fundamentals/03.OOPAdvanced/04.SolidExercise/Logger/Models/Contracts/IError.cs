using System;

namespace Logger.Models.Contracts
{
    public interface IError : ILevelable
    {
        DateTime DateTime { get; }

        string Message { get; }
    }
}