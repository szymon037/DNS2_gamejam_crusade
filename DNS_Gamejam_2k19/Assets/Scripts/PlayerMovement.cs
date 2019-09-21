using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(XboxController))]
[RequireComponent(typeof(PlayerShooting))]
public class PlayerMovement : MonoBehaviour
{
    public XboxController xboxController;
    public PlayerShooting shootingScript;

    // Start is called before the first frame update
    void Start()
    {
        this.xboxController = this.gameObject.GetComponent<XboxController>();
        this.shootingScript = this.gameObject.GetComponent<PlayerShooting>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("joystick button 10")) {
            shootingScript.Shoot();
        }
    }
}
