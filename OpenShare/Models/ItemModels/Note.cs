using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenShare.Constants;

namespace OpenShare.Models
{
    public class Note : Item
    {
        public required string Name { get; set; }
        public string TextData { get; set; } = "";
        public Enums.ITEM_TYPE Type { get; } = Enums.ITEM_TYPE.NOTE;

       
    }
}
