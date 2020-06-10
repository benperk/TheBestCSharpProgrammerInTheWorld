using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    public string GenerateGuid()
    {
        string uniqueKey = Guid.NewGuid().ToString();
        return Guid.NewGuid().ToString();
    }

    public string GenerateSequentialGuidPanel()
    {
        return GenerateComb().ToString();
    }

    public static Guid GenerateComb()
    {
        byte[] destinationArray = Guid.NewGuid().ToByteArray();
        DateTime time = new DateTime(0x76c, 1, 1);
        DateTime now = DateTime.Now;

        // Get the days and milliseconds which will be used to build the byte string
        TimeSpan span = new TimeSpan(now.Ticks - time.Ticks);
        TimeSpan timeOfDay = now.TimeOfDay;

        // Convert to a byte array 
        // Note that SQL Server is accurate to 1/300th of a millisecond so we divide by 3.333333
        byte[] bytes = BitConverter.GetBytes(span.Days);
        byte[] array = BitConverter.GetBytes((long)(timeOfDay.TotalMilliseconds / 3.333333));

        // Reverse the bytes to match SQL Servers ordering 
        Array.Reverse(bytes);
        Array.Reverse(array);

        // Copy the bytes into the guid
        Array.Copy(bytes, bytes.Length - 2, destinationArray, destinationArray.Length - 6, 2);
        Array.Copy(array, array.Length - 4, destinationArray, destinationArray.Length - 4, 4);
        return new Guid(destinationArray);
    }
}