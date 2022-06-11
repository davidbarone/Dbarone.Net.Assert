namespace Dbarone.Net.Assertions;
using System;
using System.Runtime.CompilerServices;

/// <summary>
/// Enables a user to perform a variety of assertions. The assertions are evaluated in all configurations (debug and release). If the assertion succeeds, the code continues. If the assertion fails, an `AssertionException` is thrown.
/// </summary>
public class Assert
{
    /// <summary>
    /// Checks an actual value equals an expected value.
    /// </summary>
    /// <param name="actual">The actual object value.</param>
    /// <param name="expected">The expected value.</param>
    /// <param name="actual_name">The calling variable name (do not use - this is automatically populated by the library).</param>
    /// <exception cref="AssertionException">Throws an exception if the actual value is not equal to the expected value.</exception>
    public static void Equals(object actual, object expected, [CallerArgumentExpression("actual")] string? actual_name = null)
    {
        if (actual == null)
        {
            throw new AssertionException($"{actual_name} is null. If you are testing for null, use Assert.Null().");
        }
        if (!actual.Equals(expected))
        {
            throw new AssertionException($"{actual_name} should be equal to {expected}, but is equal to {actual}.");
        }
    }

    /// <summary>
    /// Checks an actual value does not equal an expected value.
    /// </summary>
    /// <param name="actual">The actual object value.</param>
    /// <param name="expected">The expected value.</param>
    /// <param name="actual_name">The calling variable name (do not use - this is automatically populated by the library).</param>
    /// <exception cref="AssertionException">Throws an exception if the actual value is equal to the expected value.</exception>
    public static void NotEquals(object actual, object expected, [CallerArgumentExpression("actual")] string? actual_name = null)
    {
        if (actual == null)
        {
            throw new AssertionException($"{actual_name} is null. If you are testing for null, use Assert.Null().");
        }
        if (actual.Equals(expected))
        {
            throw new AssertionException($"{actual_name} should not be equal to {expected}.");
        }
    }

    /// <summary>
    /// Checks that an object reference should be null.
    /// </summary>
    /// <param name="obj">The object to check.</param>
    /// <param name="obj_name">The calling variable name (do not use - this is automatically populated by the library).</param>
    /// <exception cref="AssertionException">Throws an exception if the object is not null.</exception>
    public static void Null(object? obj, [CallerArgumentExpression("obj")] string? obj_name = null)
    {
        if (obj != null)
        {
            throw new AssertionException($"{obj_name} should be null but is not.");
        }
    }

    /// <summary>
    /// Checks that an object reference should not be null.
    /// </summary>
    /// <param name="obj">The object to check.</param>
    /// <param name="obj_name">The calling variable name (do not use - this is automatically populated by the library).</param>
    /// <exception cref="AssertionException">Throws an exception if the object is null.</exception>
    public static void NotNull(object? obj, [CallerArgumentExpression("obj")] string? obj_name = null)
    {
        if (obj == null)
        {
            throw new AssertionException($"{obj_name} should not be null but is.");
        }
    }

    /// <summary>
    /// Asserts an expression is truthy.
    /// </summary>
    /// <param name="expr">The expression to evaulate. Must return a boolean result.</param>
    /// <param name="expr_name">The expression name (do not use - this is automatically populated by the library).</param>
    /// <exception cref="AssertionException">Throws an exception if the expression resolves to false.</exception>
    public static void True(bool expr, [CallerArgumentExpression("expr")] string? expr_name = null)
    {
        if (!expr)
        {
            throw new AssertionException($"({expr_name}) should evaluate to true but evaluates to false.");
        }
    }

    /// <summary>
    /// Asserts an expression is falsy.
    /// </summary>
    /// <param name="expr">The expression to evaulate. Must return a boolean result.</param>
    /// <param name="expr_name">The expression name (do not use - this is automatically populated by the library).</param>
    /// <exception cref="AssertionException">Throws an exception if the expression resolves to true.</exception>
    public static void False(bool expr, [CallerArgumentExpression("expr")] string? expr_name = null)
    {
        if (expr)
        {
            throw new AssertionException($"({expr_name}) should evaluate to false but evaluates to true.");
        }
    }

    /// <summary>
    /// Asserts that an enum value has a flag set.
    /// </summary>
    /// <param name="actual">The actual value.</param>
    /// <param name="flag">The flag to check.</param>
    /// <param name="actual_name">The calling variable name (do not use - this is automatically populated by the library).</param>
    /// <exception cref="AssertionException">Throws an exception if the enum value does not have the flag set.</exception>
    public static void Flag(Enum actual, Enum flag, [CallerArgumentExpression("actual")] string? actual_name = null)
    {
        if (!actual.GetType().IsEnum)
        {
            throw new AssertionException($"${actual_name} must be an enum type.");
        }

        if (!actual.HasFlag(flag))
        {
            throw new AssertionException($"{actual_name} should have flag ({flag}) set, but doesn't.");
        }
    }

    /// <summary>
    /// Asserts that an enum value does not have a flag set.
    /// </summary>
    /// <param name="actual">The actual value.</param>
    /// <param name="flag">The flag to check.</param>
    /// <param name="actual_name">The calling variable name (do not use - this is automatically populated by the library).</param>
    /// <exception cref="AssertionException">Throws an exception if the enum value does not have the flag set.</exception>
    public static void NotFlag(Enum actual, Enum flag, [CallerArgumentExpression("actual")] string? actual_name = null)
    {
        if (!actual.GetType().IsEnum)
        {
            throw new AssertionException("${value_name} must be an enum type.");
        }

        if (actual.HasFlag(flag))
        {
            throw new AssertionException($"{actual_name} should not have flag ({flag}) set, but does.");
        }
    }

}