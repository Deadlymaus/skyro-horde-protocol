using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using VContainer;

namespace HordeProtocol.Gameplay
{
    public class PlayerShooting : MonoBehaviour
    {
        public float bulletSpeed = 10f;
        public float weaponCooldown = 0.5f;

        [Inject]
        private BulletObjectPooling bulletObjectPooling;

        bool canShoot = true;

        [HideInInspector] public PlayerInput playerInput;

        private void Start()
        {
        }

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
            GameObject newBullet = bulletObjectPooling.GetBullet();
            newBullet.transform.position = transform.position;
            newBullet.transform.rotation = transform.rotation;

            SendFireCommand(newBullet, bulletSpeed);

            yield return new WaitForSeconds(weaponCooldown);
            canShoot = true;

            yield return new WaitForSeconds(5f);
            if (newBullet.activeSelf)
                bulletObjectPooling.ReturnBullet(newBullet);
        }

        private void SendFireCommand(GameObject bullet, float bulletSpeed)
        {
            ICommand shooting = new Fire(bullet, bulletSpeed);
            shooting.Execute();
        }
    }
}
