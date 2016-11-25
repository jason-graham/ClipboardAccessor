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
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Runtime.InteropServices.Enums;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    /// <summary>
    /// Provides type safe access to monitor and access clipboard values.
    /// </summary>
    /// <typeparam name="TData">The type of object to monitor or access. This is limited to primitive types, <see cref="System.String"/>,
    /// <see cref="System.Windows.Forms.HtmlString"/>, <see cref="System.Windows.Forms.RtfString"/>, <see cref="System.Drawing.Bitmap"/>,
    /// or any type that implements <see cref="System.Runtime.Serialization.System.ISerializable"/> or is marked with the 
    /// <see cref="System.SerializableAttribute"/>.</typeparam>
    public static class ClipboardAccessor<TData>
    {
        #region ClipboardMessageSink Class
        /// <summary>
        /// The <see cref="ClipboardMessageSink"/> class is a target for clipboard message notifications.
        /// This implements IDisposable however, it is acceptable to allow GC to collect this.
        /// </summary>
        private sealed class ClipboardMessageSink : NativeWindow, IDisposable
        {
            #region Events
            /// <summary>
            /// Event raised when the clipboard changes.
            /// </summary>
            public event EventHandler ClipboardChanged;
            #endregion

            #region Fields
            /// <summary>
            /// Defines the next clipboard viewer.
            /// </summary>
            private IntPtr hWndNextViewer;
            /// <summary>
            /// Defines the handle, used to change chain 
            /// even after handle is destroyed.
            /// </summary>
            private IntPtr hWnd;
            #endregion

            #region Constructors
            /// <summary>
            /// Initializes the <see cref="ClipboardMessageSink"/> class.
            /// </summary>
            [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)]
            public ClipboardMessageSink()
            {
                //create the handle
                CreateHandle(new CreateParams());

                //create a local copy of the handle to allow changing clipboard
                //chain even after the handle is destroyed
                hWnd = Handle;

                //subscribe to clipboard change notifications
                hWndNextViewer = NativeMethods.SetClipboardViewer(Handle);
            }
            #endregion

            #region Overrides
            /// <summary>
            /// This method is called when a window message is sent to the handle of the window.
            /// </summary>
            /// <param name="m">The Windows <see cref="System.Windows.Forms.Message"/> to process.</param>
            [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)]
            protected override void WndProc(ref Message m)
            {
                switch ((WindowsMessages)m.Msg)
                {
                    case WindowsMessages.WM_DRAWCLIPBOARD:

                        try
                        {
                            //raise the changed event
                            if (ClipboardChanged != null)
                                ClipboardChanged(this, EventArgs.Empty);
                        }
                        finally
                        {
                            //notify next viewer in chain
                            if (hWndNextViewer != IntPtr.Zero)
                                NativeMethods.SendMessage(hWndNextViewer, WindowsMessages.WM_DRAWCLIPBOARD, m.WParam, m.LParam);
                        }

                        break;
                    case WindowsMessages.WM_CHANGECBCHAIN:

                        //if the next window is closing, repair the chain
                        if (m.WParam == hWndNextViewer)
                            hWndNextViewer = m.LParam;
                        //pass the message to the next window in the chain
                        else if (hWndNextViewer != IntPtr.Zero)
                            NativeMethods.SendMessage(hWndNextViewer, WindowsMessages.WM_CHANGECBCHAIN, m.WParam, m.LParam);

                        break;

                }

                base.WndProc(ref m);
            }
            #endregion

            #region Disposing
            /// <summary>
            /// Disposes the clipboard message sink.
            /// </summary>
            ~ClipboardMessageSink()
            {
                Disposing(false);
            }

            /// <summary>
            /// Disposes the clipboard message sink.
            /// </summary>
            public void Dispose()
            {
                Disposing(true);
                GC.SuppressFinalize(this);
            }

            /// <summary>
            /// Disposes unmanaged and optionally, managed resources.
            /// </summary>
            /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
            [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)]
            private void Disposing(bool disposing)
            {
                if (hWnd != null)
                {
                    //remove this from the clipboard chain
                    NativeMethods.ChangeClipboardChain(hWnd, hWndNextViewer);
                    hWnd = IntPtr.Zero;
                }

                if (disposing)
                    //destroy the handle
                    if (Handle != IntPtr.Zero)
                        DestroyHandle();
            }
            #endregion
        }
        #endregion

        #region Readonly Fields
        /// <summary>
        /// Defines the <see cref="System.String"/> clipboard data format
        /// that will be get or set.
        /// </summary>
        private static readonly string DataFormat;

        /// <summary>
        /// Defines the <see cref="System.Type"/> of data
        /// that will be get or set.
        /// </summary>
        private static readonly Type DataType;
        #endregion

        #region Events
        /// <summary>
        /// Defines an delegate used to facilitate subscriber tracking to create or destroy
        /// the <see cref="ClipboardMessageSink"/>.
        /// </summary>
        private static EventHandler<ClipboardChangedEventArgs<TData>> clipboardChanged;
        #endregion

        #region Fields
        /// <summary>
        /// Defines an instance of the <see cref="ClipboardMessageSink"/> used to monitor
        /// clipboard activity.
        /// </summary>
        private static ClipboardMessageSink messageSink;

        /// <summary>
        /// Defines the previous clipboard value to determine if
        /// a change actually took place in the face of sequential
        /// clipboard change notifications.
        /// </summary>
        private static TData previousValue;

        /// <summary>
        /// Defines the previous generation for the type.
        /// </summary>
        private static int previousGeneration;

        /// <summary>
        /// Defines the current clipboard generation; ONLY accessible using
        /// <see cref="ClipboardAccessor&lt;Object&gt;"/> to share between static instances.
        /// </summary>
        private static int generation;
        #endregion

        #region Static Constructor
        /// <summary>
        /// Static constructor initializes static data fields for
        /// a generic type T.
        /// </summary>
        /// <exception cref="InvalidOperationException">Invalid type specified.</exception>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1065:DoNotRaiseExceptionsInUnexpectedLocations")]
        static ClipboardAccessor()
        {
            //the ClipboardAccessor class can get or set various types
            //of clipboard data including strings, bitmaps, html, rtf
            //or any serializable object; the following determines
            //if a type fits into any of these parameters and sets static
            //fields appropriately
            DataType = typeof(TData);

            if (DataType == typeof(string))
                DataFormat = DataFormats.StringFormat;
            else if (DataType == typeof(Bitmap))
                DataFormat = DataFormats.Bitmap;
            else if (DataType == typeof(HtmlString))
                DataFormat = DataFormats.Html;
            else if (DataType == typeof(RtfString))
                DataFormat = DataFormats.Rtf;
            else if (DataType.IsSubclassOf(typeof(ISerializable)) || DataType.IsSerializable)
                DataFormat = DataFormats.Serializable;
            else
                throw new InvalidOperationException(DataType.Name + " is not a valid clipboard type.");
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the clipboard value.
        /// </summary>
        /// <remarks>
        /// Will return the default value of a type if there is no
        /// value in the clipboard.
        /// </remarks>
        public static TData Value
        {
            get
            {
                TData data;
                TryGetData(out data);
                return data;
            }
            set
            {
                Clipboard.SetData(DataFormat, value);
            }
        }
        #endregion

        #region Events
        /// <summary>
        /// Event raised when a type <typeparam name="TData"/> is added to the clipboard.
        /// </summary>
        public static event EventHandler<ClipboardChangedEventArgs<TData>> ClipboardChanged
        {
            add
            {
                //add delegate to invocation list
                clipboardChanged += value;

                //create sink if it does not exist
                if (messageSink == null)
                {
                    messageSink = new ClipboardMessageSink();

                    //wire changed event to notify subscribers
                    messageSink.ClipboardChanged += (sender, e) =>
                    {
                        TData data;

                        //attempt to get data
                        if (TryGetData(out data))
                        {
                            //get the current generation (increment for next call)
                            int generation = ClipboardAccessor<object>.generation++;

                            //if there are subscribers
                            if (clipboardChanged != null)
                            {
                                //check if object changed or different types have raised notifications
                                if (!Equals(data, previousValue) || previousGeneration != generation)
                                {
                                    previousValue = data;
                                    clipboardChanged(null, new ClipboardChangedEventArgs<TData>(data));
                                }
                            }

                            //set previous generation to current
                            previousGeneration = ++generation;
                        }
                    };
                }
            }
            remove
            {
                //remove delegate from invocation list
                clipboardChanged -= value;

                //if invocation list is empty, dispose the sink
                if (clipboardChanged == null && messageSink != null)
                {
                    messageSink.Dispose();
                    messageSink = null;
                }
            }
        }
        #endregion

        #region Static Methods
        /// <summary>
        /// Attempts to get data from the clipboard in the specified 
        /// format <typeparam name="TData"/> and returns a value 
        /// indicating if the operation succeeded.
        /// </summary>
        /// <param name="data">When this method returns, contains the data 
        /// retrieved from the clipboard or the default value of 
        /// <typeparam name="TData"/> if this method failed.</param>
        /// <returns>true if data was retrieved from the clipboard; 
        /// otherwise, false.</returns>
        public static bool TryGetData(out TData data)
        {
            //get clipboard data
            IDataObject cache = Clipboard.GetDataObject();

            //determine if data exists in specified format
            if (cache.GetDataPresent(DataFormat))
            {
                //get data from clipboard object
                object obj = cache.GetData(DataFormat);

                //determine if data exists in return format OR
                //expected return is RTF/HTML and clipboard data is string
                if (obj is TData || (obj is string && (DataType == typeof(RtfString) || DataType == typeof(HtmlString))))
                {
                    //dynamic keyword is used to allow the type to convert from
                    //an object to a generic type using operator overloads
                    data = (TData)(dynamic)obj;
                    return true;
                }
            }

            //no data found, initialize default
            data = default(TData);
            return false;
        }
        #endregion
    }
}