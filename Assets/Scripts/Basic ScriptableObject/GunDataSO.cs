using UnityEngine;

[CreateAssetMenu(fileName = "newGunData", menuName = "ScriptableObjects/GunData", order = 1)]
public class GunData : ScriptableObject
{
    [Header("Info")]
    public string gunName;
    [Multiline(10)] string description;
    public Sprite itemSprite;
    [Space]

    [Header("Audios")]
    //public AudioEvent shoot; // Audio event play sound
    //public AudioEvent reload;

    [Header("Gun Attributes")]
    [Range(10f, 1000f)] public float fireRate = 100f;
    [Range(1, 200)] public int damage = 10;
    [Range(1, 100)] public int magazineSize = 30;
    [Range(0.5f, 10f)] public float reloadTime = 1f;
    [Space]

    [Header("Bullet parameters")]
    [Range(0f, 10f)] public float scatterAngle = 1f; // Angle of scatter in degrees
    [Range(1, 100)] public int bulletsPerShot = 1; // Number of bullets to fire in one shot
    [Range(0.5f, 100f)] public float bulletSpeed = 10f;
    [Range(0.5f, 10f)] public float bulletLifeTime = 2f; //Range of bullet life time
    [Space]

    [Header("Physical Forces")]
    [Range(0.1f, 10f)] public float pushingForce = 1f; //Push enemy back
    [Range(0.1f, 10f)] public float slowMotion = 1f; //Slow enemy movement

}