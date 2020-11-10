using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitManager : MonoBehaviour
{
    //metodo con el que vamos a comprobar si todas las frutas se han recogido
    public void AllFruitsColected()
    {
        //las frutas al cogerlas se destruyen, por l oque comprobaremos si queda alguna fruta hija en fruit manager
        //lo pongo a 1 y no a 0 porque la fruta se destruye despues de la llamada al metodo
        if (transform.childCount == 1)
        {
            Debug.Log("No quedan frutas,VICTORIA");
        }
    }
}
