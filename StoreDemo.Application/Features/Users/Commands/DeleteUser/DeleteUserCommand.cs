using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreDemo.Application.Features.Users.Commands.DeleteUser;
public record DeleteUserCommand
{
    public int UserId { get; set; }
}
