using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolvexWorkShop.Bl.Dto
{
    public class AuthenticateResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }

        public AuthenticateResponseDto(UserDto user, string token)
        {
            Id = user.Id.GetValueOrDefault();
            Name = user.Name;
            LastName = user.LastName;
            UserName = user.UserName;
            Token = token;
        }
    }
}
