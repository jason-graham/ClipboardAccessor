//---------------------------------------------------------------------------- 
//
//  Copyright (C) CSharp Labs.  All rights reserved.
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
    /// The <see cref="RtfString"/> represents a rich text formatted string.
    /// </summary>
    [DebuggerDisplay("RTF value is {ToString()}")]
    public sealed class RtfString : ImplicitString<RtfString>
    {
        #region Constructor
        /// <summary>
        /// Initializes the rich text formatted string.
        /// </summary>
        /// <param name="rtf">The rich text formatted string.</param>
        private RtfString(string rtf)
            : base(rtf)
        {
        } 
        #endregion

        #region Operators
        public static implicit operator string(RtfString rtf)
        {
            if (rtf == null)
                return null;

            return rtf.Value;
        }

        public static implicit operator RtfString(string rtf)
        {
            if (rtf == null)
                return null;

            return new RtfString(rtf);
        }
        #endregion
    }
}