using System.Collections.Generic;
using System.Linq;
using SQLite;
using TabbedAppXamarin.Model;
using TabbedAppXamarin.Services.Database;
using Xamarin.Forms;

namespace TabbedAppXamarin.Services.Entities
{
    public interface IEntiryService
    {
        void Add(SomeEntity item);
        void Delete(SomeEntity item);
        IEnumerable<SomeEntity> GetThings();
    }
    public class EntityService : IEntiryService
    {
        private readonly SQLiteConnection _connection;

        public EntityService()
        {
            _connection = DependencyService.Get<ISQLite>().GetConnection();
            _connection.CreateTable<SomeEntity>();
        }

        public void Add(SomeEntity item)
        {
            _connection.Insert(item);
        }

        public void Delete(SomeEntity item)
        {
            _connection.Delete(item);
            _connection.UpdateAll(_connection.Table<SomeEntity>());
        }

        public IEnumerable<SomeEntity> GetThings()
        {
            var entities = _connection.Table<SomeEntity>().ToList();
            return entities;
        }
    }
}
