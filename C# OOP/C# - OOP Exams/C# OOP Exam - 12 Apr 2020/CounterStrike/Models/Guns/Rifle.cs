using System;
using System.Collections.Generic;
using System.Text;

namespace CounterStrike.Models.Guns
{
    public class Rifle : Gun
    {
        private const int FIRED_BULLETS = 10;
        public Rifle(string name, int bulletsCount)
            : base(name, bulletsCount)
        {
        }

        public override int Fire()
        {
            if (this.BulletsCount - FIRED_BULLETS < 0)
            {
                return this.BulletsCount;
            }
            else if (this.BulletsCount == 0)
            {
                return 0;
            }
            this.BulletsCount -= FIRED_BULLETS;

            return FIRED_BULLETS;
        }
    }
}
