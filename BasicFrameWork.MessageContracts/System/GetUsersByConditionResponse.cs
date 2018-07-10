using System.Collections.Generic;
using BasicFramework.Entity;

namespace BasicFramework.MessageContracts
{
    public class GetUsersByConditionResponse
    {
        public IEnumerable<User> Users { get; set; }

        public int PageCount { get; set; }

        public int PageIndex { get; set; }
    }
}