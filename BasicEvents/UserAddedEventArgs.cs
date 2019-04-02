using System;

namespace BasicEvents
{
	public class UserAddedEventArgs : EventArgs
	{
		public string Name { get; set; }
	}
}