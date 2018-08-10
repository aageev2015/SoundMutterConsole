using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SoundMutter
{
	internal static class NativeMethods
	{
		[DllImport("kernel32.dll")]
		internal static extern IntPtr GetConsoleWindow();
	}

	class Program
	{
		private const int APPCOMMAND_VOLUME_MUTE = 0x80000;
		private const int WM_APPCOMMAND = 0x319;

		[DllImport("user32.dll")]
		public static extern IntPtr SendMessageW(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

		public static IntPtr Handle
		{
			get { return NativeMethods.GetConsoleWindow(); }
		}

		static void Main(string[] args)
		{
			SendMessageW(Handle, WM_APPCOMMAND, Handle, (IntPtr)APPCOMMAND_VOLUME_MUTE);
			return;
		}
	}
}
