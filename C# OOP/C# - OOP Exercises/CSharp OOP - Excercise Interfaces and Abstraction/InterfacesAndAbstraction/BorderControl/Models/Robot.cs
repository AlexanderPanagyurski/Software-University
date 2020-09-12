using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Robot:IIdentifiable
    {
        public string Name { get; private set; }

        public string Id { get; private set; }

        public Robot(string name, string id)
        {
            this.Name = name;
            this.Id = id;
        }

        public bool isFakeId(string fakeNumbers)
        {
            return this.Id.EndsWith(fakeNumbers) ? true : false;
        }
    }
}
