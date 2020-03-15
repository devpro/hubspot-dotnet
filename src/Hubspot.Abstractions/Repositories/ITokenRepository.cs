using System.Threading.Tasks;
using Devpro.Hubspot.Abstractions.Models;

namespace Devpro.Hubspot.Abstractions.Repositories
{
    public interface ITokenRepository
    {
        Task<TokenModel> CreateAsync(string authorizationCode);
    }
}
