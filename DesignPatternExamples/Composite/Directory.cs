using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatternExamples.Visitor;

namespace DesignPatternExamples.Composite
{
    public abstract class FileSystemItem  //component
    {
        public abstract long Size();
        public abstract  void Accept(IFileSystemVisitor visitor);
    }

    public class File: FileSystemItem  //leaf
    {
        private readonly long _size;
        public override long Size() => _size;
        public File(long size)
        {
            _size = size;
        }

        public override void Accept(IFileSystemVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class Directory: FileSystemItem  //composite
    {
        public List<FileSystemItem> Children { get; set; }
        public Directory(params FileSystemItem[] children)
        {
            Children = children.ToList();
        }

        public override long Size() => Children.Sum(e => e.Size());

        public override void Accept(IFileSystemVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
