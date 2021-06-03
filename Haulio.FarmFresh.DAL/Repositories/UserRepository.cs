using Haulio.FarmFresh.DAL.DataContext;
using Haulio.FarmFresh.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Haulio.FarmFresh.DAL.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly FarmFreshDbContext _farmFreshDbContext;
        public UserRepository(FarmFreshDbContext farmFreshDbContext) : base(farmFreshDbContext)
        {
            _farmFreshDbContext = farmFreshDbContext;
        }
         
        public async Task<User> GetAuthUser(string Username, string Password)
        {
            return await _farmFreshDbContext.Users.Where(x=>x.Username == Username && x.Password == Password).FirstOrDefaultAsync();
        }
    }
}
