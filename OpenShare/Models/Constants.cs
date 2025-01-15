using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenShare.Constants
{
    public class Enums
    {
        public enum VALID_ENUMS { LAYOUT = 0, PRIVACY = 1};
        public enum LAYOUT { FILE = 0, IMAGE = 1, NOTE = 2 }
        public enum PRIVACY { PUBLIC = 0, PRIVATE = 1 }
        public enum ITEM_TYPE { DOCO = 0, IMAGE = 1, NOTE = 2 }
        public static LAYOUT? StringToLayoutEnum(String str)
        {
            if(str.Equals("FILE"))
            {
                return LAYOUT.FILE;
            }
            else if(str.Equals("IMAGE"))
            {
                return LAYOUT.IMAGE;
            }
            else if(str.Equals("NOTE"))
            {
                return LAYOUT.NOTE;
            }
            else
            {
                return null;
            }
        }


        public static PRIVACY? StringToPrivacyEnum(String str)
        {
            if (str.Equals("PUBLIC"))
            {
                return PRIVACY.PUBLIC;
            }
            else if (str.Equals("PRIVATE"))
            {
                return PRIVACY.PRIVATE;
            }
            else
            {
                return null;
            }
        }


        public static List<string> GetEnumAsStringList(VALID_ENUMS VE)
        {
            List<string> list = [];
            if(VE == VALID_ENUMS.LAYOUT)
            {
                foreach(LAYOUT l in Enum.GetValues(typeof(LAYOUT)))
                {
                    list.Add(l.ToString());
                }
            }
            else if (VE == VALID_ENUMS.PRIVACY)
            {
                foreach (PRIVACY p in Enum.GetValues(typeof(PRIVACY)))
                {
                    list.Add(p.ToString());
                }
            }

            return list;
        }

        public static ITEM_TYPE? StringToTypeEnum(String str)
        {
            if (str.Equals("DOCO"))
            {
                return ITEM_TYPE.DOCO;
            }
            else if (str.Equals("IMAGE"))
            {
                return ITEM_TYPE.IMAGE;
            }
            else if (str.Equals("NOTE"))
            {
                return ITEM_TYPE.NOTE;
            }
            else
            {
                return null;
            }
        }
    }
}
