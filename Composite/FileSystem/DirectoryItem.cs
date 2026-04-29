namespace Composite.FileSystem;

public class DirectoryItem : IFileSystemItem
{
    private readonly string _name;
    private IList<IFileSystemItem> _items = new List<IFileSystemItem>();

    public DirectoryItem(string name)
    {
        _name = name;
    }
    
    public void Add(IFileSystemItem item) => _items.Add(item);    

    public string GetName() => _name;

    public long GetSize() => _items.Sum(item => item.GetSize());

    public void Display(int indent = 0)
    {
        Console.WriteLine($"{new string(' ', indent)}/{_name}");
        foreach (var item in _items)
            item.Display(indent + 2);
    }
}