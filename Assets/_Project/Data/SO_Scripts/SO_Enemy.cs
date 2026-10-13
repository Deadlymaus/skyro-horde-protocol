using UnityEngine;

namespace HordeProtocol.Data
{
    [CreateAssetMenu(fileName = "SO_Enemy", menuName = "Enemy/New Enemy")]
    public class SO_Enemy : ScriptableObject
    {
        public string enemyName;
        public int enemyHealth;
        public float enemyMoveSpeed;
        public GameObject enemyGameObject;
    }
}
