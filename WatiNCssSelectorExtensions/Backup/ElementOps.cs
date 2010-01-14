using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WatiN.Core;
using Fizzler;

namespace WatinJQueryExtensions
{
    public class ElementOps : IElementOps<Element>
    {
        #region IElementOps<Element> Members

        public Selector<Element> Adjacent()
        {
            throw new NotImplementedException();
        }

        public Selector<Element> AttributeDashMatch(NamespacePrefix prefix, string name, string value)
        {
            throw new NotImplementedException();
        }

        public Selector<Element> AttributeExact(NamespacePrefix prefix, string name, string value)
        {
            throw new NotImplementedException();
        }

        public Selector<Element> AttributeExists(NamespacePrefix prefix, string name)
        {
            throw new NotImplementedException();
        }

        public Selector<Element> AttributeIncludes(NamespacePrefix prefix, string name, string value)
        {
            throw new NotImplementedException();
        }

        public Selector<Element> AttributePrefixMatch(NamespacePrefix prefix, string name, string value)
        {
            throw new NotImplementedException();
        }

        public Selector<Element> AttributeSubstring(NamespacePrefix prefix, string name, string value)
        {
            throw new NotImplementedException();
        }

        public Selector<Element> AttributeSuffixMatch(NamespacePrefix prefix, string name, string value)
        {
            throw new NotImplementedException();
        }

        public Selector<Element> Child()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
                : (Selector<Element>)(nodes => nodes);
                 //: (Selector<Element>)(nodes => nodes.Where(n => n.TagName == name));
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
