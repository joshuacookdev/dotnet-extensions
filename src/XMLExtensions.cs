using System.Xml.Linq;
using System.Linq;
using System;
using System.Runtime.CompilerServices;

namespace Cook.DotnetExtensions
{
    public static class XMLExtensions
    {
        /// <summary>
        /// Easy extension method to check if current element is root of XDocument.
        /// Requires that the XElement is part of an XDocument.
        /// </summary>
        /// <param name="element">Element to check.</param>
        /// <returns>
        ///   True if the element is root.
        /// </returns>
        public static bool IsRoot(this XElement element)
        {
            if(element.Document is null)
            {
                throw new ArgumentException("XElement must be within a XDocument");
            }
            return element == element.Document.Root;
        }

        /// <summary>
        /// Gets value of a fully qualified attribute name without throwing NullReferenceException 
        /// on missing XAttribute.Value call.
        /// </summary>
        /// <param name="elem">Element to get attribute value from.</param>
        /// <param name="att">Attribute to try and retrieve value of.</param>
        /// <returns>
        ///   Empty if attribute doesn't exist.
        ///   Empty if attribute exists but has only whitespace.
        ///   Value if attribute exists and has passible XAttribute.Value call.
        /// </returns>
        public static string SafeGetAttributeValue(this XElement elem, string att)
        {
            if (string.IsNullOrWhiteSpace(att) || elem is null)
            {
                return "";
            }

            XName attribute = att;
            return elem.Attribute(attribute.LocalName) != null
                ? elem.Attribute(attribute.LocalName).Value
                : "";
        }

        public static string SafeGetParentName(this XElement elem)
        {
            return (elem != null && elem.Parent != null)
                ? elem.Parent.Name.LocalName
                : "";
        }
    }
}