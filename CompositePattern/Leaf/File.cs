using CompositePattern.Component;

namespace CompositePattern.Leaf;

public class File : FileSystemItem
{
    private readonly decimal _size;
    public File(string name, decimal size) : base(name)
    {
        _size = size;
    }

    public override decimal GetSize() => _size;
}