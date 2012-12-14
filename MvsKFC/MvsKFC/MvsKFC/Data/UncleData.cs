using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cocos2d;

namespace MvsKFC.Data
{

    class UncleData
    {
        public string image_path { get; set; }
        public float x { get; set; }
        public float y { get; set; }
        public UncleData(string image_path, float x, float y)
        {
            this.image_path = image_path;
            this.x = x;
            this.y = y;
        }
    }
}
