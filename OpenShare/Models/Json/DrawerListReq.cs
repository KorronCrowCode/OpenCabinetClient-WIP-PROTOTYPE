using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenShare.Models.Json
{
    public class DrawerListReq
    {
        public string _header { get; set; }
        public class Body
        {
            public string _username { get; set; }
        }
        public Body _body { get; set; }

        public DrawerListReq(string header, string username)
        {
            _header = header;
            _body = new Body{_username=username};
        }
    }
}
