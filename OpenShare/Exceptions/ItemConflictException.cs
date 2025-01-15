using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenShare.Models;

namespace OpenShare.Exceptions
{
    public class ItemConflictException : Exception
    {
        public Item ExistingItem { get; }
        public Item IncomingItem { get; }

        public ItemConflictException(Item existingItem, Item incomingItem)
        {
            ExistingItem = existingItem;
            IncomingItem = incomingItem;
        }
        public ItemConflictException(string message, Item existingItem, Item incomingItem) : base(message) 
        {
            ExistingItem = existingItem;
            IncomingItem = incomingItem;
        }
        public ItemConflictException(string message, Exception innerException, Item existingItem, Item incomingItem) : base(message, innerException)
        {
            ExistingItem = existingItem;
            IncomingItem = incomingItem;
        }
    }
}
