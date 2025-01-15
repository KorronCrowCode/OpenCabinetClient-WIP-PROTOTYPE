using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenShare.Models;

namespace OpenShare.Exceptions
{
    public class DrawerConflictException : Exception
    {
        public Drawer ExistingDrawer { get; }
        public Drawer IncomingDrawer { get; }

        public DrawerConflictException(Drawer existingDrawer, Drawer incomingDrawer)
        {
            ExistingDrawer = existingDrawer;
            IncomingDrawer = incomingDrawer;
        }
        public DrawerConflictException(string message, Drawer existingDrawer, Drawer incomingDrawer) : base(message)
        {
            ExistingDrawer = existingDrawer;
            IncomingDrawer = incomingDrawer;
        }
        public DrawerConflictException(string message, Exception innerException, Drawer existingDrawer, Drawer incomingDrawer) : base(message, innerException)
        {
            ExistingDrawer = existingDrawer;
            IncomingDrawer = incomingDrawer;
        }
    }
}

