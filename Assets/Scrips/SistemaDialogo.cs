using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SistemaDialogo : MonoBehaviour
{
    //Partron SINGLETON
    //Asegurarte que esta sea la unica instancia de "SistemaDialogo
    //Asegura que esa instancia SEA ACCESIBLE desde cualquier punto del programa
    public static SistemaDialogo sistema;
    [SerializeField] private GameObject marcos;
    [SerializeField] private TMP_Text textoDialogo;


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


    public void IniciarDialogo(DialogaSO dialogo)
    {

        marcos.SetActive(true);
 
    }

    private void EscribirFrase()
    {

    }

    private void TerminarDialogo()
    {



    }

   
    private void SiguienteFrase()
    {

    }

    


}
