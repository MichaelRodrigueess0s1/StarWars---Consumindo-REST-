using StarWars.Model;
using StarWars.Services.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Services.Interface
{
    public interface IStarWarsService
    {
        Task<PersonResponse> GetPersons(int page);

        Task<Person> GetPerson(int id);
    }
}
