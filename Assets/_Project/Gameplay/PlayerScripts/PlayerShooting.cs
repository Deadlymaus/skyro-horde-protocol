using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HordeProtocol.Gameplay
{
    public class PlayerShooting : MonoBehaviour
    {
        public float bulletSpeed = 10f;
        public float weaponCooldown = 0.5f;
        public GameObject bulletPrefab;

        bool canShoot = true;

        [HideInInspector] public PlayerInput playerInput;

        private void Update()
        {
            if(playerInput.actions["Fire"].IsPressed() && canShoot)
            {
                StartCoroutine(Shoot());
                canShoot = false;
            }
        }
        IEnumerator Shoot()
        {
            GameObject newBullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

            newBullet.GetComponent<Rigidbody2D>().AddForce(newBullet.transform.right * bulletSpeed, ForceMode2D.Force);

            if (newBullet.activeSelf)
            {
                Destroy(newBullet, 5f);
            }

            yield return new WaitForSeconds(weaponCooldown);
            canShoot = true;
        }
    }
}
