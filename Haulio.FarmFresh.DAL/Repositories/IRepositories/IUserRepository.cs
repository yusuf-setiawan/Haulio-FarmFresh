using Haulio.FarmFresh.Entity.Entities;
using System.Threading.Tasks;

namespace Haulio.FarmFresh.DAL.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        public Task<User> GetAuthUser(string Username, string Password);
    }
}
