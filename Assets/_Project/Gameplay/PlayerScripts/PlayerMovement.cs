using UnityEngine;
using UnityEngine.InputSystem;

namespace HordeProtocol.Gameplay
{
    public class PlayerMovement : MonoBehaviour
    {
        [HideInInspector]public PlayerInput playerInput;
        public float moveSpeed = 5f;

        private void Start()
        {
            if (playerInput == null) { GetComponent<PlayerInput>();}

        }
        private void Update()
        {
            Vector2 movementInput = playerInput.actions["Move"].ReadValue<Vector2>();
            Vector3 movement = new Vector3(movementInput.x, movementInput.y, 0);
            transform.Translate(movement * Time.deltaTime * moveSpeed);
        }
    }
}
