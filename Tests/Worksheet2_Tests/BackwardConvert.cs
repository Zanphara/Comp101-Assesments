using NUnit.Framework;
using Worksheet_2;

namespace Worksheet2_Tests;

[TestFixture]
public class BackwardConvert
{

    [Test]
    public void CheckHexByte()
    {
        string input = "0xFF";
        int expected = 255;

        int result = Program.ConvertToInt(input);
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void CheckHexColour()
    {
        string input = "0xFF66CC";
        int expected = 16737996;

        int result = Program.ConvertToInt(input);
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void CheckHexLowerBound()
    {
        string input = "0x0";
        int expected = 0;

        int result = Program.ConvertToInt(input);
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void CheckHex250()
    {
        string input = "0xF2";
        int expected = 242;

        int result = Program.ConvertToInt(input);
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void CheckHexInvalid()
    {
        string input = "0xXXF0";
        int expected = -1;

        int result = Program.ConvertToInt(input);
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void CheckNotPrefixed()
    {
        string input = "FF";
        int expected = -1;

        int result = Program.ConvertToInt(input);
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void CheckRoundRobin()
    {
        for (int i = 0; i <= 255; i++)
        {
            string userHex = Program.ConvertToHex(i);
            int userValue = Program.ConvertToInt(userHex);
            Assert.AreEqual(userValue, i);
        }
    }

    [Test]
    public void CheckFullHexByte()
    {
        for (int i = 0; i <= 255; i++)
        {
            string userHex = Program.ConvertToHex(i);
            string expected = i.ToString("X");
            expected = "0x" + expected;

            Assert.AreEqual(expected, userHex);
        }
    }

    [Test]
    public void CheckOverFlowHex()
    {
        string input = "0x80000000";
        int expected = -1;

        int result = Program.ConvertToInt(input);
        Assert.AreEqual(expected, result);

    }
    [Test]
    public void CheckIntMaxValue()
    {
        string input = "0x7FFFFFFF";
        int expected = int.MaxValue;

        int result = Program.ConvertToInt(input);
        Assert.AreEqual(expected, result);

    }


    [Test]
    public void CheckOctalByte()
    {
        string input = "0o77";
        int expected = 63;

        int result = Program.ConvertToInt(input);
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void CheckOctalColour()
    {
        string input = "0o2524167";
        int expected = 698487;

        int result = Program.ConvertToInt(input);
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void CheckOctalLowerBound()
    {
        string input = "0o0";
        int expected = 0;

        int result = Program.ConvertToInt(input);
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void CheckOctal250()
    {
        string input = "0o362";
        int expected = 242;

        int result = Program.ConvertToInt(input);
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void CheckOctalInvalid()
    {
        string input = "0oXXF0";
        int expected = -1;

        int result = Program.ConvertToInt(input);
        Assert.AreEqual(expected, result);
    }

}