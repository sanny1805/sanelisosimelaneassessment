using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlagExplorer.Domain.Entities
{
    public class CountryDetails : Country
    {
        public long Population { get; set; }
        public string Capital { get; set; } = string.Empty;
    }
}
