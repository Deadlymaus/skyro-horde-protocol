using UnityEngine;
using UnityEngine.InputSystem;

namespace HordeProtocol.Gameplay
{
    public class Player : MonoBehaviour
    {
        public PlayerInput playerInput;

        public PlayerMovement playerMovement;
        public PlayerShooting playerShooting;

        private void Start()
        {
            if (playerInput == null)
            {
                playerInput = GetComponent<PlayerInput>();
            }
            if (playerMovement == null)
            {
                playerMovement = GetComponent<PlayerMovement>();
                playerMovement.playerInput = playerInput;
            }
            if (playerShooting == null)
            {
                playerShooting = GetComponent<PlayerShooting>();
                playerShooting.playerInput = playerInput;
            }

            playerMovement.playerInput = playerInput;
            playerShooting.playerInput = playerInput;
        }
    }
}
