using System;
using System.Diagnostics.CodeAnalysis;

namespace Cook.DotnetExtensions
{
    public static class Guards
    {
        /// <summary>
        /// Checks if an object is null, and throws an ArgumentNullException if it is.
        /// Planned to be used as an inline validation to prevent early guards in methods.
        /// S/O to Jon Skeet for this snippet:
        /// https://github.com/jskeet/DemoCode/blob/master/CSharp8/Nullability/Preconditions.cs
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static T CheckNotNull<T>([NotNull] T? input) where T : class =>
            input ?? throw new ArgumentNullException();
    }
}