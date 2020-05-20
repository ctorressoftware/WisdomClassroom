using System.Collections.Generic;
using System.Data.Entity;
using WisdomClassroomApp.Common;
using WisdomClassroomApp.Models.Domain;
using WisdomClassroomApp.Models.Viewmodels;
using WisdomClassroomApp.Persistence;

namespace WisdomClassroomApp.Services
{
    public class PersonServices : IRepository<PersonViewModel>
    {
        public List<PersonViewModel> GetAll()
        {
            var listPeople = new List<PersonViewModel>();

            using (var db = new ApplicationDbContext())
            {
                foreach (var item in db.Person)
                {
                    var person = Convert(item);
                    listPeople.Add(person);
                }

                return listPeople;
            }
        }

        public PersonViewModel GetById(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var person = Convert(db.Person.Find(id));
                return person;
            }
        }

        public PersonViewModel GetByEmail(string email)
        {
            var person = GetAll().Find(x => x.Email.Equals(email));

            return person;
        }

        public void Create(PersonViewModel model)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Person.Add(Convert(model));
                db.SaveChanges();
            }
        }

        public void Delete(PersonViewModel model)
        {
            using (var db = new ApplicationDbContext())
            {
                var person = Convert(model);
                db.Entry(person).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void Update(PersonViewModel entity)
        {
            using (var db = new ApplicationDbContext())
            {
                var person = Convert(entity);
                db.Entry(person).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        private dynamic Convert<E>(E item)
        {
            if (item is Person)
            {
                var entity = item as Person;

                return new PersonViewModel
                {
                    Id = entity.Id,
                    Birthday = entity.Birthday,
                    Name = entity.Name,
                    LastName = entity.LastName,
                    Email = entity.Email,
                    Role = entity.Role
                };
            }
            else if (item is PersonViewModel)
            {
                var entity = item as PersonViewModel;

                return new Person
                {
                    Id = entity.Id,
                    Birthday = entity.Birthday,
                    Name = entity.Name,
                    LastName = entity.LastName,
                    Email = entity.Email,
                    Role = entity.Role
                };
            }

            return null;
        }
    }
}