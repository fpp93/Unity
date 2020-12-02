using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    //aqui guardare la posicion del player cuando llegue al checkppoint
    private float checkPointPositionx, checkPointPositiony;
    public Animator animator;

    void Start()
    {
        //si he pasado al nivel 3, borro los prefas para no salir en la posicion del checkpoint
        if (SceneManager.GetActiveScene()==SceneManager.GetSceneAt(2))
        {
            PlayerPrefs.DeleteAll();
            
        }
        //si esta variable es distinta a 0, significara que hemos asignado la posicion bien al chekcpoint
        if (PlayerPrefs.GetFloat("checkPointPositionx") != 0)
        {
            //variamos la posicion de nuestro personaje a la del checkpoint
            transform.position = new Vector2(PlayerPrefs.GetFloat("checkPointPositionx"),PlayerPrefs.GetFloat("checkPointPositiony"));
        }
    }

    //alcanzar checkpoint
    public void ReachedCheckPoint(float x,float y)
    {
        //playerprefs me permite guardar informacion no perdible dentro del juego, en este caso queremos guardar la posicion  del checkpoint
        PlayerPrefs.SetFloat("checkPointPositionx", x);
        PlayerPrefs.SetFloat("checkPointPositiony", y);
        
        
        //para borrar la informacion guardada, en unity, iremos a edit y clear playerprefs
    }

    public void PlayerDamaged()
    {
        //animacion al morir, se llamara a esta funcion en los scripts de los enemigos
        animator.Play("Hit");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
