using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarStats : MonoBehaviour
{
    public float speed;
    public float mass;
    public float health;

    void Start() {
        health = Constants.BASE_HEALTH_VALUE;
        mass = Constants.BASE_MASS_VALUE;
        speed = Constants.BASE_SPEED;
    }

    public void ReduceHealth(float damage) {
        health -= damage;
    }
}
