using System.Collections.Generic;
using BasicFramework.Entity;
namespace BasicFramework.MessageContracts
{
    public class UserRequestAndResponse
    {
        public IEnumerable<User> UserCollection { get; set; }

        public User User { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int PageCount { get; set; }

        public int TotalCount { get; set; } 
    }
}