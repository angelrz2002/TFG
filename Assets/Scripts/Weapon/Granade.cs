using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granade : MonoBehaviour
{
    public float delay = 3;

    // Si no se pone nada delante de public o privado se crea como private.
    float countDown;
    // Pillara la explosion a todos los objetos que esten al rededor de este are definida.
    public float radius = 5;

    public float explosionForce = 70;

    public bool exploted = false;

    public GameObject explosionEffect;

    void Start()
    {
        countDown = delay;
    }

    void Update()
    {
        countDown -= Time.deltaTime;
        if(countDown <= 0 && exploted == false)
        {
            Explote();
            exploted = true;
        }
    }

    void Explote()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach(var rangeObjects in colliders)
        {
            Rigidbody rb = rangeObjects.GetComponent<Rigidbody>();
            // Esto es para saber si los objectos del area tienen RigidBody y si lo tienen 
            // les aplican las fuerza de la granada.
            if(rb != null)
            {
                rb.AddExplosionForce(explosionForce * 10, transform.position, radius);
            }
        }
        Destroy(gameObject);
    }
}
