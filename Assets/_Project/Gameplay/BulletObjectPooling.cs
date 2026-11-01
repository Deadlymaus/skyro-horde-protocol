using System.Collections.Generic;
using UnityEngine;

namespace HordeProtocol.Gameplay
{
    public class BulletObjectPooling : MonoBehaviour
    {
        [SerializeField]
        private GameObject bulletPrefab;
        [SerializeField]
        private Queue<GameObject> BulletPool = new Queue<GameObject>();
        [SerializeField]
        private int poolStartSize = 10;

        private void Start()
        {
            for (int i = 0; i < poolStartSize; i++)
            {
                GameObject bullet = Instantiate(bulletPrefab);
                BulletPool.Enqueue(bullet);
                bullet.SetActive(false);
            }
        }
        public GameObject GetBullet()
        {
            if (BulletPool.Count > 0)
            {
                GameObject bullet = BulletPool.Dequeue();
                bullet.SetActive(true);
                return bullet;
            }
            else
            {
                GameObject bullet = Instantiate(bulletPrefab);
                BulletPool.Enqueue(bullet);

                bullet = BulletPool.Dequeue();
                bullet.SetActive(true);
                return bullet;
            }
        }

        public void ReturnBullet(GameObject bullet)
        {
            BulletPool.Enqueue(bullet);
            bullet.SetActive(false);
        }
    }
}
