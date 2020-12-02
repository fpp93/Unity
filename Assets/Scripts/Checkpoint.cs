using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //posiciones x e y de nuestro checkpoint
            collision.GetComponent<PlayerRespawn>().ReachedCheckPoint(transform.position.x,transform.position.y);

            //la animacion de la bandera se activara cuando pasemos
            GetComponent<Animator>().enabled = true;
        }
    }
}
