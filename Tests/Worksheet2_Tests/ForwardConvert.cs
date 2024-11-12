using NUnit.Framework;
using Worksheet_2;

namespace Worksheet2_Tests;

public class ForwardConvert
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void CheckHexNegativeBounds()
    {
        int input = -1;
        string expected = "ERROR";

        string result = Program.ConvertToHex(input);
        Assert.AreEqual(expected, result);
    }
    
    [Test]
    public void CheckHexUpperBounds()
    {
        int input = 256;
        string expected = "0x100";

        string result = Program.ConvertToHex(input);
        Assert.AreEqual(expected, result);
    }
    
    [Test]
    public void CheckHexUpperBound()
    {
        int input = 255;
        string expected = "0xFF";

        string result = Program.ConvertToHex(input);
        Assert.AreEqual(expected, result);
    }
    
    [Test]
    public void CheckHexLowerBound()
    {
        int input = 0;
        string expected = "0x0";

        string result = Program.ConvertToHex(input);
        Assert.AreEqual(expected, result);
    }
    
    [Test]
    public void CheckHexLowerNibble()
    {
        int input = 15;
        string expected = "0xF";

        string result = Program.ConvertToHex(input);
        Assert.AreEqual(expected, result);
    }
    
    [Test]
    public void CheckHexLUpperNibble()
    {
        int input = 240;
        string expected = "0xF0";

        string result = Program.ConvertToHex(input);
        Assert.AreEqual(expected, result);
    }
}