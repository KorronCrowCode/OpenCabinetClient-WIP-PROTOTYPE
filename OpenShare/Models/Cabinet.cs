using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenShare.Constants;
using OpenShare.Exceptions;
using OpenShare.ViewModels.ComponentViewModels;

namespace OpenShare.Models
{
    public class Cabinet
    {
        private List<Drawer> _drawers = [];

        public Cabinet()
        {
            //test data

            _drawers.Add(new Drawer(Enums.LAYOUT.NOTE, Enums.PRIVACY.PRIVATE, "test1", "admin"));
            _drawers.Add(new Drawer(Enums.LAYOUT.NOTE, Enums.PRIVACY.PRIVATE, "test2", "admin"));
            _drawers.Add(new Drawer(Enums.LAYOUT.NOTE, Enums.PRIVACY.PRIVATE, "test3", "admin"));
        }
       
        public void CreateDrawer(Drawer drawer)
        {
            foreach (Drawer existingDrawer in _drawers)
            {
                if (Conflicts(drawer))
                {
                    throw new DrawerConflictException(existingDrawer, drawer);
                }
            }
            _drawers.Add(drawer);
        }

        public Drawer getDrawer(string name)
        {
            Drawer drawer = null;
            foreach (Drawer existingDrawer in _drawers)
            {
                if (drawer.Name.Equals(name))
                {
                    drawer = existingDrawer;
                    break;
                }
            }
                return drawer;

        }

        public void setDrawer(Drawer drawer)
        {
            int targetIndex = -1;
            foreach(Drawer existingDrawer in _drawers)
            {
                if(existingDrawer.Name.Equals(drawer.Name))
                {
                    targetIndex = _drawers.IndexOf(existingDrawer);
                    break;
                }
            }

            _drawers[targetIndex] = drawer;
        }

        public List<Drawer> GetAllDrawers()
        {
            return _drawers;
        }

        public void AddDrawer(Drawer drawer)
            { _drawers.Add(drawer); }


        private bool Conflicts(Drawer drawer)
        {
            bool hasConflict = false;
            //check if drawer contains item name
            foreach (Drawer existingDrawer in _drawers)
            {
                if (existingDrawer.Name.Equals(drawer.Name))
                {
                    hasConflict = true;
                }
            }

            return hasConflict;
        }
    }
}
