using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClipboardAccessorDemo
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ClipboardAccessor<string>.ClipboardChanged += PlaintextClipboardAccessor;
            ClipboardAccessor<RtfString>.ClipboardChanged += ClipboardAccessor;
        }

        private void ClipboardAccessor(object sender, ClipboardChangedEventArgs<RtfString> e)
        {
            rtfTextbox.Rtf = e.Value;
        }

        private void PlaintextClipboardAccessor(object sender, ClipboardChangedEventArgs<string> e)
        {
            plaintextTextbox.Text = e.Value;
        }

        private void copyToClipboardButton_Click(object sender, EventArgs e)
        {
            ClipboardAccessor<string>.Value = copyToClipboardTextbox.Text;
        }

        private void pasteFromClipboardButton_Click(object sender, EventArgs e)
        {
            pasteFromClipboardTextbox.Text = ClipboardAccessor<string>.Value;
        }
    }
}
