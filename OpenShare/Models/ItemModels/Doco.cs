using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using OpenShare.Constants;

namespace OpenShare.Models
{
    public class Doco : Item
    {
        public string Name { get; set; }
        public string TextData { get; set; }

        public Enums.ITEM_TYPE Type => Enums.ITEM_TYPE.DOCO;
    }
}
