using VContainer;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HordeProtocol.Gameplay
{
    public class Player : MonoBehaviour, IDamageable
    {
        public PlayerInput playerInput;

        public PlayerMovement playerMovement;
        public PlayerShooting playerShooting;

        [Inject]
        private UI_References uiReferences;
        [Inject]
        private GameState gameState;

        public void TakeDamage()
        {
            gameState.hasDied = true;
            gameState.ChangeState();
        }

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

        void Update()
        {
            if (playerInput.actions["Pause"].IsPressed())
            {
                gameState.isPaused = true;
                gameState.ChangeState();
                uiReferences.SendPauseCommand();
            }
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("enemy"))
            {
                TakeDamage();
            }
        }
    }
}

public interface IDamageable
{
    public void TakeDamage();
}
