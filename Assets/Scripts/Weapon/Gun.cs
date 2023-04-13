using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    // Reeferencia de la bala
    // Referencia del punto

    public Transform spawnPoint;    // Punto de spawn.
    public GameObject bullet;
   
    public float shotForce = 1500; // Fuerza con la que se disparará.
    public float shotRate = 0.5f; // Ratio con el que podamos disparar.

    private float shotRateTime = 0; // Tiempo de espera para volver a disparar tras haber disparado.


    void Update()
    {
        shotRateTime += Time.deltaTime;
        // Para disparar con el click izq del raton
        if (Input.GetButtonDown("Fire1")){
            
            // Si el tiempo actual es mayor a la variable te dejara disparar
            // Segunda condicion para saber si el arma tiene municion o no.
            if(shotRate < shotRateTime && GameManager.Instance.gunAmmo > 0)
            {
                // Cada vez que se dispara resta la municion del arma.
                GameManager.Instance.gunAmmo --;

                // La bala que se instancie la meteremos dentro de este GameObject.
                GameObject newBullet;

                newBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
                
                // Es para añadir una fuerza hacia adelante y que no este parada.
                newBullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * shotForce);

                shotRateTime = 0;

                Destroy(newBullet, 2);
            }
        }
    }
}
