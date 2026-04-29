namespace Composite.FileSystem;

public class FileItem : IFileSystemItem
{
    private readonly string _name;
    private readonly long _size;

    public FileItem(string name, long size)
    {
        _name = name;
        _size = size;
    }
    
    public string GetName() => _name;

    public long GetSize() => _size;

    public void Display(int indent = 0) => Console.WriteLine($"{new string(' ', indent)}{_name} ({_size} bytes)");
}