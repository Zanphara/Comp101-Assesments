using NUnit.Framework;
using Worksheet_2;

namespace Worksheet2_Tests;

[TestFixture]
public class VectorLogic
{
    private const float delta = 0.000001F;
    
    [Test]
    public void CheckVectorAdd()
    {
        float[] v1 = {0.0F, 0.0F};
        float[] v2 = {0.0F, 0.0F};
        float[] expected = {0.0F, 0.0F};

        float[] result = Program.addVectors(v1, v2);
        
        Assert.AreEqual(2, result.Length);
        Assert.AreEqual(expected[0], result[0], delta);
        Assert.AreEqual(expected[1], result[1], delta);
    }
    
    [Test]
    public void CheckVectorAddUp()
    {
        float[] v1 = {1.0F, 0.0F};
        float[] v2 = {5.0F, 0.0F};
        float[] expected = {6.0F, 0.0F};

        float[] result = Program.addVectors(v1, v2);
        
        Assert.AreEqual(2, result.Length);
        Assert.AreEqual(expected[0], result[0], delta);
        Assert.AreEqual(expected[1], result[1], delta);
    }
    
    [Test]
    public void CheckVectorAddRight()
    {
        float[] v1 = {0.0F, 6.0F};
        float[] v2 = {0.0F, 2.0F};
        float[] expected = {0.0F, 8.0F};

        float[] result = Program.addVectors(v1, v2);
        
        Assert.AreEqual(2, result.Length);
        Assert.AreEqual(expected[0], result[0], delta);
        Assert.AreEqual(expected[1], result[1], delta);
    }
    
    [Test]
    public void CheckVectorSub()
    {
        float[] v1 = {0.0F, 0.0F};
        float[] v2 = {0.0F, 0.0F};
        float[] expected = {0.0F, 0.0F};

        float[] result = Program.subVectors(v1, v2);
        
        Assert.AreEqual(2, result.Length);
        Assert.AreEqual(expected[0], result[0], delta);
        Assert.AreEqual(expected[1], result[1], delta);
    }
    
    [Test]
    public void CheckVectorSubUp()
    {
        float[] v1 = {1.0F, 0.0F};
        float[] v2 = {5.0F, 0.0F};
        float[] expected = {-4.0F, 0.0F};

        float[] result = Program.subVectors(v1, v2);
        
        Assert.AreEqual(2, result.Length);
        Assert.AreEqual(expected[0], result[0], delta);
        Assert.AreEqual(expected[1], result[1], delta);
    }
    
    [Test]
    public void CheckVectorSubRight()
    {
        float[] v1 = {0.0F, 6.0F};
        float[] v2 = {0.0F, 2.0F};
        float[] expected = {0.0F, 4.0F};

        float[] result = Program.subVectors(v1, v2);
        
        Assert.AreEqual(2, result.Length);
        Assert.AreEqual(expected[0], result[0], delta);
        Assert.AreEqual(expected[1], result[1], delta);
    }
    
    [Test]
    public void CheckLengthTriple()
    {
        float[] v1 = {3.0F, 4.0F};
        float expected = 5.0F;
        float result = Program.lengthVector(v1);
        
        Assert.AreEqual( expected, result, delta);
    }
    
    [Test]
    public void CheckLengthTripleNeg()
    {
        float[] v1 = {5.0F, -12.0F};
        float expected = 13.0F;
        float result = Program.lengthVector(v1);
        
        Assert.AreEqual( expected, result, delta );
    }
    
}