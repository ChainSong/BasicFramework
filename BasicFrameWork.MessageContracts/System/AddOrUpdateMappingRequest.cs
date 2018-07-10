using System.Collections.Generic;
using BasicFramework.Entity;

namespace BasicFramework.MessageContracts
{
    public  class AddOrUpdateMappingRequest
    {
        public IEnumerable<Mapping> MapingCollection { get; set; }
    }
}
