using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace BasicEvents
{
	/// <summary>
	/// 1. User provides their name as Input and then application show message to "Welcome to their Name".
	/// 2. Jack, Steven and Mathew are banned for the organization. So, when any user enters Jack, Steven and Mathew as user name, the application raised an event and fire alarm as well as sends email to administration.
	/// https://www.completecsharptutorial.com/basic/c-event-handling-exercises.php
	/// </summary>
	class Program
	{
		static void Main(string[] args)
		{
			Organization organization = new Organization();
			organization.BannedUsers.Add("Jack");
			organization.BannedUsers.Add("Steven");
			organization.BannedUsers.Add("Mathew");

			organization.UserAdded += OnUserAdded;
			organization.UserBanned += UserBannedAlarm;
			organization.UserBanned += UserBannedEmail;

			while (true)
			{
				Console.WriteLine("What is your name?");
				organization.AddUser(Console.ReadLine());
			}
		}

		static void UserBannedAlarm(object sender, UserBannedEventArgs args)
		{
			SystemSounds.Beep.Play();
		}
		static void UserBannedEmail(object sender, UserBannedEventArgs args)
		{
			Console.WriteLine($"Email: {args.Name} is banned, and is attempting to join the organization!");
		}

		static void OnUserAdded(object sender, UserAddedEventArgs args)
		{
			Console.WriteLine($"Welcome {args.Name}!");
		}
	}
}
