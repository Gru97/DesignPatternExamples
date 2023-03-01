using Directory = DesignPatternExamples.Composite.Directory;
using File = DesignPatternExamples.Composite.File;

namespace DesignPatternExamples.Visitor
{
    public interface IFileSystemVisitor
    {
        public void Visit(File file);
        public void Visit(Directory file);
    }
}
