namespace Composite.FileSystem;

public interface IFileSystemItem
{
    string GetName();
    long GetSize();
    void Display(int indent = 0);
}