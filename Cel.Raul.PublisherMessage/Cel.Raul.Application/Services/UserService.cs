using Cel.Raul.AzureQueue.Interfaces;
using Cel.Raul.AzureQueue.Messages;
using Cel.Raul.Domain.Commands;
using Cel.Raul.Domain.Services;
using System.Threading.Tasks;

namespace Cel.Raul.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IQueueCommunicator _queueCommunicator;

        public UserService(IQueueCommunicator queueCommunicator)
        {
            _queueCommunicator = queueCommunicator;
        }

        public async Task CreateUser(CreateUserCommand command)
        {
            if (!command.IsValid())
                return;

            // Create user here
            
            var thankYouEmail = new SendEmailCommand()
            {
                To = command.Email,
                Subject = "Thank you for create your account",
                Body = $"hello, {command.Name}"
            };

            // send to Queue
            await _queueCommunicator.SendAsync(thankYouEmail);
        }
    }
}
