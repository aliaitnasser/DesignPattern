using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
	/// <summary>
	/// Mediator
	/// </summary>
	public interface IChatRoom
	{
		void Register(TeamMember teamMember);
		void Send(string from, string message);
		void Send(string from, string to, string message);
	}

	/// <summary>
	/// Colleage
	/// </summary>
	public abstract class TeamMember
	{
		private IChatRoom? _chatRoom;
		public string Name { get; set; }

		public TeamMember(string name)
		{
			Name = name;
		}

		internal void SetChatRoom(IChatRoom chatRoom)
		{
			_chatRoom = chatRoom;
		}

		public void Send(string message)
		{
			_chatRoom?.Send(Name, message);
		}
		public void Send(string to, string message)
		{
			_chatRoom?.Send(Name, to, message);
		}

		public virtual void Receive(string from, string message)
		{
			Console.WriteLine($"From {from}:\n \t{message}\n");
		}
	}

	/// <summary>
	/// Concrete colleage
	/// </summary>
	public class Lawyer: TeamMember
	{
		public Lawyer(string name) : base(name) { }

		public override void Receive(string from, string message)
		{
			Console.WriteLine($"{nameof(Lawyer)} {Name} received :");
			base.Receive(from, message);
		}
	}

	/// <summary>
	/// Concrete colleage
	/// </summary>
	public class Manager: TeamMember
	{
		public Manager(string name) : base(name) { }

		public override void Receive(string from, string message)
		{
			Console.WriteLine($"{nameof(Manager)} {Name} received :");
			base.Receive(from, message);
		}
	}

	/// <summary>
	/// Concrete Mediator
	/// </summary>
	public class TeamChatRoom: IChatRoom
	{
		private readonly Dictionary<string, TeamMember> teamMembers = new(); 
		public void Register(TeamMember teamMember)
		{
			teamMember.SetChatRoom(this);
			if(!teamMembers.ContainsKey(teamMember.Name)) teamMembers.Add(teamMember.Name, teamMember);
		}

		public void Send(string from, string message)
		{
			foreach(var teamMember in teamMembers.Values)
			{
				if(teamMember.Name != from) teamMember.Receive(from, message);
			}
		}
		public void Send(string from, string to, string message)
		{
			var teamMember = teamMembers[to];
			teamMember.Receive(from, message);
		}
	}


}
