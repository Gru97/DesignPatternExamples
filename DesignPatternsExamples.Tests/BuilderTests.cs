using DesignPatternExamples.Builder.SimpleBuilder;
using FluentAssertions;
using Xunit;

namespace DesignPatternsExamples.Tests;

public class BuilderTests
{
    [Fact]
    public void Get_Size_Of_A_File_System_Item()
    {
        var url = new MyUrlBuilder()
            .WithScheme("https")
            .WithHost("google.com")
            .WithPort("8080")
            .WithQueryParams(builder => builder
                .WithParams("page", "10"))
            .Build();

        url.Should().Be("https://google.com?page=10");
    }
}