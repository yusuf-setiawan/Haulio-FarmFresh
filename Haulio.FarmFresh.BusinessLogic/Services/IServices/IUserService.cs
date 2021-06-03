using Haulio.FarmFresh.DTO.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Haulio.FarmFresh.BusinessLogic.Services
{
    public interface IUserService
    {
        Task<List<UserToListDTO>> GetUsers();
        Task<UserToListDTO> AddUser(UserToAddDTO userToAddDTO);
        Task<UserToAuthDTO> GetAuthUser(string Username, string Password);
    }
}
