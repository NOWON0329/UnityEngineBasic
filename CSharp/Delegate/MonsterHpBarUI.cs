using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    internal class MonsterHpBarUI
    {
        public float barValue;
        public MonsterHpBarUI(Monster owner)
        {
            owner.OnHpChange += Refresh;
        }

        public void Refresh(float value) => barValue = value;
    }
}
