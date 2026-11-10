using System.Collections.Generic;
using UnityEngine;

namespace HordeProtocol.Gameplay
{
    public class EnemyObjectPooling
    {
        public GameObject enemyPrefab;
        [SerializeField]
        private Queue<GameObject> EnemyPool = new Queue<GameObject>();
        [SerializeField]
        private int poolStartSize = 5;

        public GameObject GetEnemy()
        {
            if(EnemyPool.Count > 0)
            {
                GameObject enemy = EnemyPool.Dequeue();
                enemy.SetActive(true);
                return enemy;
            }
            else
            {
                return null;
            }
        }

        public void ReturnEnemy(GameObject enemy)
        {
            EnemyPool.Enqueue(enemy);
            enemy.SetActive(false);
        }

        public EnemyObjectPooling(GameObject prefab, int startSize)
        {
            enemyPrefab = prefab;
            poolStartSize = startSize;
            for (int i = 0; i < poolStartSize; i++)
            {
                GameObject enemy = GameObject.Instantiate(enemyPrefab);
                EnemyPool.Enqueue(enemy);
                enemy.SetActive(false);
            }
        }
    }
}
