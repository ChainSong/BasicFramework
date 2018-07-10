using System.Collections.Generic;
using BasicFramework.Entity;

namespace BasicFramework.MessageContracts
{
    public class AddOrUpdateUserRequest
    {
        public IEnumerable<User> UserCollection { get; set; }
    }
}
