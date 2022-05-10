namespace BinaryTranslator.Services;

public interface IBinaryConverter
{
    string StringToBinary(string data);

    string BinaryToString(string data);

    bool IsBinary(string data);
}