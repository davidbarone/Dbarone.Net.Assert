# Dbarone.Net.Assert
A .NET assertion library.

This is an assertion framework that uses a simple `Assert` static class to perform various assertions. The assertions run on all configurations (debug, release). If an assertion fails, an `AssertionException` is thrown. Clear, consise error messages include the variable names. This is made possible by the new `CallerArgumentExpression` class available in .NET 6.0 / C# 10.0.

## Documentation

For full details of the library, please refer to the [documentation](./Documentation.md).

## Sample code

A simple example of using the this library is shown below:

``` cs
public void DoSomething(int value)
{
    // Ensure that value equals 10 before proceeding.
    Assert.Equals(actual, 10);  // will raise exception if not equal to 10.
}
```