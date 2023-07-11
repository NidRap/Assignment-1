using Assignment_1.Models;

namespace Assignment_1.Repository.IRepository
{
	public interface IUserRepository
	{
	List<User> GetAll();
		User Get(int Id);
		void Create(User entity);
		void Remove(User entity);

		void Update(User entity);

		


	}
}
