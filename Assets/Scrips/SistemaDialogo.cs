using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class SistemaDialogo : MonoBehaviour
{
    //Partron SINGLETON
    //Asegurarte que esta sea la unica instancia de "SistemaDialogo
    //Asegura que esa instancia SEA ACCESIBLE desde cualquier punto del programa
    public static SistemaDialogo sistema;
    [SerializeField] private GameObject marcos;
    [SerializeField] private TMP_Text textoDialogo;
    private DialogaSO dialogoActual; //para almacenar que o con que dialogo estamos trabajando
    [SerializeField] Transform npcCamera;

    private bool escribiendo; //Determina si el sistema esta escribiendo o no
    private int indiceFraseActual;//Marca la frase por la que voy 
    

    

    private void Awake()
    {
        //si el trono esta vacio    trono=sistema
        if (sistema == null) 
        {
            //reclamo el trono y me lo llevo
            sistema=this;
            //y no me destruyo entre escenas
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }


    public void IniciarDialogo(DialogaSO dialogo,Transform cameraPoint)
    {
        npcCamera.transform.SetPositionAndRotation(cameraPoint.position,cameraPoint.rotation);
        
        Time.timeScale = 0; //pausamos el juego
        //el dialogo actual con el que trabajamos es el que me dan por parametro de entrada
        dialogoActual = dialogo;
        marcos.SetActive(true);
        StartCoroutine(EscribirFrase());
        
    }

    private  IEnumerator EscribirFrase()
    {
        escribiendo = true;
        textoDialogo.text = "";
        char[]fraseEnLetras = dialogoActual.frases[indiceFraseActual].ToCharArray();
        foreach (char letra in fraseEnLetras) 
        {
            textoDialogo.text += letra;
            
            yield return new WaitForSecondsRealtime(dialogoActual.tiempoEntreLetras);
        }
        escribiendo = false;
    }
    public void SiguienteFrase()
    {
        if (escribiendo)//si estamos escribiendo una frase...
        {
            CompletarFrase();
        }
        else
        {
            indiceFraseActual++;//avanzo de indice de frase 
            if(indiceFraseActual < dialogoActual.frases.Length)
            {
               StartCoroutine(EscribirFrase()); //la escribe
            }
            else
            {
                TerminarDialogo();//si no me quedan frases termino y cierro dialogo
            }
        }
      
    }
    private void CompletarFrase()
    {
        StopAllCoroutines();
        textoDialogo.text = dialogoActual.frases[indiceFraseActual];
        escribiendo=false;
    }
    private void TerminarDialogo()
    {
        marcos.SetActive(false);
        StopAllCoroutines();
        indiceFraseActual = 0;//para posteriores dialogos
        escribiendo = false;
        dialogoActual = null;//ya no tenemos ningun dialogo a no ser que me vuelvan a clicar
        Time.timeScale = 1;
    }

}
