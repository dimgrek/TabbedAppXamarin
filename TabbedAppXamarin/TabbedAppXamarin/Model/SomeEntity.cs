using System;
using SQLite;

namespace TabbedAppXamarin.Model
{
    [Table("ContactItem")]
    public class SomeEntity
    {
        //public SomeEntity()
        //{
        //    Id = Guid.NewGuid();
        //}

        [PrimaryKey]
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime Updated { get; set; }
    }
}
