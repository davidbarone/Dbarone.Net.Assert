namespace Dbarone.Net.Assertions.Tests;
using DbAssert = Dbarone.Net.Assertions.Assert;
using System;
using System.Collections.Generic;
using Xunit;

public class Animal
{

}

public class Dog : Animal
{

}

public class House
{

}

public class AssertionTests
{
    [Theory]
    [InlineData(10, 10)]
    [InlineData(true, true)]
    [InlineData("ABC", "ABC")]
    public void Equal_Success(object actual, object expected)
    {
        DbAssert.Equals(actual, expected);
    }

    [Theory]
    [InlineData(null, null)]
    [InlineData(10, null)]
    [InlineData(null, 10)]
    [InlineData(10, 9)]
    [InlineData(true, false)]
    [InlineData("ABC", "ABCD")]
    public void Equal_Failure(object actual, object expected)
    {
        Assert.Throws<AssertionException>(() => DbAssert.Equals(actual, expected));
    }

    [Theory]
    [InlineData((1 == 1))]
    public void True_Success(bool expr)
    {
        DbAssert.True(expr);
    }

    [Theory]
    [InlineData((1 == 2))]
    public void True_Failure(bool expr)
    {
        Assert.Throws<AssertionException>(() => DbAssert.True(expr));
    }

    [Theory]
    [InlineDataAttribute(FlagsEnum.bar | FlagsEnum.baz, FlagsEnum.bar)]
    public void Flags_Success(System.Enum actual, System.Enum flag)
    {
        DbAssert.Flag(actual, flag);
    }

    [Theory]
    [InlineDataAttribute(FlagsEnum.bar | FlagsEnum.baz, FlagsEnum.other)]
    public void Flags_Failure(System.Enum actual, System.Enum flag)
    {
        Assert.Throws<AssertionException>(() => DbAssert.Flag(actual, flag));
    }

    [Theory]
    [InlineDataAttribute(FlagsEnum.bar | FlagsEnum.baz, FlagsEnum.other)]
    public void NotFlags_Success(System.Enum actual, System.Enum flag)
    {
        DbAssert.NotFlag(actual, flag);
    }

    [Theory]
    [InlineDataAttribute(FlagsEnum.bar | FlagsEnum.baz, FlagsEnum.bar)]
    public void NotFlags_Failure(System.Enum actual, System.Enum flag)
    {
        Assert.Throws<AssertionException>(() => DbAssert.NotFlag(actual, flag));
    }

    [Theory]
    [InlineDataAttribute(2, 1)]
    public void GreaterThan_Success(IComparable actual, IComparable expected)
    {
        DbAssert.GreaterThan(actual, expected);
    }

    [Theory]
    [InlineDataAttribute(1, 2)]
    public void GreaterThan_Failure(IComparable actual, IComparable expected)
    {
        Assert.Throws<AssertionException>(() => DbAssert.GreaterThan(actual, expected));
    }

    [Theory]
    [InlineDataAttribute(2, 2)]
    [InlineDataAttribute(2, 3)]
    public void NotGreaterThan_Success(IComparable actual, IComparable expected)
    {
        DbAssert.NotGreaterThan(actual, expected);
    }

    [Theory]
    [InlineDataAttribute(2, 1)]
    public void NotGreaterThan_Failure(IComparable actual, IComparable expected)
    {
        Assert.Throws<AssertionException>(() => DbAssert.NotGreaterThan(actual, expected));
    }

    [Theory]
    [InlineDataAttribute(1, 2)]
    public void LessThan_Success(IComparable actual, IComparable expected)
    {
        DbAssert.LessThan(actual, expected);
    }

    [Theory]
    [InlineDataAttribute(2, 1)]
    public void LessThan_Failure(IComparable actual, IComparable expected)
    {
        Assert.Throws<AssertionException>(() => DbAssert.LessThan(actual, expected));
    }

