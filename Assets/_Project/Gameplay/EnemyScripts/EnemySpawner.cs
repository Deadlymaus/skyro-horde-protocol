using System.Collections.Generic;
using UnityEngine;

namespace HordeProtocol.Gameplay
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField]
        private float timeToSpawn = 5f;
        private float timeSinceSpawn;
        private EnemyObjectPooling enemyPooling;

        public List<GameObject> enemySpawns;

        private void Start()
        {
            enemyPooling = FindFirstObjectByType<EnemyObjectPooling>();
        }

        private void Update()
        {
            timeSinceSpawn += Time.deltaTime;
            if(timeSinceSpawn >= timeToSpawn)
            {
                GameObject newEnemy = enemyPooling.GetEnemy();
                if (newEnemy == null) return;

                newEnemy.transform.position = enemySpawns[Random.Range(0, enemySpawns.Count)].transform.position;
                timeSinceSpawn = 0f;
            }
        }
    }
}
