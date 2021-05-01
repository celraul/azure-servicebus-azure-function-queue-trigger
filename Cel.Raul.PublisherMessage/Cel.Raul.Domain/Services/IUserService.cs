using Cel.Raul.Domain.Commands;
using System.Threading.Tasks;

namespace Cel.Raul.Domain.Services
{
    public interface IUserService
    {
        public Task CreateUser(CreateUserCommand command);
    }
}
