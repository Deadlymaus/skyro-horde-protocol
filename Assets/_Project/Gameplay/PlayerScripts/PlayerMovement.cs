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
            Vector2 moveInput = playerInput.actions["Move"].ReadValue<Vector2>();
            Vector2 newPos = rb.position + moveInput * moveSpeed * Time.fixedDeltaTime;
            rb.MovePosition(newPos);

            Vector2 mousePos = Mouse.current.position.ReadValue();
            Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);
            Vector2 dir = mouseWorldPos - (Vector2)transform.position;

            if (dir.sqrMagnitude > 0.0001f)
            {
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                GetComponent<Rigidbody2D>().MoveRotation(angle);
            }
        }
    }
}
