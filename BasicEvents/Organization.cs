using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicEvents
{
	class Organization
	{
		public List<String> BannedUsers { get; set; } = new List<string>();

		public List<User> Users { get; set; } = new List<User>();

		public void AddUser(string name)
		{
			bool userIsBanned = false;

			foreach (string user in BannedUsers)
			{
				if (name == user)
					userIsBanned = true;
			}

			if (!userIsBanned)
			{
				UserAddedEventArgs args = new UserAddedEventArgs();
				args.Name = name;
				UserAdded(this, args);
				User newUser = new User();
				newUser.Name = name;
				Users.Add(newUser);
			}
			else
			{
				UserBannedEventArgs args = new UserBannedEventArgs();
				args.Name = name;
				UserBanned(this, args);
			}
		}

		public event UserAddedDelegate UserAdded;
		public event UserBannedDelegate UserBanned;
	}
}
