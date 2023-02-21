using System.ComponentModel.DataAnnotations;
using DesignPatternExamples.Builder.NestedBuilder;
using DesignPatternExamples.Builder.StepBuilder;
using FluentAssertions;
using Xunit;

namespace DesignPatternsExamples.Tests;

public class BuilderTests
{
    [Fact]
    public void Create_Url()
    {
        //nested builder
        var url = new MyUrlBuilder()
            .WithScheme("https")
            .WithHost("google.com")
            .WithPort("8080")
            .WithQueryParams(builder => builder
                .WithParams("page", "10"))
            .Build();

        url.Should().Be("https://google.com?page=10");
    }

    [Fact]
    public void Create_Merchant()
    {
        //step builder
        var legalMerchant = MerchantBuilder
            .New()
            .Legal()
            .WithCompany("google")
            .WithCompanyRegistrationNumber("11105")
            .Build();

        legalMerchant.Should().NotBeNull();
        legalMerchant.Company.Should().Be("google");

        var individualMerchant = MerchantBuilder
            .New()
            .Individual()
            .WithName("jack")
            .WithNationalCode("120008563")
            .Build();

        individualMerchant.Should().NotBeNull();
        individualMerchant.Name.Should().Be("jack");

    }
}