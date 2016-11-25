//---------------------------------------------------------------------------- 
//
//  Copyright (C) Jason Graham.  All rights reserved.
// 
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
// 
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
// 
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
// 
// History
//  08/21/13    Created 
//
//---------------------------------------------------------------------------

namespace System.Windows.Forms
{
    using System.Diagnostics;

    /// <summary>
    /// Allows implicit string conversions for derived types.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ImplicitString<T> : IEquatable<T>, IComparable<T> where T : ImplicitString<T>
    {
        #region Fields
        /// <summary>
        /// Defines the underlying value.
        /// </summary>
        [DebuggerBrowsable(Diagnostics.DebuggerBrowsableState.Never)]
        protected readonly string Value;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes the class from a string.
        /// </summary>
        /// <param name="value">The <see cref="System.String"/> to initialize the underlying value from.</param>
        protected ImplicitString(string value)
        {            
            Value = value;
        }
        #endregion

        #region Overrides
        /// <summary>
        /// Returns the underlying instance of <see cref="System.String"/>; no actual conversion is performed.
        /// </summary>
        /// <returns>The current string.</returns>
        public override string ToString()
        {
            return Value;
        }

        /// <summary>
        /// Returns the hash code for this string.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        /// <summary>
        /// Determines whether this instance and a specified object, which must also
        /// be a <typeparamref name="T"/> object, have the same value.
        /// </summary>
        /// <param name="obj">The type <typeparamref name="T"/> to compare to this instance.</param>
        /// <returns>true if obj is a <typeparamref name="T"/> and its value is the same as this instance;
        /// otherwise, false</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            T other = obj as T;

            if (other == null)
                return false;

            return Equals(other);
        }
        #endregion

        #region IEquatable/IComparable Implementation
        /// <summary>
        /// Determines whether this instance and another specified <typeparamref name="T"/> object
        /// have the same value.
        /// </summary>
        /// <param name="other">The string to compare to this instance.</param>
        /// <returns>true if the value of the <paramref name="other"/> parameter is the same as this instance;
        /// otherwise, false.</returns>
        public bool Equals(T other)
        {
            return string.Equals(Value, other.Value);
        }

        /// <summary>
        /// Compares this instance with a specified <typeparamref name="T"/> object and indicates whether
        /// this instance precedes, follows, or appears in the same position in the sort order
        /// as the specified <typeparamref name="T"/>.
        /// </summary>
        /// <param name="other">The type <typeparamref name="T"/> to compare with this instance.</param>
        /// <returns>A 32-bit signed integer that indicates whether this instance precedes, follows,
        /// or appears in the same position in the sort order as the other parameter. Value
        /// Condition Less than zero This instance precedes other. Zero This instance
        /// has the same position in the sort order as other. Greater than zero This instance
        /// follows other.-or- other is null.</returns>
        public int CompareTo(T other)
        {
            return string.Compare(Value, other.Value);
        }
        #endregion
    }
}
