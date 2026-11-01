using UnityEngine;
using UnityEngine.InputSystem;

namespace HordeProtocol.Gameplay
{
    public class PlayerMovement : MonoBehaviour
    {
        [HideInInspector] public PlayerInput playerInput;
        public float moveSpeed = 5f;
        Rigidbody2D rb;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            if (playerInput.actions["Move"].IsPressed())
            {
                Vector2 moveInput = playerInput.actions["Move"].ReadValue<Vector2>();
                SendMoveCommand(moveInput, moveSpeed, gameObject.transform);
            }
            SendRotateCommand(Mouse.current, Camera.main, gameObject.transform);
        }

        private void SendMoveCommand(Vector2 direction, float moveSpeed, Transform objectToMove)
        {
            ICommand movement = new Move(direction, moveSpeed, objectToMove);
            movement.Execute();
        }

        private void SendRotateCommand(Mouse mouse, Camera camera, Transform objectToRotate)
        {
            ICommand rotation = new Rotation(mouse, camera, objectToRotate);
            rotation.Execute();
        }
    }
}
