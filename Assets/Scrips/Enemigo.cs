using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    [SerializeField] private Transform ruta;
    List<Vector3> listadoPuntos = new List<Vector3>();
    private NavMeshAgent agent;
    private Vector3 destinoActual; //Marca el destino al cual tenemos que ir
    // Start is called before the first frame update
    private void Awake()    
    {
        agent = GetComponent<NavMeshAgent>();
        //voy recorriendo todos los puntos que tiene mi ruta
        foreach (Transform punto in ruta)
        {
            //y los añado en mi lista.
            listadoPuntos.Add(punto.position);
        }
        CalcularDestino();
    }
    void Start()
    {
        StartCoroutine(PatrullasYEsperar());
      
    }

    private IEnumerator PatrullasYEsperar()
    {
       agent.SetDestination(destinoActual);
       yield return null;
    }
    private void CalcularDestino()
    {
        destinoActual = listadoPuntos[0];
    }
    
}

