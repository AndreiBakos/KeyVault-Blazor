using AngleSharp.Dom;
using Bunit;
using KeyVault.Pages;
using Xunit;
namespace KeyVault.Tests;

public class BasicTest
{

    [Fact]
    public void main_app_header_loaded()
    {
        using var testContext = new TestContext();
        // given
         var testComponent = testContext.RenderComponent<TestComponent>();
         var expectedHeader = "TestComponent";

        //when
        var mainHeader = testComponent.Find($"#testHeader:contains('{expectedHeader}')");

        //then
        Assert.Equal(expectedHeader, mainHeader.Text());
    }
}