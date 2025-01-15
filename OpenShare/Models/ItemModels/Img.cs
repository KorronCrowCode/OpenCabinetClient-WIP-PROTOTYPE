using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using OpenShare.Constants;

namespace OpenShare.Models
{
    public class Img : Item
    {
        public string Name { get; set; }
        public string TextData { get; set; }

        public Enums.ITEM_TYPE Type => Enums.ITEM_TYPE.IMAGE;
    }
}