    [Theory]
    [InlineDataAttribute(2, 2)]
    [InlineDataAttribute(2, 1)]
    public void NotLessThan_Success(IComparable actual, IComparable expected)
    {
        DbAssert.NotLessThan(actual, expected);
    }

    [Theory]
    [InlineDataAttribute(1, 2)]
    public void NotLessThan_Failure(IComparable actual, IComparable expected)
    {
        Assert.Throws<AssertionException>(() => DbAssert.NotLessThan(actual, expected));
    }

    [Theory]
    [InlineDataAttribute(2, 1, 3)]
    [InlineDataAttribute(2, 2, 2)]
    public void Between_Success(IComparable actual, IComparable min, IComparable max)
    {
        DbAssert.Between(actual, min, max);
    }

    [Theory]
    [InlineDataAttribute(1, 2, 3)]
    public void Between_Failure(IComparable actual, IComparable min, IComparable max)
    {
        Assert.Throws<AssertionException>(() => DbAssert.Between(actual, min, max));
    }

    [Theory]
    [InlineDataAttribute(1, 2, 3)]
    public void NotBetween_Success(IComparable actual, IComparable min, IComparable max)
    {
        DbAssert.NotBetween(actual, min, max);
    }

    [Theory]
    [InlineDataAttribute(2, 1, 3)]
    [InlineDataAttribute(2, 2, 2)]
    public void NotBetween_Failure(IComparable actual, IComparable min, IComparable max)
    {
        Assert.Throws<AssertionException>(() => DbAssert.NotBetween(actual, min, max));
    }

    [Fact]
    public void IsType_Success()
    {
        var d = new Dog();
        DbAssert.IsType(d, typeof(Dog));
    }

    [Fact]
    public void IsType_Failure()
    {
        var d = new Dog();
        Assert.Throws<AssertionException>(() => DbAssert.IsType(d, typeof(Animal)));
    }

    [Fact]
    public void NotIsType_Success()
    {
        var d = new Dog();
        DbAssert.NotIsType(d, typeof(Animal));
    }

    [Fact]
    public void NotIsType_Failure()
    {
        var d = new Dog();
        Assert.Throws<AssertionException>(() => DbAssert.NotIsType(d, typeof(Dog)));
    }

    [Fact]
    public void AssignableFrom_Success()
    {
        var d = new Dog();
        DbAssert.AssignableFrom(d, typeof(Animal));
    }

    [Fact]
    public void AssignableFrom_Failure()
    {
        var h = new House();
        Assert.Throws<AssertionException>(() => DbAssert.IsType(h, typeof(Animal)));
    }

    [Fact]
    public void NotAssignableFrom_Success()
    {
        var h = new House();
        DbAssert.NotAssignableFrom(h, typeof(Animal));
    }

    [Fact]
    public void NotAssignableFrom_Failure()
    {
        var d = new Dog();
        Assert.Throws<AssertionException>(() => DbAssert.NotAssignableFrom(d, typeof(Dog)));
    }

    [Theory]
    [InlineData(new object[] { 1, 2, 3 }, 3)]
    public void Contains_Success(IEnumerable<object> actual, object expected)
    {
        DbAssert.Contains(actual, expected);
    }

    [Theory]
    [InlineData(new object[] { 1, 2, 3 }, 4)]
    public void Contains_Failure(IEnumerable<object> actual, object expected)
    {
        Assert.Throws<AssertionException>(() => DbAssert.Contains(actual, expected));
    }

    [Theory]
    [InlineData(new object[] { 1, 2, 3 }, 4)]
    public void NotContains_Success(IEnumerable<object> actual, object expected)
    {
        DbAssert.NotContains(actual, expected);
    }

    [Theory]
    [InlineData(new object[] { 1, 2, 3 }, 3)]
    public void NotContains_Failure(IEnumerable<object> actual, object expected)
    {
        Assert.Throws<AssertionException>(() => DbAssert.NotContains(actual, expected));
    }

}