using System.Threading.Tasks;

namespace Devpro.Hubspot.Abstractions.Repositories
{
    public interface IContactRepository
    {
        Task<object> FindAllAsync();
    }
}
