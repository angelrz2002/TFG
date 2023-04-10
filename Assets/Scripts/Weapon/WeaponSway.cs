using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSway : MonoBehaviour
{
    private Quaternion startRotation; // Para pillar la posicion inicial de nuestro arma.

    public float swayAmound = 8; // Para que la rotacion sea mas o menos exagerado.

    void Start()
    {
        startRotation = transform.localRotation;
    }

    void Update()
    {
        Sway();
    }

    private void Sway()
    {
        // Pillar el eje 'X' e 'Y'.
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        Quaternion xAngle = Quaternion.AngleAxis(mouseX * -1.25f, Vector3.up);//Pillar el angulo en el eje X.
        Quaternion yAngle = Quaternion.AngleAxis(mouseY * -1.25f, Vector3.left);//Pillar el angulo en el eje X.

        Quaternion targetRotation = startRotation * xAngle * yAngle;

        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, Time.deltaTime * swayAmound);
    }
}
