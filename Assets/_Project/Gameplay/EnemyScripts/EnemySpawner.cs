using HordeProtocol.Data;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using VContainer;

namespace HordeProtocol.Gameplay
{
    public class EnemySpawner : MonoBehaviour
    {
        public List<SO_Wave> waves;
        private int currentWaveIndex = 0;
        [SerializeField]
        private float timeToSpawn = 5f;
        [Inject]
        private EnemyFactory enemyFactory;

        public List<Transform> enemySpawns;

        private void Start()
        {
            StartCoroutine(StartNextWave());
        }

        IEnumerator StartNextWave()
        {
            foreach (SO_Enemy enemy in waves[currentWaveIndex].Enemies)
            {
                GameObject newEnemy = enemyFactory.CreateEnemy(enemy);
                if (newEnemy == null) yield return null;
                newEnemy.transform.position = enemySpawns[Random.Range(0, enemySpawns.Count)].position;

                yield return new WaitForSeconds(timeToSpawn);
            }

            currentWaveIndex++;
            StartCoroutine(StartNextWave());
        }
    }
}
