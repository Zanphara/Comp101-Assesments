using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;
using System.Runtime.Intrinsics;
using System.Text;
using System.Text.RegularExpressions;

namespace Worksheet_2;

public class Program()
{
    public static void Main(string[] args)
    {
        //while (true) 
        //{
        //    Console.WriteLine("give an input");
        //    string? input = Console.ReadLine();
        //    ChallengeMiddleEndianHex(input);
        //}

        //while (true)
        //{
        //    Console.WriteLine("give an input");
        //    string? input = Console.ReadLine();
        //    ChallengeMiddleEndianHex(input);
        //}

    }

    /// <summary>
    /// Convert one 'ascii' character to hexadecimal 
    /// </summary>
    /// <param name="myValue">The value to convert</param>
    /// <returns>A value between 0-16 if valid, else -1</returns>
    public static int HexDigit(char c)
    {
        if (c >= '0' && c <= '9')
        {

            return c - '0';
        }
        else if (c >= 'A' && c <= 'F')
        {
            return c - 'A' + 10;
        }
        else if (c >= 'a' && c <= 'f')
        {
            return c - 'a' + 10;
        }
        else
        {
            return -1;
        }
    }

    /// <summary>
    /// Converts an integer to hexedecimal
    /// </summary>
    /// <param name="number"></param>
    /// <param name="Hex"></param>
    /// <returns>A valid Hex string prefixed with 0x else ERROR</returns>
    public static string ConvertToHex(int number)
    {
        if (number < 0) 
        {
            return "ERROR";
        }

        StringBuilder Hex = new StringBuilder();

        while (true)
        {
            int remainder = number % 16;
            number /= 16;
            if (remainder < 10)
            {
                Hex.Insert(0, remainder);
            }
            else if (remainder >= 10)
            {
                Hex.Insert(0, (char)(remainder - 10 + 'A'));
            }
            if (number <= 0)
            {
                return "0x" + Hex;
            }

        }

    }

    /// <summary>
    /// converts a valid hexadecimal to an integer
    /// </summary>
    /// <param name="Hex"></param>
    /// <returns>An int beloe int.maxvalue </returns>
    public static int ConvertToInt(string Hex = "")
    {
        if (string.IsNullOrWhiteSpace(Hex) || (Hex.Length < 3)) return -1;

        int baseValue = Hex.StartsWith("0x", StringComparison.OrdinalIgnoreCase) ? 16 :
                        Hex.StartsWith("0o", StringComparison.OrdinalIgnoreCase) ? 8 :
                                                                                  -1;
        if (baseValue == -1) return -1;

        Hex = Hex.Substring(2);
        if (!Regex.IsMatch(Hex, baseValue == 16 ? "^[0-9A-Fa-f]+$" : "^[0-7]+$")) return -1;


        int result = 0, multiplier = 1;
        for (int i = Hex.Length - 1; i >= 0; i--)
        {
            int digitValue = HexDigit(Hex[i]);
            try
            {
                checked  
                {
                    result += digitValue * multiplier;
                }
            }
            catch (OverflowException)
            {
                return -1;
            }
            multiplier *= baseValue;
        }
        return result;     
    }



    /// <summary>
    /// Convert a 'middle endian' hex value back to it's integer version.
    /// </summary>
    /// 
    /// <param name="hexString">the 'middle endian' hexadecimal value</param>
    /// <returns>The corresponding (base 10) integer, or 0 on error</returns>
    public static int ChallengeMiddleEndianHex(string hexString)
    {
        if (!Regex.IsMatch(hexString, @"^0x[0-9A-Fa-f]+$")) return 0;
        if (!hexString.ToLower().StartsWith("0x") || (hexString.Length - 2) % 4 != 0)
        {
            return 0;
        }
        hexString = hexString.Remove(0, 2);
        string newhexString = "";
        for (int i = 0; i < hexString.Length; i = i += 4)
        {
            string temp1 = hexString[i].ToString() + hexString[i + 1].ToString();
            string temp2 = hexString[i + 2].ToString() + hexString[i + 3].ToString();
            newhexString = newhexString + temp2 + temp1;
        }

        hexString = hexString.Substring(2);

        int result = 0, multiplier = 1, temp = 0;
        for (int i = newhexString.Length - 1; i >= 0; i--)
        {
            int digitValue = HexDigit(newhexString[i]);
            try
            {
                checked
                {
                    temp = result;
                    result = (result + digitValue * multiplier);

                    //result += digitValue * multiplier;
                }
            }
            catch (OverflowException)
            {
                result = temp + ((digitValue * multiplier) % int.MaxValue)+2;
            }
            multiplier *= 16;
        }

        return result;
    }



    /* VECTOR LOGIC BELOW */

    /// <summary>
    /// Takes 2 2d or 3d vectors and adds their components
    /// </summary>
    /// <param name="vec1"></param>
    /// <param name="vec2"></param>
    /// <returns>a float[] of equal length to the input else an empty array</returns>
    public static float[] addVectors(float[] vec1, float[] vec2)
    {
        if (vec1.Length != vec2.Length || (vec1.Length != 2 && vec1.Length != 3))
        {
            return new float[0];
        }

        float[] result = new float[vec1.Length];

        for (int i = 0; i < vec1.Length; i++)
        {
            result[i] = vec1[i] + vec2[i];
        }

        return result;
    }

    /// <summary>
    /// Takes 2 2d or 3d vectors and subtracts their components
    /// </summary>
    /// <param name="vec1"></param>
    /// <param name="vec2"></param>
    /// <returns>a float[] of equal length to the input else an empty array</returns>
    public static float[] subVectors(float[] vec1, float[] vec2)
    {
        if (vec1.Length != vec2.Length || (vec1.Length != 2 && vec1.Length != 3))
        {
            return new float[0];
        }

        float[] result = new float[vec1.Length];

        for (int i = 0; i < vec1.Length; i++)
        {
            result[i] = vec1[i] - vec2[i];
        }

        return result;
    }

    /// <summary>
    /// takes a single 2d or 3d vector and finds its length
    /// </summary>
    /// <param name="vec"></param>
    /// <returns>a float equal to the length of the vector</returns>
    public static float lengthVector(float[] vec)
    {
        if (vec.Length != 2 && vec.Length != 3)
        {
            return 0.0F; 
        }

        float sumOfSquares = 0.0F;

        for (int i = 0; i < vec.Length; i++)
        {
            sumOfSquares += MathF.Pow(vec[i], 2);
        }

        return MathF.Sqrt(sumOfSquares);
    }

    /// <summary>
    /// Takes 2 2d or 3d vectors and caclulates the distance between them
    /// </summary>
    /// <param name="vec1"></param>
    /// <param name="vec2"></param>
    /// <returns>a float equal to the distance between the vectors<</returns>
    public static float vectorDistance(float[] vec1, float[] vec2)
    {
        if (vec1.Length != vec2.Length || (vec1.Length != 2 && vec1.Length != 3))
        {
            return 0.0F;
        }

        float sumOfSquares = 0.0F;

        for (int i = 0; i < vec1.Length; i++)
        {
            float difference = vec2[i] - vec1[i];
            sumOfSquares += MathF.Pow(difference, 2);
        }
        
        return MathF.Sqrt(sumOfSquares);
    }

}