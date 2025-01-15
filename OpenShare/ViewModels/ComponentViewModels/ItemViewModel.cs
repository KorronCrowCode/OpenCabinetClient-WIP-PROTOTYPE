using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenShare.Constants;
using OpenShare.Models;

namespace OpenShare.ViewModels.ComponentViewModels
{
    public class ItemViewModel(Item item) : ViewModelBase
    {
        private readonly Item _item = item;
        public string Name => _item.Name;
        public string Type => _item.Type.ToString();
        public string TextData => item.TextData;

        private Object? getItemObject(Item item)
        {
            if(item.Type==Enums.ITEM_TYPE.DOCO)
            {
                Doco doco = (Doco)item;
                return doco.TextData;
            }
            else if(item.Type == Enums.ITEM_TYPE.IMAGE)
            {
                Img img = (Img)item;
                return img.TextData;
            }
            else if(item.Type == Enums.ITEM_TYPE.NOTE)
            {
                Note note = (Note)item;
                return note.TextData;
            }
            else
            {
                return null;
            }
        }
    }
}
