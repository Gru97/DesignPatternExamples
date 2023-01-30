using DesignPatternExamples.Composite;
using Xunit;
using Directory = DesignPatternExamples.Composite.Directory;
using File = DesignPatternExamples.Composite.File;

namespace DesignPatternsExamples.Tests
{
    public class Tests
    {
        [Fact]
        public void Get_Size_Of_A_File_System_Item()
        {
            var file1 = new File(10);
            var file2 = new File(20);
            var file3 = new File(30);

            var directory = new Directory(file1, file2);
            
            directory.Size();
            file1.Size();
        }
    }
}