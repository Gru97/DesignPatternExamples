using DesignPatternExamples.Composite;
using Directory = DesignPatternExamples.Composite.Directory;
using File = DesignPatternExamples.Composite.File;

namespace DesignPatternExamples.Visitor;

public class MaxSizeVisitor : IFileSystemVisitor
{
    private FileSystemItem _currentMax=new Directory(new File(0));
    public void Visit(File file)
    {
        if (file.Size() >= _currentMax.Size())
            _currentMax = file;
    }

    public void Visit(Directory directory)
    {
        foreach (var child in directory.Children)
        {
            child.Accept(this);
        }
          
    }

    public FileSystemItem GetMaxSize() => _currentMax;
}