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
        private static readonly WatiNElementOperators _ops = new WatiNElementOperators();
        
        #region Public CssSelector Extensions
        
        public static Element CssSelect(this Document doc, string selector)
        {
            return doc.Elements.CompileAndCssSelect(selector);
        }

        public static IEnumerable<Element> CssSelectAll(this Document doc, string selector)
        {
            return doc.Elements.CompileAndSelectAll(selector);
        }

        public static Element CssSelect(this Element node, string selector)
        {
            return node.CssSelectAll(selector).FirstOrDefault();
        }
       
        public static IEnumerable<Element> CssSelectAll(this Element node, string selector)
        {
            return CssSelectAll(node, selector);
        }
        
        #endregion
   
        #region Compiler & private Select helpers

        private static IEnumerable<Element> CompileAndSelectAll(this IEnumerable<Element> nodes, string selector)
        {
            return CompileForElements(selector)(nodes);
        }

        private static Element CompileAndCssSelect(this IEnumerable<Element> nodes, string selector)
        {
            return CompileForElements(selector)(nodes).FirstOrDefault();
        }


        private static Func<Element, IEnumerable<Element>> CompileForElement(string selector)
        {
            var compiled = Parser.Parse(selector, new SelectorGenerator<Element>(_ops)).Selector;
            return node => compiled(Enumerable.Repeat(node, 1));
        }

        private static Func<IEnumerable<Element>, IEnumerable<Element>> CompileForElements(string selector)
        {
            var compiled = Parser.Parse(selector, new SelectorGenerator<Element>(_ops)).Selector;
            return nodes => compiled(nodes); 
            
        }
        

        #endregion

        #region Supporting Extensions (internal and/or private)

        internal static IEnumerable<Element> Children(this Component e)
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

        internal static IEnumerable<Element> Descendents(this Component e)
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

        internal static IEnumerable<Element> ElementsAfterSelf(this Element node)
        {
            if (node == null) throw new ArgumentNullException("node");

            return node.NodesAfterSelf();
        }

        internal static IEnumerable<Element> NodesAfterSelf(this Element node)
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
        
        #endregion
    }
}
