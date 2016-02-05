using System.Collections.Generic;

namespace Business.Commands
{
    public class GetAddressesByPersonCommand : ICommand
    {
         public int PersonId { get; set; }
    }

    public class GetAddressesByPersonCommandResult : ICommandResult
    {
        public int PersonId { get; set; }

        public IEnumerable<PersonAddress> Addresses { get; set; } 
    }

    public class PersonAddress
    {
        public string Street { get; set; }

        public string City { get; set; }
    }
}