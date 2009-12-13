using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WatiN.Core;
using Fizzler;

namespace WatinJQueryExtensions
{
    public static class Extensions
    {
        private static readonly ElementOps _ops = new ElementOps();

        public static Element CssSelect(this Element node, string selector)
        {
            return node.CssSelectAll(selector).FirstOrDefault();
        }

        public static IEnumerable<Element> CssSelectAll(this Element node, string selector)
        {
            return CssSelectAll(node, selector, null);
        }

        public static IEnumerable<Element> CssSelectAll(this Element node, string selector, Func<string, Func<Element, IEnumerable<Element>>> compiler)
        {
            return (compiler ?? Compile)(selector)(node);
        }

        public static Func<Element, IEnumerable<Element>> Compile(string selector)
        {
            var compiled = Parser.Parse(selector, new SelectorGenerator<Element>(_ops)).Selector;
            return node => compiled(Enumerable.Repeat(node, 1));
        }


        /////////////////////////


        public static IEnumerable<Element> Descendents(this Element e)
        {
            return null;
            //return e.DomContainer.Element(Find.ByExistenceOfRelatedElement<Element>(node => node.Ancestor<Element>(ancestor => ancestor == e)));
        }



    }
}
