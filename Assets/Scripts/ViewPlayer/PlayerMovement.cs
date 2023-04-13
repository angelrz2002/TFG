using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController CharacterController;
    public float speed = 12f;

    public float gravity = -10;
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
            velocity.y = Mathf.Sqrt(jumpHeight * -gravity * 3);
        }
       

        /*--Trabaja la gravedad del personaje para que este caiga una  velocidad que se quiera----*/
        velocity.y += gravity * Time.deltaTime;
        move *= speed;
        move.y = velocity.y;
        CharacterController.Move(move * Time.deltaTime);
        /*----------------------------------------------------------------------------------------*/
    }
}
