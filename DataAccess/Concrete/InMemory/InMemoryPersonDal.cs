using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryPersonDal : IPersonDal
    {
       
        List<Person> _people;
        //public InMemoryPersonDal()
        //{
        //    _people = new List<Person> { 

        //        new Person{PersonId=1, PersonName="Seda", PersonSurname="Turan", PersonPhoneNumber=537.ToString() },
        //        new Person{PersonId=1, PersonName="Merve", PersonSurname="Turan", PersonPhoneNumber=538.ToString() },
        //        new Person{PersonId=1, PersonName="Ela", PersonSurname="Turan", PersonPhoneNumber=539.ToString() }
        //    };
        //}
        
        public void Add(Person person)
        {
            _people.Add(person);
        }

        public void Delete(Person person)
        {
            //Person personToDelete = null;
            //foreach (var p in _people)
            //{
            //    if (person.PersonId == p.PersonId)
            //    {
            //        personToDelete = p;
            //    }
            //}
            //_people.Remove(personToDelete);

            
             Person personToDelete = _people.SingleOrDefault(p=>p.PersonId == person.PersonId);
            _people.Remove(personToDelete);
        }

        public Person Get(Expression<Func<Person, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Person> GetAll()
        {
            return _people;
        }

        public List<Person> GetAll(Expression<Func<Person, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<PersonDetailDto> GetPersonDetails()
        {
            throw new NotImplementedException();
        }
        public void Update(Person person)
        {
            Person personToUpdate = _people.SingleOrDefault(p => p.PersonId == person.PersonId);
            personToUpdate.PersonId = person.PersonId;
            personToUpdate.PersonName = person.PersonName;
            personToUpdate.PersonSurname = person.PersonSurname;
            personToUpdate.PersonPhoneNumber = person.PersonPhoneNumber;
            personToUpdate.PersonEmail = person.PersonEmail;
        }

    }
}
