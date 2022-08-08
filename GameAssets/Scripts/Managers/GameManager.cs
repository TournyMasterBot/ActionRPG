using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Managers
{
    public static class GameManager
    {
        public static void Initialize()
        {
            StateManager.Initialize();
            SceneManager.Initialize();
        }
    }
}
