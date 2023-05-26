using Microsoft.EntityFrameworkCore;
using task_system.Data;
using task_system.Models;
using task_system.Repositories.Interfaces;

namespace task_system.Repositories
{
    public class UserRepository : IUserRepository
	{
        private readonly TaskSystemDBContext _dbContext;

        public UserRepository(TaskSystemDBContext taskSystemDBContext)
        {
            _dbContext = taskSystemDBContext;
        }

        public async Task<UserModel> GetById(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<UserModel> Add(UserModel user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<UserModel> Update(UserModel user, int id)
        {
            UserModel userById = await GetById(id);

            if(userById == null)
            {
                throw new Exception($"User with ID: {id} was not found in database.");
            }

            userById.Name = user.Name;
            userById.Email = user.Email;

            _dbContext.Users.Update(userById);
            await _dbContext.SaveChangesAsync();

            return userById;
        }

        public async Task<bool> Delete(int id)
        {
            UserModel userById = await GetById(id);

            if (userById == null)
            {
                throw new Exception($"User with ID: {id} was not found in database.");
            }

            _dbContext.Users.Remove(userById);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        
    }
}

