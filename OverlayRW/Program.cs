using System;
using System.Windows.Forms;

namespace OverlayRW
{
  internal static class Program
  {
    /// <summary>
    /// Der Haupteinstiegspunkt für die Anwendung.
    /// </summary>
    [STAThread]
    private static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(defaultValue: false);
      Application.Run(mainForm: new OverlayRWForm());
    }
  }
}
