using System.Collections.Generic;

public interface IBrowser
{
    ICollection<string> Urls { get; }

    string Browse(string url);
}