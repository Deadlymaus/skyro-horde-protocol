using UnityEngine;
using UnityEngine.InputSystem;

namespace HordeProtocol.Gameplay
{
    public class Rotation : ICommand
    {
        [SerializeField]
        private Mouse mouse;
        private Camera camera;
        private Transform objectToRotate;

        public Rotation(Mouse mouse, Camera camera, Transform objectToRotate)
        {
            this.mouse = mouse;
            this.camera = camera;
            this.objectToRotate = objectToRotate;
        }

        public void Execute()
        {
            Vector2 mousePos = mouse.position.ReadValue();
            Vector2 mouseWorldPos = camera.ScreenToWorldPoint(mousePos);
            Vector2 dir = mouseWorldPos - (Vector2)objectToRotate.position;

            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            objectToRotate.GetComponent<Rigidbody2D>().MoveRotation(angle);
        }
    }
}
