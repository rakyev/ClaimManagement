﻿using System;
using System.Collections.Generic;
using System.Linq;
using ICM.Data.Business.RepositoryImplementation;
using System.Web;
using ICM.Data.Business.CountImplementation;

//Created by Femi 2015-02-08 03:25AM
namespace ICM.Data.Business.BusinessObject
{
    public class ClientBO : GenericRepository<Client>
    {
        public List<Country> GetCountryList()
        {            
            var query = from country in Context.Countries
                        select country;

            return query.ToList();
        }

        public List<Gender> GetGenderList()
        {
            var query = from gender in Context.Genders
                        select gender;

            return query.ToList();
        }

         public List<MaritalState> GetMaritalStateList()
        {
            var query = from maritalState in Context.MaritalStates
                        select maritalState;

            return query.ToList();
        }

         public List<Prefix> GetPrefixList()
         {
             var query = from prefix in Context.Prefixes
                         select prefix;

             return query.ToList();
         }

         public List<ProvinceOrState> GetProvinceOrStateList()
         {
             var query = from province in Context.ProvinceOrStates
                         select province;

             return query.ToList();
         }
         public List<Client> GetClientsSearched(string des)
         {
             var query = from test in Context.Clients
                         where test.FirstName.Contains(des) || test.LastName.Contains(des)
                         select test;
            
             return query.ToList();
         }

         public int CountClientByDateCreated(DateTime dateTime)
        {
            var count = Context.Clients.Count(s => s.CreatedOrUpdated == dateTime);
            return count;
        }

        public override void Add(Client entity)
        {
            base.Add(entity);
            ClientCaseDoctorAppointmentCounts.ClientCount++;

        }

        public override void Delete(Client entity)
        {
            base.Delete(entity);
            ClientCaseDoctorAppointmentCounts.ClientCount--;

        }

        public IQueryable<Client> GetClientByName(String firstName, String lastName)
        {
            IQueryable<Client> query;
            if (firstName != null && firstName != "")
            {

                query = from client in Context.Clients
                        where client.FirstName.Contains(firstName)
                        select client;
            }
            else if (lastName != null && lastName != "")
            {
                query = from client in Context.Clients
                        where client.LastName.Contains(lastName)
                        select client;
            }
            
            else
            {
                query = from client in Context.Clients
                        where (client.FirstName.Contains( firstName)) && (client.LastName.Contains( lastName))
                        select client;
            }
            return query;
        }
    }
}