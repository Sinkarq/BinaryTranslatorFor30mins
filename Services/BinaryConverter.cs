using System.Text;

namespace BinaryTranslator.Services;

public class BinaryConverter : IBinaryConverter
{
    public string StringToBinary(string data)
    {
        var sb = new StringBuilder();

        foreach (var c in data)
        {
            sb.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
        }

        return sb.ToString();
    }

    public string BinaryToString(string data)
    {
        var byteList = new List<byte>();
 
        for (var i = 0; i < data.Length; i += 8)
        {
            byteList.Add(Convert.ToByte(data.Substring(i, 8), 2));
        }
        return Encoding.ASCII.GetString(byteList.ToArray());
    }

    public bool IsBinary(string data)
    {
        var result = true;
        
        for (var i = 0; i < data.Length; i++)
        {
            if (data[i] != '1' && data[i] != '0')
            {
                result = false;
            }
        }

        return result;
    }
}