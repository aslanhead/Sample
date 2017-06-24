namespace Sqlize
{
    using System;
    using System.Windows.Forms;

    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Usage: Sqlize --string or Sqlize --int");
                return;
            }

            if (args[0].Equals("--string", StringComparison.OrdinalIgnoreCase))
            {
                SqlizeString();
            }
            else if (args[0].Equals("--int", StringComparison.OrdinalIgnoreCase))
            {
                SqlizeInt();
            }
            else
            {
                Console.WriteLine("Usage: Sqlize --string or Sqlize --int");
            }
        }

        private static void SqlizeString()
        {
            string s = Clipboard.GetText();
            if (!string.IsNullOrEmpty(s))
            {
                s = s.Trim();
                s = s.Replace(Environment.NewLine, "','");
                Clipboard.SetText("('" + s + "')");
            }
        }

        private static void SqlizeInt()
        {
            string s = Clipboard.GetText();
            if (!string.IsNullOrEmpty(s))
            {
                s = s.Trim();
                s = s.Replace(Environment.NewLine, ",");
                Clipboard.SetText("(" + s + ")");
            }
        }
    }
}
