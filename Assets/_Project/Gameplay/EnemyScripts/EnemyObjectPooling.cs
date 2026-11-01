using System.Collections.Generic;
using UnityEngine;

namespace HordeProtocol.Gameplay
{
    public class EnemyObjectPooling : MonoBehaviour
    {
        [SerializeField]
        private GameObject enemyPrefab;
        [SerializeField]
        private Queue<GameObject> EnemyPool = new Queue<GameObject>();
        [SerializeField]
        private int poolStartSize = 5;

        private void Start()
        {
            for (int i = 0; i < poolStartSize; i++)
            {
                GameObject enemy = Instantiate(enemyPrefab);
                EnemyPool.Enqueue(enemy);
                enemy.SetActive(false);
            }
        }
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
    }
}
