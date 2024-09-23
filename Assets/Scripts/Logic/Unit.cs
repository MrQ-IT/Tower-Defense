using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Logic
{
    public interface Unit
    {
        public int attackRange { get; set; }

        public void ShootArrow();
    }
}
