using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Weapon))]
public class PlayerShooting : MonoBehaviour
{
    public float shotTimer = 0f;
    public Weapon playerWeapon;
    public Transform shootPoint = null;

    void Awake() { 
        this.playerWeapon = this.gameObject.GetComponent<Weapon>();
    }

    void Update() {
        if (shotTimer > 0f) {
            shotTimer -= Time.deltaTime;
        } 
    }

    public void Shoot() {
        if (shotTimer > 0f) return;

        bool shotSuccessful = this.playerWeapon?.Shoot(this.shootPoint.position) ?? false;
        if (!shotSuccessful) return;

        shotTimer = playerWeapon.shotSpeed;
    }
}
