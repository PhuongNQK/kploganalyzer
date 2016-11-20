namespace Kp.Tools.LogAnalyzer.Common
{
    public interface IStringSource
    {
        string Name { get; set; }

        string GetLine();
    }
}