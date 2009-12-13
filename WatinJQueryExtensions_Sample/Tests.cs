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
                var startElement = browser.ElementsOfType<Form>()[0];


                //var results = startElement.CssSelectAll("table input.lst");
                var inputBox = startElement.CssSelect("table input[title='Google Search']") as TextField;
                var buttons = startElement.CssSelectAll("input.lsb").ToList();


                Assert.IsNotNull(inputBox);
                Assert.AreEqual(2, buttons.Count());

                inputBox.TypeText("Chuck Norris");
                buttons[0].Click();
                

            }
        }

     

    }
}
