using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool Instance { get; private set; } //Singleton

    [SerializeField] GameObject bulletPrefab;
    [SerializeField] int poolSize = 30;
    [Space]

    [SerializeField] GameObject muzzleflashPrefab;
    [SerializeField] int muzzleflashPoolSize = 30;

    List<GameObject> bulletsBool;
    List<GameObject> muzzleflashes;

    private void Awake() //Singleton
    {
        if (Instance != null)
        {
            Debug.LogError("There's more than one BulletBool! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    void Start()
    {
        bulletsBool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bulletsBool.Add(bullet);
        }

        muzzleflashes = new List<GameObject>();

        for (int i = 0; i < muzzleflashPoolSize; i++)
        {
            GameObject muzzleflash = Instantiate(muzzleflashPrefab);
            muzzleflash.SetActive(false);
            muzzleflashes.Add(muzzleflash);
        }
    }

    public GameObject GetBullet()
    {
        foreach (var bullet in bulletsBool)
        {
            if (!bullet.activeInHierarchy)
            {
                bullet.SetActive(true);
                return bullet;
            }
        }

        GameObject newBullet = Instantiate(bulletPrefab);
        bulletsBool.Add(newBullet);
        return newBullet;
    }


    public GameObject GetMuzzleflash()
    {
        foreach (var muzzleflash in muzzleflashes)
        {
            if (!muzzleflash.activeInHierarchy)
            {
                muzzleflash.SetActive(true);
                return muzzleflash;
            }
        }

        GameObject newMuzzleflash = Instantiate(muzzleflashPrefab);
        muzzleflashes.Add(newMuzzleflash);
        return newMuzzleflash;
    }

    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);
    }

    public void ReturnMuzzleflash(GameObject muzzleflash)
    {
        muzzleflash.SetActive(false);
    }
}
