using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FruitManager : MonoBehaviour
{
    public Text levelCleared;
    public GameObject transition;

    public void Update()
    {
        //estaremos llamando constantemente a este metodo para comprobar si se han acabado las frutas
        AllFruitsColected();
    }
    //metodo con el que vamos a comprobar si todas las frutas se han recogido
    public void AllFruitsColected()
    {
       
        
        if (transform.childCount == 0)
        {
            Debug.Log("No quedan frutas,VICTORIA");
            levelCleared.gameObject.SetActive(true);
            //Animacion de cambio de nivel
            transition.SetActive(true);
            Invoke("ChangeScene", 1);
          
            
            
        }
    }
    void ChangeScene()
    {
        //en file, build settings de unity, tendremos que arrastrar nuestras scenes
        //esto llama a la siguiente escena sumandole 1 a buildIndex, ya que sigue un contador
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
