using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{

    public class PlannerRepository
    {
        private readonly SQLiteAsyncConnection _database;

        public PlannerRepository(string databaseFilePath)
        {
            _database = new SQLiteAsyncConnection(databaseFilePath);
            _database.CreateTableAsync<Planner>().Wait();
        }


        public async Task<List<Planner>> GetList()
        {
            Planner planner = new Planner() { Title = "Plan your upcoming activities here!", IsCompleted = true };
            if ((await _database.Table<Planner>().CountAsync() == 0))
            {
                await _database.InsertAsync(planner);
            }
            return await _database.Table<Planner>().ToListAsync();
        }

        public Task DeleteItem(Planner itemToDelete)
        {
            return _database.DeleteAsync(itemToDelete);
        }

        public Task ChangeItemIsCompleted(Planner itemToChange)
        {
            itemToChange.IsCompleted = !itemToChange.IsCompleted;
            return _database.UpdateAsync(itemToChange);
        }

        public Task AddItem(Planner itemToAdd)
        {
            return _database.InsertAsync(itemToAdd);
        }
    }
}
