using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchGround : MonoBehaviour
{
    //la ponemos static para poder utilizarla dentro de otro script
    public static bool isGrounded;

    //metodo quecomprueba si nuestro collider esta tocando alguna geometria(en este caso el suelo)
    private void OnTriggerEnter2D(Collider2D Collision)
    {
        if (Collision.gameObject.tag == "Mapa")
        {
            isGrounded = true;
        }
      
    }
    private void OnTriggerExit2D(Collider2D Collision)
    {
        if (Collision.gameObject.tag == "Mapa")
        {
            isGrounded = false;
        }
    }
}
