using System.Reflection;
using System.Windows.Forms;

namespace DataGeneratorGUI.Helpers
{
    public static class Extensions
    {
        public static void DoubleBuffered(this DataGridView dgv, bool setting)
        {
            var dgvType = dgv.GetType();
            var pi = dgvType.GetProperty("DoubleBuffered",
                BindingFlags.Instance | BindingFlags.NonPublic);
            pi?.SetValue(dgv, setting, null);
        }
    }
}
