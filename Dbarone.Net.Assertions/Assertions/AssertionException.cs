namespace Dbarone.Net.Assertions;
using System;

/// <summary>
/// Standard exception thrown by all Assert failures.
/// </summary>
public class AssertionException : Exception
{
    /// <summary>
    /// Constructor for the AssertionException class.
    /// </summary>
    /// <param name="message">The assertion message being thrown.</param>
    public AssertionException(string message) : base(message) { }
}