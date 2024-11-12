using NUnit.Framework;
using Worksheet_2;

namespace Worksheet2_Tests;

[TestFixture]
public class ChallengeMiddleHex
{
    [Test]
    public void CheckLower()
    {
        string input = "0xFF00";
        int expected = 255;

        int result = Program.ChallengeMiddleEndianHex(input);
        Assert.AreEqual(expected, result);
    }
    
    [Test]
    public void CheckUpper()
    {
        string input = "0x00FF";
        int expected = 65280;

        int result = Program.ChallengeMiddleEndianHex(input);
        Assert.AreEqual(expected, result);
    }
    
    [Test]
    public void CheckMiddle()
    {
        string input = "0x0FF0";
        int expected = 61455; // in 'proper' hex, this is 0xF00F

        int result = Program.ChallengeMiddleEndianHex(input);
        Assert.AreEqual(expected, result);
    }
    
    [Test]
    public void CheckWord()
    {
        string input = "0xCAFE";
        int expected = 65226; // in 'proper' hex, this is 0xFECA

        int result = Program.ChallengeMiddleEndianHex(input);
        Assert.AreEqual(expected, result);
    }
    
    [Test]
    public void CheckTooBig()
    {
        string input = "0xABABAB";
        int expected = 0; // not 2 pairs or hex digits

        int result = Program.ChallengeMiddleEndianHex(input);
        Assert.AreEqual(expected, result);
    }
    
    [Test]
    public void CheckTooSmall()
    {
        string input = "0xAB";
        int expected = 0; // not 2 pairs or hex digits

        int result = Program.ChallengeMiddleEndianHex(input);
        Assert.AreEqual(expected, result);
    }
    
    [Test]
    public void CheckNotHex()
    {
        string input = "0xCOMP";
        int expected = 0; // M and P are not valid hex

        int result = Program.ChallengeMiddleEndianHex(input);
        Assert.AreEqual(expected, result);
    }
    [Test]
    public void CheckEmpty()
    {
        string input = "";
        int expected = 0; 
        int result = Program.ChallengeMiddleEndianHex(input);
        Assert.AreEqual(expected, result);
    }
    [Test]
    public void CheckLetterCase()
    {
        string input = "0xfF3c";
        int expected = 15615; // in normal hex this is 0x3cfF

        int result = Program.ChallengeMiddleEndianHex(input);
        Assert.AreEqual(expected, result);
    }
    [Test]
    public void CheckMissingPrefix()
    {
        string input = "ff00";
        int expected = 0;

        int result = Program.ChallengeMiddleEndianHex(input);
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void CheckOnlyPrefix()
    {
        string input = "0x";
        int expected = 0;

        int result = Program.ChallengeMiddleEndianHex(input);
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void CheckMaxHex()
    {
        string input = "0xff7fffff";
        int expected = int.MaxValue;

        int result = Program.ChallengeMiddleEndianHex(input);
        Assert.AreEqual(expected, result);
    }
    [Test]
    public void CheckWrapAround_1()
    {
        string input = "0x00800000"; // Would be 0x80000000 in normal hex
        int expected = 1;

        int result = Program.ChallengeMiddleEndianHex(input);
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void CheckWrapAround_2()
    {
        string input = "0x00800100"; // Would be 0x80000001 in normal hex
        int expected = 2;

        int result = Program.ChallengeMiddleEndianHex(input);
        Assert.AreEqual(expected, result);
    }
    [Test]
    public void CheckWrapAround_3()
    {
        string input = "0x00800200"; // Would be 0x80000002 in normal hex
        int expected = 3;

        int result = Program.ChallengeMiddleEndianHex(input);
        Assert.AreEqual(expected, result);
    }
    [Test]
    public void CheckWrapAround_4()
    {
        string input = "0x00801900"; // Would be 0x80000019 in normal hex
        int expected = 26;

        int result = Program.ChallengeMiddleEndianHex(input);
        Assert.AreEqual(expected, result);
    }
    [Test]
    public void CheckWrapAround_5()
    {
        string input = "0x0080FF00";// Would be 0x800000FF in normal hex
        int expected = 256;

        int result = Program.ChallengeMiddleEndianHex(input);
        Assert.AreEqual(expected, result);
    }
    [Test]
    public void CheckDoubleWrapAround_1()
    {
        string input = "0xFFFFFFFE";// Would be 0xFFFFFEFF in normal hex
        int expected = 2147483392;

        int result = Program.ChallengeMiddleEndianHex(input);
        Assert.AreEqual(expected, result);
    }
    [Test]
    public void CheckDoubleWrapAround_2()
    {
        string input = "0xFFFFFEFF";// Would be 0xFFFFFFFE in normal hex
        int expected = int.MaxValue;

        int result = Program.ChallengeMiddleEndianHex(input);
        Assert.AreEqual(expected, result);
    }
    [Test]
    public void CheckDoubleWrapAround_3()
    {
        string input = "0xFFFFFFFF";// Would be 0xFFFFFFFF in normal hex
        int expected = 1;

        int result = Program.ChallengeMiddleEndianHex(input);
        Assert.AreEqual(expected, result);
    }
    [Test]
    public void CheckDoubleWrapAround_4()
    {
        string input = "0xFFFFFFFFFFFF";// Would be 0xFFFFFFFFFFFF in normal hex
        int expected = 131071;

        int result = Program.ChallengeMiddleEndianHex(input);
        Assert.AreEqual(expected, result);
    }
}