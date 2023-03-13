using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class CamaraContFresh : MonoBehaviour
{
    public GameObject[] camaraList;
    int ncamaras = 3;
    public bool fspCam = true;
    public bool trpCam = false;
    public bool ispCam = false;

    public float rotSpeed;
    public float rotMin, rotMax;
    float mouseX, mouseY;
    public Transform target, player;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        for (int i=0; i<ncamaras; i++) 
        {
            camaraList[i].gameObject.SetActive(false);
        }
        camaraList[0].gameObject.SetActive(true);
    }


    void TurnOffCams()
    {
        for (int i = 0; i < ncamaras; i++)
        {
            camaraList[i].gameObject.SetActive(false);
        }
    }

    void Update()
    {
        //ACTIVADOR DE CAMARAS
        if(Input.GetKey(KeyCode.Alpha1))
        {
            Debug.Log("Primera Persona activada");
            TurnOffCams();
            camaraList[0].gameObject.SetActive(true);

            fspCam = true;
            trpCam = false;
            ispCam = false;
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            Debug.Log("Tercera Persona activada");
            TurnOffCams();
            camaraList[1].gameObject.SetActive(true);

            fspCam = false;
            trpCam = true;
            ispCam = false;

        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            Debug.Log("Vista Isométrica activada");
            TurnOffCams();
            camaraList[2].gameObject.SetActive(true);

            fspCam = false;
            trpCam = false;
            ispCam = true;
        }



        //ACTIVACION DE FUNCIONES
        if ( fspCam == true)
        {
            mouseX += rotSpeed * Input.GetAxis("Mouse X");
            mouseY -= rotSpeed * Input.GetAxis("Mouse Y");
            mouseY = Mathf.Clamp(mouseY, rotMin, rotMax);

            target.rotation = UnityEngine.Quaternion.Euler(mouseY, mouseX, 0.0f);
            player.rotation = UnityEngine.Quaternion.Euler(0.0f, mouseX, 0.0f);
        }
        if ( trpCam == true)
        {
            mouseX += rotSpeed * Input.GetAxis("Mouse X");
            mouseY -= rotSpeed * Input.GetAxis("Mouse Y");
            mouseY = Mathf.Clamp(mouseY, rotMin, rotMax);

            target.rotation = UnityEngine.Quaternion.Euler(mouseY, mouseX, 0.0f);
            player.rotation = UnityEngine.Quaternion.Euler(0.0f, mouseX, 0.0f);
        }
        if ( ispCam == true)
        {

        }





    }
}
