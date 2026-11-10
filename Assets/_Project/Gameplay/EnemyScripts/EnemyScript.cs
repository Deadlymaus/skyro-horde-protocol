using HordeProtocol.Data;
using System;
using UnityEngine;
using VContainer;

namespace HordeProtocol.Gameplay
{
    public class EnemyScript : MonoBehaviour, IDamageable
    {
        public SO_Enemy enemyScriptableObject;
        public Rigidbody2D rb;

        [Inject]
        private EnemyObjectPooling enemyObjectPooling;
        [Inject]
        private BulletObjectPooling bulletObjectPooling;

        public static event Action EnemyHasDied;


        private void Start()
        {
            enemyScriptableObject = Instantiate(enemyScriptableObject);
            if (rb == null) rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            transform.position = Vector2.MoveTowards(transform.position, FindFirstObjectByType<Player>().gameObject.transform.position, enemyScriptableObject.enemyMoveSpeed * Time.deltaTime);
        }

        public void TakeDamage()
        {
            if (enemyObjectPooling != null)
                enemyObjectPooling.ReturnEnemy(gameObject);
            EnemyHasDied?.Invoke();
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("bullet"))
            {
                TakeDamage();
                if (bulletObjectPooling != null)
                    bulletObjectPooling.ReturnBullet(collision.gameObject);
            }
        }
    }
}
