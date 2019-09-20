using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    
    public float shotTimer = 0f;

    void Awake() { }

    void Update() {
        if (shotTimer > 0f) {
            shotTimer -= Time.deltaTime;
        } 

        if (Input.GetMouseButton(0)) {
            this.Shoot();
        }
    }

    void Shoot() {
        if (shotTimer > 0f) return;
        GameObject bullet = BulletPool.Get();
        Debug.Log((bullet == null).ToString());
        if (bullet == null) return;
        bullet.transform.position = this.transform.position;
        Vector3 direction = this.transform.forward;
        var bulletReference = bullet.GetComponent<Bullet>();
        bulletReference.SetOwner(this.gameObject);
        //temporary values
        bulletReference.SetProperties(5f, 5f, this.transform.forward);
        bullet.SetActive(true);
        shotTimer = Constants.BASE_SHOT_TIMER;
    }
}
