using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using WatiN.Core;
using WatinJQueryExtensions;
using WatiN.Core.Constraints;


namespace WatinJQueryExtensions_Sample
{
    [TestFixture]
    public class jQueryExtensionsSampleTests
    {
        [Test]
        public void Test_01_NO_jQuery()
        {
            using (Browser browser = new IE("http://www.google.com"))
            {
                var searchText = browser.TextField(new AndConstraint(
                        Find.ByName("q"),
                        Find.ByExistenceOfRelatedElement<Element>(e => e.Ancestor<Form>())
                        ));

                var result = browser.Element(Find.ByValue(""));

                Assert.IsNotNull(searchText);
                Assert.IsTrue(searchText.Exists);

                searchText.TypeText("chuck norris");
            }
        }

        [Test]
        public void Test_02_WITH_jQuery()
        {
            using (Browser browser = new IE("http://www.google.com"))
            {
                

                var results = browser.Elements[0].CssSelect(".lst");
                //Assert.IsTrue(results.Count() > 0);
                //var searchText = browser.jQuery("form input[name=q]")[0] as TextField;

                //Assert.IsNotNull(searchText);
                //Assert.IsTrue(searchText.Exists);

                //searchText.TypeText("chuck norris");

            }
        }

     

    }
}
