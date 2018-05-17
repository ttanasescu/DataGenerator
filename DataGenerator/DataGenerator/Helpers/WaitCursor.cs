using System;
using System.Windows.Forms;

namespace DataGeneratorGUI.Helpers
{
    public class WaitCursor : IDisposable
    {
        public WaitCursor(bool appStarting = false, bool applicationCursor = false)
        {
            Cursor.Current = appStarting ? Cursors.AppStarting : Cursors.WaitCursor;
            if (applicationCursor) Application.UseWaitCursor = true;
        }

        public void Dispose()
        {
            Cursor.Current = Cursors.Default;
            Application.UseWaitCursor = false;
        }
    }
}