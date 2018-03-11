using Newtonsoft.Json;
using StarWars.Model;
using StarWars.Services.Core;
using StarWars.Services.Interface;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Services.Services
{
    public class StarWarsService : IStarWarsService
    {
        HttpClient _httpClient;

        public async Task<Person> GetPerson(int id)
        {
            string url = "https://swapi.co/api/people/"+id;
            try
            {
                using (_httpClient = new HttpClient())
                {
                    var result = await _httpClient.GetAsync(url);



                    if (result.IsSuccessStatusCode)
                    {
                        var content = await result.Content.ReadAsStringAsync();
                        var resp = JsonConvert.DeserializeObject<Person>(content);
                        return resp;
                    }
                    else
                    {
                        var content = await result.Content.ReadAsStringAsync();
                        var resp = JsonConvert.DeserializeObject<string>(content);
                        throw new Exception(resp);
                    }
                }
            }
            catch (Exception)
            {                
                throw;
            }            
        }

        public async Task<PersonResponse> GetPersons(int page)
        {
            HttpClient _httpClient;

          
                string url = "https://swapi.co/api/people/?page="+page;
                try
                {
                    using (_httpClient = new HttpClient())
                    {
                        var result = await _httpClient.GetAsync(url);



                        if (result.IsSuccessStatusCode)
                        {
                            var content = await result.Content.ReadAsStringAsync();
                            var resp = JsonConvert.DeserializeObject<PersonResponse>(content);
                            return resp;
                        }
                        else
                        {
                            var content = await result.Content.ReadAsStringAsync();
                            var resp = JsonConvert.DeserializeObject<string>(content);
                            throw new Exception(resp);
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
    }
}
