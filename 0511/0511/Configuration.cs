using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace _0511
{
    class Configuration
    {
        List<ItemValue> listConfig = new List<ItemValue>();

        public void SetConfig(string item, string value)
        {
            ItemValue iv = new ItemValue();
            iv.SetValue(this, item, value);
        }

        public string GetConfig(string item)
        {
            foreach(ItemValue iv in listConfig)
            {
                if (iv.GetItem() == item)
                    return iv.GetValue();
            }
            return "";
        }

        private class ItemValue         // inner class => Configuration 클래스 본인만 사용하고 외부로부터는 숨기기 위해 사용
        {
            private string item;
            private string value;

            public void SetValue(Configuration cg, String item, String value)
            {
                this.item = item;
                this.value = value;

                bool found = false;
                for(int i = 0; i < cg.listConfig.Count; i++)
                {
                    if (cg.listConfig[i].item == item)
                    {
                        cg.listConfig[i] = this;
                        found = true;
                        break;
                    }
                }

                if (found == false)
                    cg.listConfig.Add(this);
            }

            public string GetItem()
            {
                return item;
            }

            public string GetValue()
            {
                return value;
            }
        }
    }
}
