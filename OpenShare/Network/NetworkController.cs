using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using OpenShare.Models;
using OpenShare.Models.Json;
using static OpenShare.Models.Json.DrawerListReq;
using System.Text.Json;
using System.Windows.Media.Animation;
using OpenShare.Constants;

namespace OpenShare.Network
{
    public class NetworkController
    {
        public Cabinet _cabinet { get; } = new Cabinet();
        public string drawerToAccess { get; set; }

        public List<Drawer> GetValidDrawers(string username)
        {
            var valid = new List<Drawer>();
            foreach(Drawer d in _cabinet.GetAllDrawers())
            {
                if(d.Owner.Equals(username))
                {
                    valid.Add(d);
                }
            }
            return valid;

        }

        public Drawer? GetDrawer(string name, string username)
        {
            foreach (Drawer d in GetValidDrawers(username))
            {
                if (d.Name.Equals(name))
                {
                    return d;
                }
            }
            return null;
        }

        public List<Item> GetItems(string name, string username)
        {
            return GetDrawer(name, username).GetAllItems()??new List<Item>();
        }

        public void AddDrawer(Drawer d)
        {
            _cabinet.AddDrawer(d);
        }

        public void AddItem(Item item, string drawerName, string type)
        {
            if(type.Equals("NOTE"))
            {
                Drawer d = GetDrawer(drawerName, "admin");
                d.AddItem((Note) item);
                _cabinet.setDrawer(d);
            }
            
        }

    }
}
