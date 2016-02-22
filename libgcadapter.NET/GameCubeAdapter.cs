using System;

namespace libgcadapter.NET
{
	public unsafe class GameCubeAdapter : IDisposable
	{
		public const int Ports = 4;

		public bool Open
		{
			get
			{
				return _adapter[0] == 1;
			}
		}

		private bool _succeeded = false;

		// yes, we are accessing the adapter instance as a raw byte array.
		internal byte* _adapter;

		private GameCubeController[] _controllers = new GameCubeController[Ports];

		public GameCubeAdapter()
		{
			if(libgcadapter.gc_adapter_get_version() != libgcadapter.LIBGCADAPTER_VERSION)
				throw new GameCubeAdapterException("Invalid library version.", this);
			if(libgcadapter.gc_adapter_initialize(out _adapter))
				_succeeded = true;
			else
				throw new GameCubeAdapterException("Could not initialize libgcadapter.", this);
			for(int i = 0; i < Ports; i++)
			{	
				_controllers[i] = new GameCubeController(this, i);
			}
		}

		internal GameCubeAdapter(out bool succeeded)
		{
			if(libgcadapter.gc_adapter_get_version() != libgcadapter.LIBGCADAPTER_VERSION)
			{
				succeeded = false;
				return;
			}
			if(libgcadapter.gc_adapter_initialize(out _adapter))
				succeeded = true;
			else
			{
				succeeded = false;
				return;
			}
			for(int i = 0; i < Ports; i++)
			{	
				_controllers[i] = new GameCubeController(this, i);
			}
			_succeeded = succeeded;
		}

		public static bool TryCreate(out GameCubeAdapter adapter)
		{
			bool succeeded;
			GameCubeAdapter adapter_ = new GameCubeAdapter(out succeeded);
			if(succeeded)
				adapter = adapter_;
			else
				adapter = null;
			return succeeded;
		}

		public void Update()
		{
			libgcadapter.gc_adapter_update(_adapter);
		}

		public GameCubeController Port(int port)
		{
			if(port < 0 || port > 3)
				throw new GameCubeAdapterException("Invalid port specified (" + port + ").", this);
			return _controllers[port];
		}

		public GameCubeController this[int port]
		{
			get
			{
				return Port(port);
			}
		}
			
		public void Dispose()
		{
			if(_succeeded)
			{
				libgcadapter.gc_adapter_free(_adapter);
			}
		}
	}
}
