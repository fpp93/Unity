using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FruitCollected : MonoBehaviour
{
    //metodo que se activa cuando el collider de la fruta entra en contacto con nuestro personaje

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //ESTE TAG CREADO, puede activarse en el editor del personaje, en la casilla tag
        if (collision.CompareTag("Player"))
        {
            //sprite rendered hace que se vea o no el objeto, asi que lo desactivamos
            GetComponent<SpriteRenderer>().enabled = false;
            //ya que collected la hemos puesto como hijo, la cogemos y la activamos cuando cogamos la fruta
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            //destruimos el objeto ya que no existira en el mapa al cogerla
            Destroy(gameObject, 0.5f);
            

        }
    }
}
