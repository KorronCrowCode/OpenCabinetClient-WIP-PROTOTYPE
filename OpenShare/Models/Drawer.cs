using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenShare.Exceptions;
using OpenShare.Models;
using OpenShare.Constants;
namespace OpenShare.Models
{
    public class Drawer
    {
        public readonly List<Item> _items = [];
        public readonly Enums.LAYOUT _layout;
        public readonly Enums.PRIVACY _privacy;
        public string Name;
        public readonly string Owner;//not yet implemented

        public Drawer(Enums.LAYOUT layout, Enums.PRIVACY privacy, string name, string owner)
        {
            _layout = layout;
            _privacy = privacy;
            Name = name;
            Owner = owner;
        }

        public Item createNote(string name, string textData)
        {
            return new Note{Name=name, TextData=textData};
        }

        public void AddItem(Item item)
        {
            foreach(Item existingItem in _items)
            {
                if(Conflicts(item))
                {
                    throw new ItemConflictException(existingItem, item);
                }

            }
        }

        public List<Item> GetAllItems() { return _items; }

        private bool Conflicts(Item item)
        {
            bool hasConflict = false;
            //check if drawer contains item name
            foreach(Item existingItem in _items)
            {
               if(existingItem.Name.Equals(item.Name))
                {
                    hasConflict = true; 
                }
            }

            return hasConflict;
        }

    }
}
