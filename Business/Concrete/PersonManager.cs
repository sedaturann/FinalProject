﻿using Business.Abstract;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class PersonManager : IPersonService
    {
        IPersonDal _personDal;
        public PersonManager(IPersonDal personDal)
        {
            _personDal = personDal;

        }
        public IDataResult<List<Person>> GetAll()
        {
            return new SuccessDataResult<List<Person>>(_personDal.GetAll(), Messages.PeopleListed);
        }

        public IDataResult<List<Person>> GetAllByPersonId(int id)
        {
            return new SuccessDataResult<List<Person>>(_personDal.GetAll(p => p.PersonId == id));
        }
        public IDataResult<List<PersonDetailDto>> GetPersonDetails()
        {
            return new SuccessDataResult<List<PersonDetailDto>>(_personDal.GetPersonDetails());
        }

        [ValidationAspect(typeof(PersonValidator))]
        public IResult Add(Person person)
        {
            IResult result = BusinessRules.Run(CheckIfPersonPhoneNumberExists(person.PersonPhoneNumber));

            if (result != null)
            {
                return result;
            }
            _personDal.Add(person);
            return new SuccessResult(Messages.PersonAdded);
        }

        public IDataResult<Person> GetById(int personId)
        {
            return new SuccessDataResult<Person>(_personDal.Get(p => p.PersonId == personId));
        }

        public IDataResult<List<Person>> GetByPersonPhoneNumber(decimal min, decimal max)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Person person)
        {
            throw new NotImplementedException();
        }
        private IResult CheckIfPersonPhoneNumberExists(string personPhoneNumber)
        {
            var result = _personDal.GetAll(p => p.PersonPhoneNumber == personPhoneNumber).Any();
            if (result)
            {
                return new ErrorResult(Messages.PersonPhoneNumberAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
