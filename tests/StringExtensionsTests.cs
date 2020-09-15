using System;
using Xunit;
using Cook.DotnetExtensions;
using System.IO;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;

namespace Cook.DotnetExtensions.Tests
{
    public class StringExtensionsTests
    {
        [Theory]
        [InlineData(null,0,0,"")]
        [InlineData(null,0,10,"")]
        [InlineData("",0,0,"")]
        [InlineData("",0,1,"")]
        [InlineData("Sample",6,1,"")]
        [InlineData("Sample",0,1,"S")]
        [InlineData("Sample",4,10,"le")]
        [InlineData("Sample",0,6,"Sample")]
        public void SafeSubstring(string input, int startIndex, int stopIndex, string expectedReturn)
        {
            Assert.Equal(expectedReturn, input.SafeSubstring(startIndex, stopIndex));
        }
    }
}
