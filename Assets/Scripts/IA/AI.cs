using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AI : MonoBehaviour
{

    // Declaramos las variables de la malla y el destino al que queremos llevar al enemigo

    public NavMeshAgent navMeshAgent;

    // Esto es un Array de las posiciones que necesitas
    public Transform[] destinations;

    public float distanceToFollowPath = 2;

    private int indice = 0;

    [Header("-----------¿ FollowPlayer ?---------------")]

    public bool FollowPlayer;

    private GameObject player;

    private float distanceToPlayer;

    public float distanceToFollowPlayer = 10;

    void Start()
    {

        // Mediante esta igualación llevamos la posicion del enemigo al destino 
        navMeshAgent.destination = destinations[indice].transform.position;

        player = FindObjectOfType<PlayerMovement>().gameObject;

    }

   
    void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        // Cuando este cerca de nuestro jugador , sigamos al player

        if (distanceToPlayer <= distanceToFollowPlayer && FollowPlayer)
        {

            followPlayer();

        }
        else
        {
            enemyPath();
        }

       
    }


    public void enemyPath()
    {

<<<<<<< Updated upstream
        navMeshAgent.destination = destinations[indice].position;
=======
        navMeshAgent.SetDestination( destinations[indice].position);
>>>>>>> Stashed changes

        // Comprueba si la posicion de nuestro enemigo  es menor o igual a la distancia de llegar a ese punto que le marcamos

        if (Vector3.Distance(transform.position, destinations[indice].position) <=  distanceToFollowPath)
        {
            // Comprobacion al llegar al punto de si hay otro punto mas en el array o no
            if (destinations[indice] != destinations[destinations.Length - 1] )
            {
                indice++; 
            }
            else
            {
                indice = 0;
            }

        }

    }

    public void followPlayer()
    {
        navMeshAgent.destination = player.transform.position;


    }
}
