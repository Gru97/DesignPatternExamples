using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternExamples.Composite
{
    public abstract class FileSystemItem  //component
    {
        public abstract long Size();
    }

    public class File: FileSystemItem  //leaf
    {
        private readonly long _size;
        public override long Size() => _size;
        public File(long size)
        {
            _size = size;
        }
    }

    public class Directory: FileSystemItem  //composite
    {
        private List<File> Children { get; set; }
        public Directory(params File[] children)
        {
            Children = children.ToList();
        }

        public override long Size() => Children.Sum(e => e.Size());
        
    }
}
