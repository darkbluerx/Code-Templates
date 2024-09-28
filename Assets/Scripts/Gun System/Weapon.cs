using System.Collections;
using UnityEngine;

namespace weapon
{
    public class Weapon : MonoBehaviour
    {
        public virtual GameObject muzzleFlash { get; set; } //Muzzle flash effect
        public virtual GameObject bulletPrefab { get; set; }
        public virtual Vector3 bulletSpread { get; set; }
        public virtual Transform firePoint { get; set; } //Where the bullet is spawned

        public virtual int maxAmmo { get; set; } //Ammo what you have
        public virtual int currentAmmo { get; set; } //Bullets left in the magazine

        public virtual bool canShoot { get; set; } = true;
        public virtual bool isReloading { get; set; }


        // this method inherits from the Gun class. if you want to use this method, you need to override it in the child class
        // using Generate Overrides -> override method, you can create this method in the child class
        // Example: press right mouse button  in the inherit class and select Generate Overrides -> override method -> Shoot()
        public virtual IEnumerator Shoot() { yield return null; }

        public virtual Vector3 ProjectileScatter()
        {
            float randomX = Random.Range(-1, 1);
            //float randomY = Random.Range(0, 0);
            float randomZ = Random.Range(-1, 1);
            bulletSpread = new Vector3(randomX, 0, randomZ);

            return bulletSpread;
        }

        public virtual IEnumerator Reload() { yield return null; }
    }
}
