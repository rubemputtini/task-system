using System;
using Microsoft.EntityFrameworkCore;
using task_system.Data.Map;
using task_system.Models;

namespace task_system.Data
{
	public class TaskSystemDBContext : DbContext
	{
		public TaskSystemDBContext(DbContextOptions<TaskSystemDBContext> options)
			: base(options)
		{
		}

        public DbSet<UserModel> Users { get; set; }
		public DbSet<TaskModel> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new TaskMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}

