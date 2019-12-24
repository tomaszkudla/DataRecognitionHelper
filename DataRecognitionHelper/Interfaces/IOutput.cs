namespace DataRecognitionHelper.Interfaces
{
    public interface IOutput
    {
        string Name { get; }
        string GetOutput(byte[] bytes);
    }
}
