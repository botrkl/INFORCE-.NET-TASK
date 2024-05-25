using AutoMapper;
using URLShortener.BLL.Models;
using URLShortener.BLL.Models.AddModels;
using URLShortener.BLL.Services.Intefaces;
using URLShortener.DAL.Entities;
using URLShortener.DAL.Repositories.Intefaces;

namespace URLShortener.BLL.Services.Classes
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHashingService _passwordHashingService;
        private readonly IJwtService _jwtService;
        private readonly IMapper _mapper;
        public AuthService(IUserRepository userRepository, IPasswordHashingService passwordHashingService, IJwtService jwtService, IMapper mapper)
        {
            _userRepository = userRepository;
            _passwordHashingService = passwordHashingService;
            _jwtService = jwtService;
            _mapper = mapper;
        }
        public async Task<string> AuthenticateAsync(string username, string password)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);
            if (user == null)
            {
                throw new Exception($"User with username '{username}' does not exist.");
            }

            if (!await _passwordHashingService.VerifyPasswordAsync(password, user.HashPassword))
            {
                throw new Exception("Wrong password.");
            }
            var userModel = _mapper.Map<UserModel>(user);

            var token = await _jwtService.GenerateToken(userModel);

            return token;
        }

        public async Task<string> RegisterAsync(AddUserModel addUserModel)
        {
            if (await _userRepository.CheckUserExistByUsernameAsync(addUserModel.Username))
            {
                throw new Exception($"User with username '{addUserModel.Username}' already exist.");
            }
            addUserModel.Password = await _passwordHashingService.HashPasswordAsync(addUserModel.Password);

            var user = _mapper.Map<User>(addUserModel);

            var resultUser = await _userRepository.AddAsync(user);
                                                                  
            var userModel = _mapper.Map<UserModel>(resultUser);

            var token = await _jwtService.GenerateToken(userModel);
            return token;
        }
    }
}
