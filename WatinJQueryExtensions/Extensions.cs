using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WatiN.Core;
using Fizzler;
using WatiN.Core.Constraints;
using WatiN.Core.Native;

namespace WatinJQueryExtensions
{
    public static class Extensions
    {
        private static readonly ElementOps _ops = new ElementOps();

        public static Element CssSelect(this Document doc, string selector)
        {            
            return doc.Elements.FirstOrDefault();
        }

        public static IEnumerable<Element> CssSelectAll(this Document doc, string selector)
        {
            return doc.Elements;
        }

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
            Func<Element, IEnumerable<Element>> selectorFunction = null;
            if (compiler == null)
            {
                selectorFunction = Compile(selector);
            }
            else
            {
                selectorFunction = compiler(selector);
            }
            return selectorFunction(node);


            ////short version of above
            //return (compiler ?? Compile)(selector)(node);

        }

        public static Func<Element, IEnumerable<Element>> Compile(string selector)
        {
            var compiled = Parser.Parse(selector, new SelectorGenerator<Element>(_ops)).Selector;
            return node => compiled(Enumerable.Repeat(node, 1));
        }


        /////////////////////////


        public static IEnumerable<Element> Descendents(this Element e)
        {
            if (e is IElementContainer)
            {
                var container = e as IElementContainer;
                return container.Elements;
            }
            else
            {
                return Enumerable.Empty<Element>();
            }
         
        }
        public static IEnumerable<Element> Descendents(this Component e)
        {
            if (e is IElementContainer)
            {
                var container = e as IElementContainer;
                
                return container.Elements;
            }
            else
            {
                return Enumerable.Empty<Element>();
            }
         
        }


   
    }
}
