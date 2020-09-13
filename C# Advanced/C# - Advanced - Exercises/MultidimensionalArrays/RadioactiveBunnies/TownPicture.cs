using System;
using System.Collections.Generic;
using System.Text;

namespace RadioactiveBunnies
{
    public class TownPicture
    {
        //4
        string mPicName = "";
        string mTownName = "";

        //5
        public TownPicture()
        {

        }
        //
        public TownPicture(string mPicName, string mTownName)
        {
            this.mPicName = mPicName;
            this.mTownName = mTownName;
        }
    }
}
