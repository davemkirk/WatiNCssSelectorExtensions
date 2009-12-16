using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using WatiN.Core;
using WatiNCssSelectorExtensions;
using WatiN.Core.Constraints;

namespace WatinCssSelectorExtensions_Sample
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

        [Test]
        public void Test_02_WITH_CssSelectors()
        {
            using (Browser browser = new IE("http://www.google.com"))
            {
               

            }
        }




















        //[Test]
        //public void Test_03_WITH_CssSelectors()
        //{
        //    using (Browser browser = new IE("http://www.google.com"))
        //    {
        //        var inputBox = browser.CssSelect("form[action='/search'] input[title='Google Search']") as TextField;
        //        var buttons = browser.CssSelectAll("input.lsb").ToList();
        //        var titled = browser.CssSelectAll("*[title]");

        //        Assert.IsNotNull(inputBox);
        //        Assert.AreEqual(2, buttons.Count());

        //        inputBox.TypeText("Chuck Norris");
        //        buttons[0].Click();
        //    }
        //}

        //[Test]
        //public void Test_04_WITH_CssSelectors()
        //{
        //    using (Browser browser = new IE("http://watin.sourceforge.net/"))
        //    {
        //        var main = browser.Div(Find.ById("main"));

        //        Assert.IsNotNull(main);
        //        //Assert.AreEqual(1, main.Count());

        //        var blockquotes = main.CssSelectAll("blockquote");
        //        Assert.AreEqual(5, blockquotes.Count());
        //    }
        //}

    }

    [TestFixture]
    public class CssSelectorTests
    { 
        [Test]
        public void Test_01_UniversalSelectors()
        {
            using (Browser browser = new IE("http://watin.sourceforge.net/"))
            {
                var main = browser.CssSelect("#main");
                var universalMain = browser.CssSelect("*#main");

                Assert.IsNotNull(main);
                Assert.IsNotNull(universalMain);

                Assert.AreEqual(main.TagName, universalMain.TagName);
                Assert.AreEqual(main.ClassName, universalMain.ClassName);
            }
        }

        [Test]
        public void Test_02_AdjacentSiblingSelectors()
        {
            using (Browser browser = new IE("http://watin.sourceforge.net/"))
            {

                var rightBar = browser.CssSelect("#main + #rightbar");
                Assert.IsNotNull(rightBar);

                var noRightBar = browser.CssSelect("#badMain + #rightbar");
                Assert.IsNull(noRightBar);
            }

        }

        [Test]
        public void Test_02_WITH_CssSelectors()
        {
            using (Browser browser = new IE("http://www.google.com"))
            {
                //var startElement = browser.ElementsOfType<Form>()[0];
                var startElement = browser.Span(Find.ById("main"));
                startElement.WaitUntilExists(5);

                //var results = startElement.CssSelectAll("table input.lst");
                var inputBox = startElement.CssSelect("table input[title='Google Search']") as TextField;
                var buttons = startElement.CssSelectAll("input.lsb").ToList();


                //var main = startElement.CssSelectAll("#body");
                //Assert.IsTrue(main != null);
                //Assert.IsTrue(main.Exists);

                Assert.IsNotNull(inputBox);
                Assert.AreEqual(2, buttons.Count());

                inputBox.TypeText("Chuck Norris");
                buttons[0].Click();


            }
        }

    }
    
}
