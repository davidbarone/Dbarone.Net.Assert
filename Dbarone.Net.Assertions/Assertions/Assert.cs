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
            throw new AssertionException($"{actual_name} ({actual}) should be equal to {expected}.");
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
            throw new AssertionException($"{obj_name} should be null.");
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
            throw new AssertionException($"{obj_name} should not be null.");
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
            throw new AssertionException($"({expr_name}) should be true.");
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
            throw new AssertionException($"({expr_name}) should be false.");
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
            throw new AssertionException($"{actual_name} ({actual}) should have flag ({flag}) set.");
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
            throw new AssertionException($"{actual_name} ({actual}) should not have flag ({flag}) set.");
        }
    }

    /// <summary>
    /// Asserts that a value is greater than an expected value.
    /// </summary>
    /// <typeparam name="T">The value type to assert. Must be IComparable.</typeparam>
    /// <param name="actual">The value to assert.</param>
    /// <param name="expected">The expected value.</param>
    /// <param name="actual_name">The calling variable name (do not use - this is automatically populated by the library).</param>
    /// <exception cref="AssertionException">Throws an exception if the actual value is not greater than the expected value.</exception>
    public static void GreaterThan<T>(T actual, T expected, [CallerArgumentExpression("actual")] string? actual_name = null) where T : IComparable
    {
        if (actual.CompareTo(expected) <= 0)
        {
            throw new AssertionException($"{actual_name} ({actual}) should be greater than expected ({expected}).");
        }
    }

    /// <summary>
    /// Asserts that a value is not greater than an expected value.
    /// </summary>
    /// <typeparam name="T">The value type to assert. Must be IComparable.</typeparam>
    /// <param name="actual">The value to assert.</param>
    /// <param name="expected">The expected value.</param>
    /// <param name="actual_name">The calling variable name (do not use - this is automatically populated by the library).</param>
    /// <exception cref="AssertionException">Throws an exception if the actual value is greater than the expected value.</exception>
    public static void NotGreaterThan<T>(T actual, T expected, [CallerArgumentExpression("actual")] string? actual_name = null) where T : IComparable
    {
        if (actual.CompareTo(expected) > 0)
        {
            throw new AssertionException($"{actual_name} ({actual}) should not be greater than expected ({expected}).");
        }
    }

    /// <summary>
    /// Asserts that a value is less than an expected value.
    /// </summary>
    /// <typeparam name="T">The value type to assert. Must be IComparable.</typeparam>
    /// <param name="actual">The value to assert.</param>
    /// <param name="expected">The expected value.</param>
    /// <param name="actual_name">The calling variable name (do not use - this is automatically populated by the library).</param>
    /// <exception cref="AssertionException">Throws an exception if the actual value is not less than the expected value.</exception>
    public static void LessThan<T>(T actual, T expected, [CallerArgumentExpression("actual")] string? actual_name = null) where T : IComparable
    {
        if (actual.CompareTo(expected) >= 0)
        {
            throw new AssertionException($"{actual_name} ({actual}) should be less than expected ({expected}).");
        }
    }

    /// <summary>
    /// Asserts that a value is not less than an expected value.
    /// </summary>
    /// <typeparam name="T">The value type to assert. Must be IComparable.</typeparam>
    /// <param name="actual">The value to assert.</param>
    /// <param name="expected">The expected value.</param>
    /// <param name="actual_name">The calling variable name (do not use - this is automatically populated by the library).</param>
    /// <exception cref="AssertionException">Throws an exception if the actual value is less than the expected value.</exception>
    public static void NotLessThan<T>(T actual, T expected, [CallerArgumentExpression("actual")] string? actual_name = null) where T : IComparable
    {
        if (actual.CompareTo(expected) < 0)
        {
            throw new AssertionException($"{actual_name} ({actual}) should not be less than expected ({expected}).");
        }
    }

    /// <summary>
    /// Asserts that a value is between 2 values.
    /// </summary>
    /// <typeparam name="T">The value type to assert. Must be IComparable.</typeparam>
    /// <param name="actual">The value to assert.</param>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <param name="actual_name">The calling variable name (do not use - this is automatically populated by the library).</param>
    /// <exception cref="AssertionException">Throws an exception if the actual value is between the min and max values.</exception>
    public static void Between<T>(T actual, T min, T max, [CallerArgumentExpression("actual")] string? actual_name = null) where T : IComparable
    {
        if (!(actual.CompareTo(min) >= 0 && actual.CompareTo(max) <= 0))
        {
            throw new AssertionException($"{actual_name} ({actual}) should be between ({min}) and ({max}).");
        }
    }

    /// <summary>
    /// Asserts that a value is between 2 values.
    /// </summary>
    /// <typeparam name="T">The value type to assert. Must be IComparable.</typeparam>
    /// <param name="actual">The value to assert.</param>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <param name="actual_name">The calling variable name (do not use - this is automatically populated by the library).</param>
    /// <exception cref="AssertionException">Throws an exception if the actual value is between the min and max values.</exception>
    public static void NotBetween<T>(T actual, T min, T max, [CallerArgumentExpression("actual")] string? actual_name = null) where T : IComparable
    {
        if ((actual.CompareTo(min) >= 0 && actual.CompareTo(max) <= 0))
        {
            throw new AssertionException($"{actual_name} ({actual}) should not be between ({min}) and ({max}).");
        }
    }
}