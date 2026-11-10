using System.Collections.Generic;
using UnityEngine;

namespace HordeProtocol.Gameplay
{
    public class BulletObjectPooling
    {
        [SerializeField]
        private GameObject bulletPrefab;
        [SerializeField]
        private Queue<GameObject> BulletPool = new Queue<GameObject>();
        [SerializeField]
        private int poolStartSize = 10;
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
                GameObject bullet = GameObject.Instantiate(bulletPrefab);
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

        public BulletObjectPooling(GameObject prefab, int startSize)
        {
            bulletPrefab = prefab;
            poolStartSize = startSize;
            for (int i = 0; i < poolStartSize; i++)
            {
                GameObject bullet = GameObject.Instantiate(bulletPrefab);
                BulletPool.Enqueue(bullet);
                bullet.SetActive(false);
            }
        }
    }
}
