using System;
using System.Runtime.InteropServices;

namespace libgcadapter.NET
{
	internal static unsafe class libgcadapter
	{
		public const int LIBGCADAPTER_VERSION = 110;

		[DllImport("dl")]
		public static extern IntPtr dlopen(string file, int mode);

		[DllImport("libgcadapter.dll")]
		public static extern int gc_adapter_get_version();

		[DllImport("libgcadapter.dll")]
		public static extern bool gc_adapter_initialize(out byte* adapter);

		[DllImport("libgcadapter.dll")]
		public static extern void gc_adapter_update(byte* adapter);

		[DllImport("libgcadapter.dll")]
		public static extern void gc_adapter_poll(byte* adapter);

		[DllImport("libgcadapter.dll")]
		public static extern void gc_adapter_set_rumble(byte* adapter, int port, byte rumble);

		[DllImport("libgcadapter.dll")]
		public static extern void gc_adapter_free(byte* adapter);
	}
}

