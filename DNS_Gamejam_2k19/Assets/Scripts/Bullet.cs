using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private GameObject owner = null;
    private Vector3 direction;
    public float expireTimer;
    public float damage;
    public float bulletSpeed;


    // Start is called before the first frame update
    void Start()
    {
        this.expireTimer = Constants.BULLET_EXPIRE_TIMER;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.expireTimer > 0f) {
            this.expireTimer -= Time.deltaTime;
        } else {
            BulletPool.Reclaim(this.gameObject);
        }
        
    }

    void FixedUpdate() {
        if (this.gameObject.activeSelf) {
            transform.Translate(direction * bulletSpeed);
        }
    }

    public void Clear() {
        this.owner = null;
        this.damage = 0f;
        this.bulletSpeed = 0f;
        this.direction = Vector3.zero;
    }

    public void SetProperties(float damage, float bulletSpeed, Vector3 direction) {
        this.direction = direction;
        this.damage = damage;
        this.bulletSpeed = bulletSpeed;
        this.expireTimer = Constants.BULLET_EXPIRE_TIMER;
    }

    public void SetOwner(GameObject owner) {
        this.owner = owner;
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Car")) {
            
        }
    }
}
