using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObject : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //condicion de si el tag de personaje entra en contacto con el collider de los pinchos
        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("Player Damaged");
            //destruimos el perosnaje
            collision.transform.GetComponent<PlayerRespawn>().PlayerDamaged();
        }
    }
}
