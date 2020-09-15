using Xunit;
using System.Xml.Linq;
using System.Linq;
using System;

namespace Cook.DotnetExtensions.Tests
{
    public class XMLExtensionsTests
    {
        [Theory]
        [InlineData("root",true)]
        [InlineData("child",false)]
        [InlineData("grandchild",false)]
        public void IsRoot(string name, bool expectedReturn)
        {
            
            var actual =
                _sut.Descendants().FirstOrDefault(elem => elem.Name == name);
            
            Assert.Equal(expectedReturn, actual.IsRoot());
        }

        [Fact]
        public void IsRoot_RequiresXDocument()
        {
            XElement sut = new XElement(_sut.Root);

            Assert.Throws<ArgumentException>(() => sut.IsRoot());
        }

        [Theory]
        [InlineData(null, "")]
        [InlineData("", "")]
        [InlineData("  ", "")]
        [InlineData("MissingAttribute", "")]
        [InlineData("ValidAttWithoutValue", "")]
        [InlineData("ValidAtt", "ValidData")]
        public void SafeGetAttributeValue(string attributeName, string expectedValue)
        {
            //Given
            XElement sut = new XElement("root");
            sut.Add(
                new XAttribute("ValidAttWithoutValue", ""), 
                new XAttribute("ValidAtt", "ValidData")
            );
            //When
            string attValue = sut.SafeGetAttributeValue(attributeName);
            //Then
            Assert.Equal(expectedValue, attValue);
        }

        [Fact]
        public void SafeGetAttributeValue_NullElement()
        {
            XElement sut = null;

            string attValue = sut.SafeGetAttributeValue("id");

            Assert.Equal("",attValue);
        }

        [Theory]
        [InlineData("root","")]
        [InlineData("child", "root")]
        [InlineData("grandchild", "child")]
        public void SafeGetParentName(string elem, string parentName)
        {
            string temp = _sut.Descendants(elem).FirstOrDefault().SafeGetParentName();
            Assert.Equal(parentName, temp);
        }
        static XDocument _sut = new XDocument(
                new XElement("root",
                    new XElement("child",
                        new XElement("grandchild")
                    ),
                    new XElement("child",
                        new XElement("grandchild")
                    )
                )
            );
    }
}
