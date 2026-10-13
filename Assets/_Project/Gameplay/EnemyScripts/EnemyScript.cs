using HordeProtocol.Data;
using UnityEngine;

namespace HordeProtocol.Gameplay
{
    public class EnemyScript : MonoBehaviour, IDamageable
    {
        public SO_Enemy enemyScriptableObject;
        public Rigidbody2D rb;

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
            Destroy(gameObject);
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log("something0");
            if (collision.gameObject.CompareTag("bullet"))
            {
                TakeDamage();
                Destroy(collision.gameObject);
            }
        }
    }
}
