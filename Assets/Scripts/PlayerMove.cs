using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //variable que guarda la velocidad de movimiento horizontal
    public float runSpeed = 2;
    //variable que guarda la velocidad de salto
    public float jumpSpeed = 3;

    Rigidbody2D rb2D;

    //variables para la mejora del salto
    public Boolean betterJump = false;
    public float fallMultiplier = 0.5f;
    public float lowJumpMultiplier = 1f;

   // creamos un objeto tipo sprite rendered para poder cambiar el atributo "flip" que hace que el player mire a la izquierda 
    public SpriteRenderer spriterenderer;
    //lo he asignado desde el editor pero podria hacerlo desde el metodo start tal como hicimos con el rigidbody
    //objeto tipo animator que permitira cambiar el parametro "run" que hemos creado en el arbol de animaciones
    public Animator animator;
    void Start()
    {
        rb2D=GetComponent<Rigidbody2D>();
    }

    
    void FixedUpdate()
    {
        if (Input.GetKey("right"))
        {
            //usamos la variable de el eje x que es el movimiento horizontal, pero no tocamos el eje y.
            rb2D.velocity = new Vector2(runSpeed, rb2D.velocity.y);
            //flip es lo que hara que mire a la derecha o izquierda
            spriterenderer.flipX = false;
            //al movernos, se activa la animacion de "run"
            animator.SetBool("Run", true);
        }
        else if (Input.GetKey("left"))
        {
            //eje x en negativo ya que retrocede con left
            rb2D.velocity = new Vector2(-runSpeed, rb2D.velocity.y);
            spriterenderer.flipX = true;
            animator.SetBool("Run", true);
        }
        else
        {
            //si no se pulsa nada, significa que esta quieto.
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
            //else significa que no me estoy moviendo, por lo que la animacion de correr estara desactivada
            animator.SetBool("Run", false);
        }
        //metodo para saltar dandole la variable de nuestro otro script para comprobar que antes de saltar, este en el suelo
        if (Input.GetKey("space")&& TouchGround.isGrounded)
        {
            rb2D.velocity = new Vector2(0, jumpSpeed);
        }
        if (TouchGround.isGrounded == false)
        {
            //cuando este saltando, la animacion de saltar se activara y la de correr desactivara
            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);
        }
        if(TouchGround.isGrounded == true)
        {
            //cuando este en el suelo, la animacion de saltar se desactivara y la de correr se activara
            animator.SetBool("Jump", false);
            
        }

        if (betterJump)
        {
            if (rb2D.velocity.y < 0)
            {
                //deltatime ayuda a que no haya inconsistencia en los frames por segundo
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime;
            }
                                        //mientras no se este pulsando la tecla espacio
            if (rb2D.velocity.y > 0 && !Input.GetKey("space")) 
            {
                //velocidad de salto lenta cuando este cayendo
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier) * Time.deltaTime;
            }
        }
    }
}
