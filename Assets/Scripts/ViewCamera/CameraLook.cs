using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    public Transform playerBody;

    float xRotation = 0;

    void Start()
    {
        // Es para capar nuestro raton a la vista / ventana  game.
        Cursor.lockState = CursorLockMode.Locked; 
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;

        // Capar el 'eje Y / vertical'.
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Rotacion en el 'eje Y / vertical'.
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);


        // Rotacion en el eje 'X / horizontal'.
        playerBody.Rotate(Vector3.up * mouseX);


    }
}
