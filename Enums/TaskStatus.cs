using System;
using System.ComponentModel;

namespace task_system.Enums
{
	public enum TaskStatus
	{
		[Description("To Do")]
		ToDo = 1,
        [Description("Doing")]
        Doing = 2,
        [Description("Done")]
        Done = 3
    }
}

