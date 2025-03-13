using FlagExplorer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlagExplorer.Domain.Interfaces
{
    public interface ICountryExternalClient
    {
        Task<List<Country>> GetAllCountriesAsync();
        Task<CountryDetails> GetCountryByNameAsync(string name);
    }
}
