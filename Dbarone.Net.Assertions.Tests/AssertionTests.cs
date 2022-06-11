namespace Dbarone.Net.Assertions.Tests;
using DbAssert = Dbarone.Net.Assertions.Assert;
using Xunit;

public class AssertionTests
{
    [Theory]
    [InlineData(10,10)]
    [InlineData(true,true)]
    [InlineData("ABC","ABC")]
    public void Equal_Success(object actual, object expected)
    {
        DbAssert.Equals(actual, expected);
    }
    
    [Theory]
    [InlineData(null,null)]
    [InlineData(10,null)]
    [InlineData(null,10)]
    [InlineData(10,9)]
    [InlineData(true,false)]
    [InlineData("ABC","ABCD")]
    public void Equal_Failure(object actual, object expected){
        Assert.Throws<AssertionException>(() => DbAssert.Equals(actual, expected));
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