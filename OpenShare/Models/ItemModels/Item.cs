using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenShare.Constants;
using static OpenShare.Constants.Enums;

namespace OpenShare.Models
{
    public interface Item
    {
        public string Name { get; set; }
        public string TextData { get; set; }
        public Enums.ITEM_TYPE Type { get; }


    }
}
