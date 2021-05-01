namespace Cel.Raul.Domain.Commands
{
    public class CreateUserCommand : ICommand
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Doc { get; set; }

        public bool IsValid() => (!string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Doc));
    }
}
