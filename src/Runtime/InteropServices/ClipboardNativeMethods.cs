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

namespace System.Runtime.InteropServices
{
    public static partial class NativeMethods
    {
        /// <summary>
        /// Adds the specified window to the chain of clipboard viewers. Clipboard viewer windows receive a WM_DRAWCLIPBOARD message whenever the content of the clipboard changes. This function is used for backward compatibility with earlier versions of Windows.
        /// </summary>
        /// <param name="hWnd">A handle to the window to be added to the clipboard chain.</param>
        /// <returns>If the function succeeds, the return value identifies the next window in the clipboard viewer chain. If an error occurs or there are no other windows in the clipboard viewer chain, the return value is NULL. To get extended error information, call GetLastError.</returns>
        [DllImport(USER32, EntryPoint = "SetClipboardViewer")]
        public static extern IntPtr SetClipboardViewer([In] IntPtr hWnd);

        /// <summary>
        /// Removes a specified window from the chain of clipboard viewers.
        /// </summary>
        /// <param name="hWndRemove">A handle to the window to be removed from the chain. The handle must have been passed to the SetClipboardViewer function. </param>
        /// <param name="hWndNewNext">A handle to the window that follows the hWndRemove window in the clipboard viewer chain. (This is the handle returned by SetClipboardViewer, unless the sequence was changed in response to a WM_CHANGECBCHAIN message.) </param>
        /// <returns>The return value indicates the result of passing the WM_CHANGECBCHAIN message to the windows in the clipboard viewer chain. Because a window in the chain typically returns FALSE when it processes WM_CHANGECBCHAIN, the return value from ChangeClipboardChain is typically FALSE. If there is only one window in the chain, the return value is typically TRUE.</returns>
        [DllImport(USER32, EntryPoint = "ChangeClipboardChain")]
        public static extern bool ChangeClipboardChain([In] IntPtr hWndRemove, [In] IntPtr hWndNewNext);
    }
}
