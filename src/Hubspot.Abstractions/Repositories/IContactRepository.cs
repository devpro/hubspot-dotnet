using System.Collections.Generic;
using System.Threading.Tasks;
using Devpro.Hubspot.Abstractions.Models;

namespace Devpro.Hubspot.Abstractions.Repositories
{
    public interface IContactRepository
    {
        Task<List<ContactModel>> FindAllAsync();
    }
}
