using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
<<<<<<< Updated upstream
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
=======
    public CharacterController CharacterController;
    public float speed = 12f;

    private float gravity = -10f;
    Vector3 velocity;


    public Transform groundCheck;
    public float sphereRadius = 0.3f;
    public LayerMask groundMask;

    bool isGrounded;

    public float jumpHeight = 3;

    void Update()
    {
        /*Para saber si es el personaje se encuentra en el suelo*/
        isGrounded = Physics.CheckSphere(groundCheck.position, sphereRadius, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -3f;
        }


        /*------------Mueve el personaje ya sea con las teclas 'x, w, a, d' o 'las flechas'-------*/
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;


        /*-------------Para el salto---------------*/
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
        CharacterController.Move(move * speed * Time.deltaTime);


        /*--Trabaja la gravedad del personaje para que este caiga una  velocidad que se quiera----*/
        velocity.y += gravity * Time.deltaTime;
        CharacterController.Move(velocity * Time.deltaTime);
        /*----------------------------------------------------------------------------------------*/
    }

>>>>>>> Stashed changes
}
