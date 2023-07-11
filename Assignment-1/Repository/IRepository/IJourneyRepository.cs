using System.Linq.Expressions;
using Assignment_1.Models;

namespace Assignment_1.Repository.IRepository
{
    public interface IJourneyRepository
    {

        List<Journey> GetAllJourney();

        Journey GetJourney(int id);
        void createJourney(Journey entity);
        void updateJourney(Journey  entity);
        void deleteJourney(Journey entity);


        //Task< List<Journey>> AllJourneys
        //    (Expression<Func<Journey, bool>> filter = null);
        //Task GetJourneyById
        //    (Expression<Func<Journey, bool>> filter = null, bool tracked = true);
        //Task CreateJourney(Journey journey);
        //Task UpdateJourney(Journey journey);
        //Task DeleteJourney(int id);


    }
}
