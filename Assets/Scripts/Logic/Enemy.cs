using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Logic
{
    public interface Enemy
    {
        public int Speed { get; set; }
        public int Health { get; set; }

        void TakeDamage(int damage);
        void Die();
    }
}
