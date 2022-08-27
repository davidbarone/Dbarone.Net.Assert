namespace Dbarone.Net.Assertions;
using System;
using System.Linq;
using System.Runtime.CompilerServices;

/// <summary>
/// Applies assertions to the state of objects. The assertions are evaluated in all configurations (debug and release). If the assertion succeeds, the code continues. If the assertion fails, an `AssertionException` is thrown.
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
            throw new AssertionException($"{actual_name} ({actual}) should be equal to ({expected}).");
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
            throw new AssertionException($"{actual_name} should not be equal to ({expected}).");
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
    /// Asserts that a value is greater than or equal to an expected value.
    /// </summary>
    /// <typeparam name="T">The value type to assert. Must be IComparable.</typeparam>
    /// <param name="actual">The value to assert.</param>
    /// <param name="expected">The expected value.</param>
    /// <param name="actual_name">The calling variable name (do not use - this is automatically populated by the library).</param>
    /// <exception cref="AssertionException">Throws an exception if the actual value is not greater than or equal to the expected value.</exception>
    public static void GreaterThanEquals<T>(T actual, T expected, [CallerArgumentExpression("actual")] string? actual_name = null) where T : IComparable
    {
        if (actual.CompareTo(expected) < 0)
        {
            throw new AssertionException($"{actual_name} ({actual}) should be greater than or equal to expected ({expected}).");
        }
    }

    /// <summary>
    /// Asserts that a value is not greater than or equal to an expected value.
    /// </summary>
    /// <typeparam name="T">The value type to assert. Must be IComparable.</typeparam>
    /// <param name="actual">The value to assert.</param>
    /// <param name="expected">The expected value.</param>
    /// <param name="actual_name">The calling variable name (do not use - this is automatically populated by the library).</param>
    /// <exception cref="AssertionException">Throws an exception if the actual value is greater than or equal to the expected value.</exception>
    public static void NotGreaterThanEquals<T>(T actual, T expected, [CallerArgumentExpression("actual")] string? actual_name = null) where T : IComparable
    {
        if (actual.CompareTo(expected) >= 0)
        {
            throw new AssertionException($"{actual_name} ({actual}) should not be greater than or equal to expected ({expected}).");
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
    /// Asserts that a value is less than or equal to an expected value.
    /// </summary>
    /// <typeparam name="T">The value type to assert. Must be IComparable.</typeparam>
    /// <param name="actual">The value to assert.</param>
    /// <param name="expected">The expected value.</param>
    /// <param name="actual_name">The calling variable name (do not use - this is automatically populated by the library).</param>
    /// <exception cref="AssertionException">Throws an exception if the actual value is not less than or equal to the expected value.</exception>
    public static void LessThanEquals<T>(T actual, T expected, [CallerArgumentExpression("actual")] string? actual_name = null) where T : IComparable
    {
        if (actual.CompareTo(expected) > 0)
        {
            throw new AssertionException($"{actual_name} ({actual}) should be less than or equal to expected ({expected}).");
        }
    }

    /// <summary>
    /// Asserts that a value is not less than or equal to an expected value.
    /// </summary>
    /// <typeparam name="T">The value type to assert. Must be IComparable.</typeparam>
    /// <param name="actual">The value to assert.</param>
    /// <param name="expected">The expected value.</param>
    /// <param name="actual_name">The calling variable name (do not use - this is automatically populated by the library).</param>
    /// <exception cref="AssertionException">Throws an exception if the actual value is less than or equal to the expected value.</exception>
    public static void NotLessThanEquals<T>(T actual, T expected, [CallerArgumentExpression("actual")] string? actual_name = null) where T : IComparable
    {
        if (actual.CompareTo(expected) <= 0)
        {
            throw new AssertionException($"{actual_name} ({actual}) should not be less than or equal to expected ({expected}).");
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

    /// <summary>
    /// Asserts that an actual value is a specific type.
    /// </summary>
    /// <param name="actual">The value to assert.</param>
    /// <param name="expected">The expected type.</param>
    /// <param name="actual_name">The calling variable name (do not use - this is automatically populated by the library).</param>
    /// <exception cref="AssertionException">Throws an exception if the actual value is not the specified type.</exception>
    public static void IsType(object actual, Type expected, [CallerArgumentExpression("actual")] string? actual_name = null)
    {
        if (actual == null)
        {
            throw new AssertionException($"{actual_name} should not be null.");
        }
        if (actual.GetType()!= expected){
            throw new AssertionException($"{actual_name} ({actual.GetType().Name}) should be of type ({expected.Name}).");
        }
    }

    /// <summary>
    /// Asserts that an actual value is not a specific type.
    /// </summary>
    /// <param name="actual">The value to assert.</param>
    /// <param name="expected">The expected type.</param>
    /// <param name="actual_name">The calling variable name (do not use - this is automatically populated by the library).</param>
    /// <exception cref="AssertionException">Throws an exception if the actual value is not the specified type.</exception>
    public static void NotIsType(object actual, Type expected, [CallerArgumentExpression("actual")] string? actual_name = null)
    {
        if (actual == null)
        {
            throw new AssertionException($"{actual_name} should not be null.");
        }
        if (actual.GetType()== expected){
            throw new AssertionException($"{actual_name} should not be of type ({expected.Name}).");
        }
    }

   /// <summary>
    /// Asserts that an actual value is assignable from a specific type.
    /// </summary>
    /// <param name="actual">The value to assert.</param>
    /// <param name="expected">The expected type.</param>
    /// <param name="actual_name">The calling variable name (do not use - this is automatically populated by the library).</param>
    /// <exception cref="AssertionException">Throws an exception if the actual value is not assignable from the specified type.</exception>
    public static void AssignableFrom(object actual, Type expected, [CallerArgumentExpression("actual")] string? actual_name = null)
    {
        if (actual == null)
        {
            throw new AssertionException($"{actual_name} should not be null.");
        }
        if (actual.GetType().IsAssignableFrom(expected)){
            throw new AssertionException($"{actual_name} ({actual.GetType().Name}) should be assignable from ({expected.Name}).");
        }
    }

    /// <summary>
    /// Asserts that an actual value is not assignable from a specific type.
    /// </summary>
    /// <param name="actual">The value to assert.</param>
    /// <param name="expected">The expected type.</param>
    /// <param name="actual_name">The calling variable name (do not use - this is automatically populated by the library).</param>
    /// <exception cref="AssertionException">Throws an exception if the actual value is assignable from the specified type.</exception>
    public static void NotAssignableFrom(object actual, Type expected, [CallerArgumentExpression("actual")] string? actual_name = null)
    {
        if (actual == null)
        {
            throw new AssertionException($"{actual_name} should not be null.");
        }
        if (actual.GetType().IsAssignableFrom(expected)){
            throw new AssertionException($"{actual_name} should not be assignable from ({expected.Name}).");
        }
    }

    #region Collections

    /// <summary>
    /// Asserts that a collection contains an element with a specified value.
    /// </summary>
    /// <typeparam name="T">The type of the collection elements.</typeparam>
    /// <param name="actual">A collection.</param>
    /// <param name="expected">The expected element value.</param>
    /// <param name="actual_name">The calling variable name (do not use - this is automatically populated by the library).</param>
    /// <exception cref="AssertionException">Throws an exception if the collection does not contain the specified element.</exception>
    public static void Contains<T>(IEnumerable<T> actual, T expected, [CallerArgumentExpression("actual")] string? actual_name = null){
        if (actual == null)
        {
            throw new AssertionException($"{actual_name} should not be null.");
        }
        if (!actual.Contains(expected)){
            throw new AssertionException($"{actual_name} should contain element ({expected}).");
        }
    }

    /// <summary>
    /// Asserts that a collection does not contain an element with a specified value.
    /// </summary>
    /// <typeparam name="T">The type of the collection elements.</typeparam>
    /// <param name="actual">A collection.</param>
    /// <param name="expected">The expected element value.</param>
    /// <param name="actual_name">The calling variable name (do not use - this is automatically populated by the library).</param>
    /// <exception cref="AssertionException">Throws an exception if the collection contains the specified element.</exception>
   public static void NotContains<T>(IEnumerable<T> actual, T expected, [CallerArgumentExpression("actual")] string? actual_name = null){
        if (actual == null)
        {
            throw new AssertionException($"{actual_name} should not be null.");
        }
        if (actual.Contains(expected)){
            throw new AssertionException($"{actual_name} should not contain element ({expected}).");
        }
    }

    /// <summary>
    /// Asserts that a collection is empty.
    /// </summary>
    /// <typeparam name="T">The type of the collection elements.</typeparam>
    /// <param name="actual">A collection.</param>
    /// <param name="actual_name">The calling variable name (do not use - this is automatically populated by the library).</param>
    /// <exception cref="AssertionException">Throws an exception if the collection is not empty.</exception>
    public static void Empty<T>(IEnumerable<T> actual, [CallerArgumentExpression("actual")] string? actual_name = null){
        if (actual == null)
        {
            throw new AssertionException($"{actual_name} should not be null.");
        }
        if (actual.Any()){
            throw new AssertionException($"{actual_name} should be empty.");
        }
    }

    /// <summary>
    /// Asserts that a collection is not empty.
    /// </summary>
    /// <typeparam name="T">The type of the collection elements.</typeparam>
    /// <param name="actual">A collection.</param>
    /// <param name="actual_name">The calling variable name (do not use - this is automatically populated by the library).</param>
    /// <exception cref="AssertionException">Throws an exception if the collection is empty.</exception>
   public static void NotEmpty<T>(IEnumerable<T> actual, [CallerArgumentExpression("actual")] string? actual_name = null){
        if (actual == null)
        {
            throw new AssertionException($"{actual_name} should not be null.");
        }
        if (!actual.Any()){
            throw new AssertionException($"{actual_name} should not be empty.");
        }
    }

    /// <summary>
    /// Asserts that a collection has exactly one element.
    /// </summary>
    /// <typeparam name="T">The type of the collection elements.</typeparam>
    /// <param name="actual">A collection.</param>
    /// <param name="actual_name">The calling variable name (do not use - this is automatically populated by the library).</param>
    /// <exception cref="AssertionException">Throws an exception if the collection does not have exactly one element.</exception>
    public static void Single<T>(IEnumerable<T> actual, [CallerArgumentExpression("actual")] string? actual_name = null){
        if (actual == null)
        {
            throw new AssertionException($"{actual_name} should not be null.");
        }
        if (actual.Count() != 1){
            throw new AssertionException($"{actual_name} should have exactly one element.");
        }
    }

    /// <summary>
    /// Asserts that a collection does not have exactly one element.
    /// </summary>
    /// <typeparam name="T">The type of the collection elements.</typeparam>
    /// <param name="actual">A collection.</param>
    /// <param name="actual_name">The calling variable name (do not use - this is automatically populated by the library).</param>
    /// <exception cref="AssertionException">Throws an exception if the collection does have exactly one element.</exception>
   public static void NotSingle<T>(IEnumerable<T> actual, [CallerArgumentExpression("actual")] string? actual_name = null){
        if (actual == null)
        {
            throw new AssertionException($"{actual_name} should not be null.");
        }
        if (actual.Count() == 1){
            throw new AssertionException($"{actual_name} should not have exactly one element.");
        }
    }

    /// <summary>
    /// Asserts that all elements of a collection satisfy a predicate.
    /// </summary>
    /// <typeparam name="T">The type of the collection elements.</typeparam>
    /// <param name="actual">A collection.</param>
    /// <param name="predicate">The predicate to evaluate on each member of the collection.</param>
    /// <param name="actual_name">The calling variable name (do not use - this is automatically populated by the library).</param>
    /// <param name="predicate_name">The calling predicate name (do not use - this is automatically populated by the library).</param>
    /// <exception cref="AssertionException">Throws an exception if any of the elements in the collection does not satisfy the predicate.</exception>
   public static void All<T>(IEnumerable<T> actual, Func<T, bool> predicate, [CallerArgumentExpression("actual")] string? actual_name = null, [CallerArgumentExpression("predicate")] string? predicate_name = null){
        if (actual == null)
        {
            throw new AssertionException($"{actual_name} should not be null.");
        }
        if (actual.Where(a=>!predicate(a)).Any()){
            throw new AssertionException($"{actual_name} should satisfy the predicate ({predicate_name}) for all elements.");
        }
    }

    #endregion

    #region Timing

    /// <summary>
    /// Asserts that an action completes within a certain timeframe. Note that the action will be allowed to complete regardless of whether or not it completes within the asserted timeout.
    /// </summary>
    /// <param name="action">The action to check.</param>
    /// <param name="timeout">The maximum timeframe the action can run for.</param>
    /// <param name="action_name">The calling action variable name (do not use - this is automatically populated by the library).</param>
    /// <exception cref="AssertionException">Throws an exception if the action completes in a longer time that expected.</exception>
    public static void CompletesIn(Action action, TimeSpan timeout, [CallerArgumentExpression("action")] string? action_name = null){
        DateTime start = DateTime.Now;
        action.Invoke();
        DateTime end = DateTime.Now;
        TimeSpan actual = end - start;

        if (actual > timeout) {
            throw new AssertionException($"{action_name} should complete within {timeout}, but completed in {actual}.");
        }
    }

    #endregion
}