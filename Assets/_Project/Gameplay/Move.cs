using System;
using UnityEngine;

namespace HordeProtocol.Gameplay
{
    [Serializable]
    public class Move : ICommand
    {
        [SerializeField]
        private Vector2 direction = Vector3.zero;
        private float moveSpeed;
        private Transform objectToMove;

        public Move(Vector2 direction, float moveSpeed, Transform objectToMove)
        {
            this.direction = direction;
            this.moveSpeed = moveSpeed;
            this.objectToMove = objectToMove;
        }

        public void Execute()
        {
            objectToMove.position += moveSpeed * Time.deltaTime * (Vector3)direction;
        }
    }
}
