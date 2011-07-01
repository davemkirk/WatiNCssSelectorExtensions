using NUnit.Framework;
using WatiN.Core;
using WatiN.Core.Constraints;

namespace WatiN.CssSelectorExtensions.Tests
{
    [TestFixture]
    public class DemoTests
    {
        [Test]
        public void Test_01_NO_CssSelectors()
        {
            using (Browser browser = new IE("http://www.google.com"))
            {
                var searchText = browser.TextField(new AndConstraint(
                        Find.ByName("q"),
                        Find.ByExistenceOfRelatedElement<Element>
                                (e => e.Ancestor<Form>(Find.By("action", "/search")))
                        ));

                Assert.IsNotNull(searchText);
                Assert.IsTrue(searchText.Exists);

                var button = browser.Button(Find.ByClass("lsb"));

                

                searchText.TypeText("watin");
                button.Click();

                browser.WaitUntilContainsText("pronounced as What-in", 5);
            }
        }
    }
}
