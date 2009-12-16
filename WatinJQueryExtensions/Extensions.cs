using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WatiN.Core;
using Fizzler;
using WatiN.Core.Constraints;
using WatiN.Core.Native;

namespace WatiNCssSelectorExtensions
{
    public static class Extensions
    {
        private static readonly ElementOps _ops = new ElementOps();

        public static Element CssSelect(this Document doc, string selector)
        {
            return doc.Elements.CssSelect(selector);
        }

        public static IEnumerable<Element> CssSelectAll(this Document doc, string selector)
        {
            return doc.Elements.CssSelectAll(selector);
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


            ////short version of the above
            //return (compiler ?? Compile)(selector)(node);

        }

        public static IEnumerable<Element> CssSelectAll(this IEnumerable<Element> nodes, string selector)
        {
            return Compile2(selector)(nodes);
        }

        public static Element CssSelect(this IEnumerable<Element> nodes, string selector)
        {
            return Compile2(selector)(nodes).FirstOrDefault();
        }

        public static Func<Element, IEnumerable<Element>> Compile(string selector)
        {
            var compiled = Parser.Parse(selector, new SelectorGenerator<Element>(_ops)).Selector;
            return node => compiled(Enumerable.Repeat(node, 1));
        }

        public static Func<IEnumerable<Element>, IEnumerable<Element>> Compile2(string selector)
        {
            var compiled = Parser.Parse(selector, new SelectorGenerator<Element>(_ops)).Selector;
            return node => {
                //Console.WriteLine("node check\n");
                return compiled(node); 
            };
        }

        /////////////////////////


        public static IEnumerable<Element> Children(this Component e)
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

        public static IEnumerable<Element> ElementsAfterSelf(this Element node)
        {
            if (node == null) throw new ArgumentNullException("node");
            return node.NodesAfterSelf();
        }

        public static IEnumerable<Element> NodesAfterSelf(this Element node)
        {
            if (node == null) throw new ArgumentNullException("node");
            return NodesAfterSelfImpl(node);

        }

        private static IEnumerable<Element> NodesAfterSelfImpl(Element node)
        {
            while ((node = node.NextSibling) != null)
            {
                yield return node;
            }
        }
       
    }
}
