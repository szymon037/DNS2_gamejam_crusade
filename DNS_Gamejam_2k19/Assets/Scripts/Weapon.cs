using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float damage;
    public float bulletSpeed;
    public float shotSpeed;
    public AudioSource audioSource;

    void Awake() {
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    public bool Shoot(Vector3 origin, Vector3 direction) {
        GameObject bullet = BulletPool.Get();
        if (bullet == null) return false;
        Bullet bulletProperties = bullet.GetComponent<Bullet>();
        bullet.transform.position = origin;
        bulletProperties.SetOwner(this.gameObject);
        bulletProperties.SetProperties(this.damage, this.bulletSpeed, direction);
        bullet.SetActive(true);
        return true;
    }
}
