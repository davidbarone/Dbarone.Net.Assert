namespace Dbarone.Net.Assert;
using System;
using System.Runtime.CompilerServices;

/// <summary>
/// A simple assertion library.
/// </summary>
public class Assert
{
    /// <summary>
    /// Checks an actual value equals an expected value.
    /// </summary>
    /// <param name="actual">The actual object value.</param>
    /// <param name="expected">The expected value.</param>
    /// <param name="actual_name">The calling variable name.</param>
    /// <exception cref="AssertionException"></exception>
    public static void Equals(object actual, object expected, [CallerArgumentExpression("actual")] string? actual_name = null)
    {
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
    /// <param name="actual_name">The calling variable name.</param>
    /// <exception cref="AssertionException"></exception>
    public static void NotEquals(object actual, object expected, [CallerArgumentExpression("actual")] string? actual_name = null)
    {
        if (actual.Equals(expected))
        {
            throw new AssertionException($"{actual_name} should not be equal to {expected}.");
        }
    }

    public static void Null(object? obj, [CallerArgumentExpression("obj")] string? obj_name = null)
    {
        if (obj != null)
        {
            throw new AssertionException($"{obj_name} should be null but is not.");
        }
    }

    public static void NotNull(object? obj, [CallerArgumentExpression("obj")] string? obj_name = null)
    {
        if (obj == null)
        {
            throw new AssertionException($"{obj_name} should not be null but is.");
        }
    }

    public static void True(bool expr, [CallerArgumentExpression("expr")] string? expr_name = null)
    {
        if (!expr)
        {
            throw new AssertionException($"({expr_name}) should evaluate to true but evaluates to false.");
        }
    }

    public static void False(bool expr, [CallerArgumentExpression("expr")] string? expr_name = null)
    {
        if (expr)
        {
            throw new AssertionException($"({expr_name}) should evaluate to false but evaluates to true.");
        }
    }

    public static void Flag(Enum value, Enum flag, [CallerArgumentExpression("value")] string? value_name = null)
    {
        if (!value.GetType().IsEnum)
        {
            throw new AssertionException("${value_name} must be an enum type.");
        }

        if (!value.HasFlag(flag)) {
            throw new AssertionException($"{value_name} should have flag ({flag}) set, but doesn't.");
        }
    }

    public static void NotFlag(Enum value, Enum flag, [CallerArgumentExpression("value")] string? value_name = null)
    {
        if (!value.GetType().IsEnum)
        {
            throw new AssertionException("${value_name} must be an enum type.");
        }

        if (value.HasFlag(flag)) {
            throw new AssertionException($"{value_name} should not have flag ({flag}) set, but does.");
        }
    }

}