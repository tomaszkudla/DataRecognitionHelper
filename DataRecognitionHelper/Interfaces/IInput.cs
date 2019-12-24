namespace DataRecognitionHelper.Interfaces
{
    public interface IInput
    {
        string Name { get; }
        byte[] GetBytes(string input);
        bool IsApplicable(string input);
    }
}
