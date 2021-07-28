using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SolvexWorkshop.Model.Entities;
using SolvexWorkshop.Model.Repositories;
using SolvexWorkShop.Bl.Dto;
using SolvexWorkShop.Bl.Extensions;
using SolvexWorkShop.Core.Abstract;
using SolvexWorkShop.Core.Settings;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SolvexWorkShop.Services.Services
{
    public interface IUserService : IBaseService<User, UserDto>
    {
        Task<AuthenticateResponseDto> GetToken(AuthenticateRequestDto model);
    }

    public class UserService : BaseService<User, UserDto>, IUserService
    {
        private readonly JwtSettings _jwtSettings;
        public UserService(
            IUserRepository repository,
            IMapper mapper,
            IValidator<UserDto> validator,
            IOptions<JwtSettings> jwtSettings) : base(repository, mapper, validator)
        {
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<AuthenticateResponseDto> GetToken(AuthenticateRequestDto model)
        {
            var user = await _repository.Query()
                .Where(x => x.UserName == model.UserName)
                .Select(x => new
                {
                    x.Id,
                    x.UserName,
                    x.Name,
                    x.LastName,
                    x.Password
                })
                .FirstOrDefaultAsync();

            if (user is null)
                return null;

            bool validPassword = ValidatePassword(user.Password, model.Password);

            if (!validPassword) return null;

            var response = new AuthenticateResponseDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Name = user.Name,
                LastName = user.LastName
            };

            response.Token = GenerateJwtToken(response);

            return response;
        }

        private string GenerateJwtToken(AuthenticateResponseDto user)
        {
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);

            var symmetricSecurityKey = new SymmetricSecurityKey(key);

            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);

            var claimsIdentity = new ClaimsIdentity(new[] {
                new Claim("id", user.Id.ToString()),
                new Claim("username",user.UserName)
            });

            var claims = new Dictionary<string, object>
            {
                { "name", user.Name },
                { "lastName", user.LastName },
            };

            var description = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Claims = claims,
                Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiresInMinutes),
                SigningCredentials = signingCredentials
            };

            var handler = new JwtSecurityTokenHandler();

            var securityToken = handler.CreateToken(description);

            var token = handler.WriteToken(securityToken);

            return token;
        }

        public override async Task<IEntityOperationResult<UserDto>> AddAsync(UserDto dto)
        {
            var validationResult = _validator.Validate(dto);
            if (validationResult.IsValid is false)
                return validationResult.ToOperationResult<UserDto>();

            string passwordForEncryption = "12345";
            string userPassword = dto.Password;

            string encryptedPassword = StringCipher.Encrypt(userPassword, passwordForEncryption);

            dto.Password = encryptedPassword;

            User user = _mapper.Map<User>(dto);
            var entityResult = await _repository.Add(user);

            _mapper.Map(entityResult, dto);

            var result = dto.ToOperationResult();
            return result;
        }

        private bool ValidatePassword(string userPassword, string modelPassword)
        {
            string passwordForDecryption = "12345";
            string decyptedPassword = StringCipher.Decrypt(userPassword, passwordForDecryption);

            bool validPassword = (decyptedPassword == modelPassword);

            return validPassword;
        }
    }
}
