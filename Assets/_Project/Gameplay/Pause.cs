using System;
using UnityEngine;

namespace HordeProtocol.Gameplay
{
    public class Pause : ICommand
    {
        [SerializeField]
        private GameObject pauseMenu;

        public Pause(GameObject pauseMenu)
        {
            this.pauseMenu = pauseMenu;
        }

        public void Execute()
        {
            pauseMenu.SetActive(true);
        }
    }
}
