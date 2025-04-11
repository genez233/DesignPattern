using CompositePattern.Component;

namespace CompositePattern.Composite;

public class Folder : FileSystemItem
{
    private readonly List<FileSystemItem> _children = new();
    public Folder(string name) : base(name)
    {
    }

    public override void Add(FileSystemItem item)
    {
        _children.Add(item);
    }
    
    public override void Remove(FileSystemItem item)
    {
        _children.Remove(item);
    }

    public override decimal GetSize()
    {
        decimal totalSize = 0;
        _children.ForEach(it =>
        {
            totalSize += it.GetSize();
        });
        
        return totalSize;
    }
}