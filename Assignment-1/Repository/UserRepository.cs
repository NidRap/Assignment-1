using Assignment_1.Data;
using Assignment_1.Models;
using Assignment_1.Repository.IRepository;

namespace Assignment_1.Repository
{
	public class UserRepository : IUserRepository
	{
		private readonly ApplicationDbContext _db;
		public UserRepository(ApplicationDbContext db) {
			_db = db;
		}
		public void  Create(User entity)
		{
			 _db.User.Add(entity);
			_db.SaveChanges();
		}

		public User Get(int Id)
		{
			return _db.User.FirstOrDefault(u => u.Id == Id);
		}


		public List<User> GetAll()
		{
			return _db.User.ToList();
		}

		public void Remove(User entity)
		{
			_db.Remove(entity);
			_db.SaveChanges();
		}

		public void Update(User entity)
		{
			_db.Update(entity);
			_db.SaveChanges();
		}
	}
}
