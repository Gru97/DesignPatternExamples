using DesignPatternExamples.Visitor;
using FluentAssertions;
using Xunit;
using Directory = DesignPatternExamples.Composite.Directory;
using File = DesignPatternExamples.Composite.File;

namespace DesignPatternsExamples.Tests;

public class VisitorTests
{
    [Fact]
    public void Get_Max_FileSystemItem()
    {
        var file1 = new File(10);
        var file2 = new File(20);
        var file3 = new File(30);

        var directory = new Directory(file1, file2, new Directory(file3));

        var visitor = new MaxSizeVisitor();
        directory.Accept(visitor);
        var x= visitor.GetMaxSize();
        x.Size().Should().Be(30);
    }
}