using System;
using UnityEngine;

namespace HordeProtocol.Gameplay
{
    [Serializable]
    public class Fire : ICommand
    {
        [SerializeField]
        private GameObject bullet;
        private float bulletSpeed;

        public Fire(GameObject bullet, float bulletSpeed)
        {
            this.bullet = bullet;
            this.bulletSpeed = bulletSpeed;
        }

        public void Execute()
        {
            bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.right * bulletSpeed, ForceMode2D.Force);
        }
    }
}
