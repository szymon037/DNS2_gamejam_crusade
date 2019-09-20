using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon 
{
    public float damage;
    public float bulletSpeed;
    public float shotSpeed;
    public virtual void Shoot() {}
}
