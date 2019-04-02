using System;

namespace BasicEvents
{
	public class UserBannedEventArgs : EventArgs
	{
		public string Name { get; set; }
	}
}