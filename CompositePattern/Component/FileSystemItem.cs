namespace CompositePattern.Component;

/// <summary>
/// 抽象组件：文件系统项
/// </summary>
public abstract class FileSystemItem
{
    public string Name { get; }
    
    protected FileSystemItem(string name)
    {
        Name = name;
    }

    /// <summary>
    /// 公共操作：获取大小（叶子节点和组合节点都要实现）
    /// </summary>
    /// <returns></returns>
    public abstract decimal GetSize();

    /// <summary>
    /// 公共操作：添加子项（组合节点才需要实现）
    /// </summary>
    /// <param name="item"></param>
    /// <exception cref="NotSupportedException"></exception>
    public virtual void Add(FileSystemItem item) => throw new NotSupportedException();
    
    /// <summary>
    /// 公共操作：移除子项（组合节点才需要实现）
    /// </summary>
    /// <param name="item"></param>
    /// <exception cref="NotSupportedException"></exception>
    public virtual void Remove(FileSystemItem item) => throw new NotSupportedException();
}