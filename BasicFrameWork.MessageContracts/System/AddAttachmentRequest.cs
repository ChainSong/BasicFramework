using System.Collections.Generic;
using BasicFramework.Entity;

namespace BasicFramework.MessageContracts
{
    public class AddAttachmentRequest
    {
        public IEnumerable<Attachment> attachments { get; set; }

        public bool IsCoverOld { get; set; }
    }
}