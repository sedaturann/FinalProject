﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfPersonDal : EfEntityRepositoryBase<Person, DatabaseContext>, IPersonDal
    {
        public List<PersonDetailDto> GetPersonDetails()
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                var result = (from p in context.People
                              select new PersonDetailDto
                              {
                                  PersonId = p.PersonId,
                                  PersonName = p.PersonName,
                                  PersonSurname = p.PersonSurname,
                                  PersonPhoneNumber = p.PersonPhoneNumber,
                                  PersonEmail = p.PersonEmail
                              }).ToList();
                return result.ToList();
            }
        }
    }
}
