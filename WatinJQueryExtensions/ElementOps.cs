using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WatiN.Core;
using Fizzler;

namespace WatiNCssSelectorExtensions
{
    public class ElementOps : IElementOps<Element>
    {
        #region IElementOps<Element> Members

        public Selector<Element> Adjacent()
        {
            return nodes => nodes.SelectMany(n => n.ElementsAfterSelf().Take(1));
        }

        public Selector<Element> AttributeDashMatch(NamespacePrefix prefix, string name, string value)
        {
            throw new NotImplementedException();
        }

        public Selector<Element> AttributeExact(NamespacePrefix prefix, string name, string value)
        {
            return prefix.IsSpecific
                         ? (Selector<Element>)(nodes => Enumerable.Empty<Element>())
                         : (nodes => from n in nodes
                                     where n.GetAttributeValue(name) == value
                                     select n);
        }

        public Selector<Element> AttributeExists(NamespacePrefix prefix, string name)
        {
            return prefix.IsSpecific
                         ? (Selector<Element>)(nodes => Enumerable.Empty<Element>())
                         : (nodes => from n in nodes
                                     where n.GetAttributeValue(name) != null
                                     select n);
        }

        public Selector<Element> AttributeIncludes(NamespacePrefix prefix, string name, string value)
        {
            return prefix.IsSpecific
                         ? (Selector<Element>)(nodes => Enumerable.Empty<Element>())
                         : (nodes => from n in nodes
                                     where n.GetAttributeValue(name).Split(' ').Contains(value)
                                     select n);
        }

        public Selector<Element> AttributePrefixMatch(NamespacePrefix prefix, string name, string value)
        {
            return prefix.IsSpecific
                         ? (Selector<Element>)(nodes => Enumerable.Empty<Element>())
                         : (nodes => from n in nodes
                                     where n.GetAttributeValue(name).StartsWith(value)
                                     select n);
        }

        public Selector<Element> AttributeSubstring(NamespacePrefix prefix, string name, string value)
        {
            throw new NotImplementedException();
        }

        public Selector<Element> AttributeSuffixMatch(NamespacePrefix prefix, string name, string value)
        {
            return prefix.IsSpecific
                         ? (Selector<Element>)(nodes => Enumerable.Empty<Element>())
                         : (nodes => from n in nodes
                                     where n.GetAttributeValue(name).EndsWith(value)
                                     select n);
        }

        public Selector<Element> Child()
        {
            //?? does does Children() really return immediate children???
            return nodes => nodes.SelectMany(n => n.Children());
        }

        public Selector<Element> Class(string className)
        {
            return node => 
                {
                    return node.Where(e =>
                        {
                            return (e.ClassName ?? "").ToLower() == className.ToLower();
                        });
                };
        }

        public Selector<Element> Descendant()
        {
            return node => node.SelectMany(n => n.Descendents());
        }

        public Selector<Element> Empty()
        {
            return nodes => nodes.Where(n => n.Descendents().Count() == 0);
        }

        public Selector<Element> FirstChild()
        {
            throw new NotImplementedException();
        }

        public Selector<Element> GeneralSibling()
        {
            throw new NotImplementedException();
        }

        public Selector<Element> Id(string id)
        {
            return node => node.Where(n => {
                if (n.Id == null) { return false; }
                
                return n.Id.ToUpper() == id.ToUpper();
            });
        }

        public Selector<Element> LastChild()
        {
            throw new NotImplementedException();
        }

        public Selector<Element> NthChild(int a, int b)
        {
            throw new NotImplementedException();
        }

        public Selector<Element> OnlyChild()
        {
            throw new NotImplementedException();
        }

        public Selector<Element> Type(NamespacePrefix prefix, string name)
        {
            return prefix.IsSpecific ? 
                (Selector<Element>)(nodes => Enumerable.Empty<Element>())
                : (Selector<Element>)(nodes => nodes.Where(n => n.TagName.ToUpper() == name.ToUpper()));
        }

        public Selector<Element> Universal(NamespacePrefix prefix)
        {
            return  prefix.IsSpecific
                ? (Selector<Element>)(nodes => Enumerable.Empty<Element>())
                : (Selector<Element>)(nodes => nodes);
        }

        #endregion
    }
}
