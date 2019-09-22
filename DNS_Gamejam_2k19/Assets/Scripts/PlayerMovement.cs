using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerShooting))]
public class PlayerMovement : MonoBehaviour
{
    public PlayerShooting shootingScript;
    public CarStats stats;
    public int id;
    private string leftStickVertical;
    private string leftStickHorizontal;
    private string rightStickHorizontal;
    private string rightStickVertical;
    private string shootButton;

    void OnDestroy() {

    }

    // Start is called before the first frame update
    void Start()
    {
        this.shootingScript = this.gameObject.GetComponent<PlayerShooting>();
        leftStickVertical = $"GamepadVertical{id}";
        leftStickHorizontal = $"GamepadHorizontal{id}";
        rightStickHorizontal = $"GamepadRightHorizontal{id}";
        rightStickVertical = $"GamepadRightVertical{id}";
        shootButton = $"joystick {id} button 5";
        this.stats = this.gameObject.GetComponent<CarStats>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (Input.GetKeyDown(shootButton)) {
            shootingScript.Shoot();
        }

        if (this.stats.health <= 0f) {
            Die();
        }

        Rotate();
    }

    void Move() {
        float x = -Input.GetAxis(leftStickHorizontal), z = Input.GetAxis(leftStickVertical);
        transform.Translate(new Vector3(x, 0f, z) * this.stats.speed * Time.deltaTime);
    }

    void Rotate() {
        float x = Input.GetAxis(rightStickHorizontal), z = -Input.GetAxis(rightStickVertical);
        Vector3 direction = new Vector3(x, 0f, z);
        Quaternion rot = Quaternion.LookRotation(-direction, Vector3.up);
        shootingScript.RotateShootPoint(rot);
    }

    void Die() {
        //Do something here, like releasing particles or sth
    }

}
