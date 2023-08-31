using System;
public class PathNotFoundException : ArgumentException
{
    public PathNotFoundException()
        : base("The path provided was not found.")
    { }
}