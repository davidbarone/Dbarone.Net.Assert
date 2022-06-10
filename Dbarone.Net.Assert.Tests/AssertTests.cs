namespace Dbarone.Net.Assert.Tests;
using DbAssert = Dbarone.Net.Assert.Assert;
using Xunit;


public class AssertTests
{
    [Fact]
    public void Equal()
    {
        var foo = 10;
        DbAssert.Equals(foo, 10);
    }

    [Fact]
    public void Assert_True()
    {
        string var1 = "foo";
        string var2 = "foo";
        DbAssert.True(var1 == var2);
    }

    [Fact]
    public void Assert_Flags()
    {
        var myFlag = FlagsEnum.bar | FlagsEnum.baz;
        DbAssert.Flag(myFlag, FlagsEnum.bar);
        Assert.Throws<AssertionException>(() => DbAssert.Flag(myFlag, FlagsEnum.other));
    }

    [Fact]
    public void Assert_NotFlags()
    {
        var myFlag = FlagsEnum.bar | FlagsEnum.baz;
        DbAssert.NotFlag(myFlag, FlagsEnum.other);
        Assert.Throws<AssertionException>(() => DbAssert.NotFlag(myFlag, FlagsEnum.bar));
    }    
}