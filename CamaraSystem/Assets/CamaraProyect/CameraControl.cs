using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public bool activeTP;
    public bool activeOP;

    public Transform posOP;
    public Transform posTP;
    public Transform posPP;

    //CAMARA TP
    public float rotSpeed;
    public float rotMin, rotMax;
    float mouseX, mouseY;
    public Transform target, player;



    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Cam()
    {
        mouseX += rotSpeed * Input.GetAxis("Mouse X");
        mouseY -= rotSpeed * Input.GetAxis("Mouse Y");
        mouseY = Mathf.Clamp(mouseY, rotMin, rotMax);

        target.rotation = Quaternion.Euler(mouseY, mouseX, 0.0f);
        player.rotation = Quaternion.Euler(0.0f, mouseX, 0.0f);
    }

    private void LateUpdate()
    {
        Cam();

        if (activeOP == false && Input.GetKeyDown(KeyCode.Tab))
        {
            activeOP = true;
            transform.position = posPP.position;
        }
        else if (activeTP == true && Input.GetKeyDown(KeyCode.Tab))
        {
            activeTP = false;
            transform.position = posTP.position;
            transform.LookAt(player);
        }
        else if (activeTP == true && Input.GetKeyDown(KeyCode.Tab))
        {
            activeTP = true;
            transform.position = posOP.position;
            transform.LookAt(player);
        }
    }
}
