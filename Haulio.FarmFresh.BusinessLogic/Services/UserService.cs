using AutoMapper;
using Haulio.FarmFresh.BusinessLogic.Services;
using Haulio.FarmFresh.DAL.Repositories;
using Haulio.FarmFresh.DTO.DTOs;
using Haulio.FarmFresh.Entity.Entities;
using Haulio.FarmFresh.Utility;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Haulio.FarmFresh.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<UserToListDTO> AddUser(UserToAddDTO userToAddDTO)
        {
            return _mapper.Map<UserToListDTO>(await _userRepository.Add(_mapper.Map<User>(userToAddDTO)));
        }

        public async Task<List<UserToListDTO>> GetUsers()
        {
            return _mapper.Map<List<UserToListDTO>>(await _userRepository.GetList());
        }
         
        public async Task<UserToAuthDTO> GetAuthUser(string Username, string Password)
        {
            string encPass = TokenUtility.GenerateSHA512String(Password);
            return _mapper.Map<UserToAuthDTO>(await _userRepository.GetAuthUser(Username, encPass));
        }
    }

}
