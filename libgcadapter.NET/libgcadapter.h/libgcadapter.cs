using System;
using System.Runtime.InteropServices;

namespace libgcadapter.NET
{
	internal static unsafe class libgcadapter
	{
		public const int LIBGCADAPTER_VERSION = 111;

		[StructLayout(LayoutKind.Sequential)]
		public struct gc_adapter_t
		{
			[MarshalAs(UnmanagedType.U1)]
			public bool open;
			[MarshalAs(UnmanagedType.U1)]
			public bool reserved;

			[MarshalAs(UnmanagedType.ByValArray, SizeConst = GameCubeAdapter.Ports)]
			public GameCubeControllerType[] pad;
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = GameCubeAdapter.Ports)]
			public GameCubeControllerState[] state;
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = GameCubeAdapter.Ports)]
			public byte[] rumble;

			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 37)]
			public byte[] usb_recv_data;
			public IntPtr usb_context;
			public IntPtr usb_device_handle;
			public byte usb_endpoint_read;
			public byte usb_endpoint_write;
		}

		[DllImport("libgcadapter.dll")]
		public static extern int gc_adapter_get_version();

		[DllImport("libgcadapter.dll")]
		public static extern bool gc_adapter_initialize(out IntPtr adapter);

		[DllImport("libgcadapter.dll")]
		public static extern void gc_adapter_update(IntPtr adapter);

		[DllImport("libgcadapter.dll")]
		public static extern void gc_adapter_poll(IntPtr adapter);

		[DllImport("libgcadapter.dll")]
		public static extern void gc_adapter_set_rumble(IntPtr adapter, int port, byte rumble);

		[DllImport("libgcadapter.dll")]
		public static extern void gc_adapter_free(IntPtr adapter);
	}
}

