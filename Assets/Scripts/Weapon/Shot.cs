using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    // Reeferencia de la bala
    // Referencia del punto

    public GameObject bullet;
    public Transform spawnPoint;    // Punto de spawn.

    public float shotForce = 1500; // Fuerza con la que se disparará.
    public float shotRate = 0.5f; // Ratio con el que podamos disparar.

    private float shotRateTime = 0; // Tiempo de espera para volver a disparar tras haber disparado.


    void Update()
    {
        // Para disparar con el click izq del raton
        if (Input.GetButtonDown("Fire1")){
            
            //Si el tiempò actual es mayor a la variable te dejara disparar
            if(Time.time > shotRateTime)
            {
                // La bala que se instancie la meteremos dentro de este GameObject.
                GameObject newBullet;

                newBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
                
                // Es para añadir una fuerza hacia adelante y que no este parada.
                newBullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * shotForce);

                shotRateTime = Time.time + shotRate;

                Destroy(newBullet, 2);
            }
        }
    }
}
