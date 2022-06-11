namespace Dbarone.Net.Assertions.Tests;
using DbAssert = Dbarone.Net.Assertions.Assert;
using System;
using Xunit;

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
    [InlineData((1 != 2))]
    public void True_Success(bool expr)
    {
        DbAssert.True(expr);
    }

    [Theory]
    [InlineData((1 == 2))]
    [InlineData((1 != 1))]
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

}