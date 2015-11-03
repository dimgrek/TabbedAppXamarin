using System.Collections.Generic;
using System.Linq;
using SQLite;
using TabbedAppXamarin.Model;
using TabbedAppXamarin.Services.Database;
using Xamarin.Forms;

namespace TabbedAppXamarin.Services.Entities
{
    public interface IEntityService
    {
        void Add(SomeEntity item);
        void Delete(SomeEntity item);
        void Update(SomeEntity item);
        IEnumerable<SomeEntity> GetThings();
        IEnumerable<SomeEntity> GetThingsOrdered();
    }
    public class EntityService : IEntityService
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

        public void Update(SomeEntity item)
        {
            _connection.Delete(item);
            _connection.UpdateAll(_connection.Table<SomeEntity>());
            _connection.Insert(item);
        }

        public IEnumerable<SomeEntity> GetThings()
        {
            var entities = _connection.Table<SomeEntity>().ToList();
            return entities;
        }

        public IEnumerable<SomeEntity> GetThingsOrdered()
        {
            var entities = _connection.Table<SomeEntity>().ToList().OrderBy(e => e.Name);
            return entities;
        }
    }
}
