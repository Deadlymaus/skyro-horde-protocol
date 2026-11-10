using System.Collections.Generic;
using UnityEngine;
using HordeProtocol.Data;

namespace HordeProtocol.Gameplay
{
    public class EnemyFactory : MonoBehaviour
    {
        private List<EnemyObjectPooling> enemyPooling;


        public GameObject CreateEnemy(SO_Enemy enemyData)
        {
            foreach (EnemyObjectPooling pooling in enemyPooling)
            {
                if (pooling.enemyPrefab == enemyData.enemyGameObject)
                {
                    GameObject newEnemy = pooling.GetEnemy();
                    if (newEnemy == null) return null;
                    return newEnemy;
                }
                else
                {
                    enemyPooling.Add(new EnemyObjectPooling(enemyData.enemyGameObject, 5));
                    GameObject newEnemy = enemyPooling[enemyPooling.Count - 1].GetEnemy();

                    if (newEnemy == null) return null;
                    return newEnemy;
                }
            }
            return null;
        }
    }
}
