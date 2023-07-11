using System.Linq.Expressions;
using Assignment_1.Data;
using Assignment_1.Models;
using Assignment_1.Repository.IRepository;
using AutoMapper;

namespace Assignment_1.Repository
{
    public class JourneyRepository : IJourneyRepository
    {
        private readonly ApplicationDbContext _db;
        public JourneyRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public void createJourney(Journey entity)
        {
            _db.Add(entity);
            _db.SaveChanges();
        }

        public void deleteJourney(Journey entity)
        {
            _db.Remove(entity);
            _db.SaveChanges();
        }

        public List<Journey> GetAllJourney()
        {
           return _db.Journeys.ToList();
        }

        public Journey GetJourney(int id)
        {
            return _db.Journeys.FirstOrDefault(u => u.Id == id);
        }

        public void updateJourney(Journey entity)
        {
            _db.Update(entity);
            _db.SaveChanges();
        }
    }
}
