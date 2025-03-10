using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SistemaPatrulla : MonoBehaviour
{
    [SerializeField] private Enemigo main;
    [SerializeField] private Transform ruta;
    private float velocidadPatruya = 3;

    List<Vector3> listadoPuntos = new List<Vector3>();

    [SerializeField] private NavMeshAgent agent;
    private Vector3 destinoActual; //Marca el destino al cual tenemos que ir
    private int indiceRutaActual;
    private float tiempoEntrePuntos;//Marca el indice del nuevo punto
    // Start is called before the first frame update
    private void Awake()
    {
        main.Patrulla = this;
       
        //voy recorriendo todos los puntos que tiene mi ruta
        foreach (Transform punto in ruta)
        {
            //y los a�ado en mi lista.
            listadoPuntos.Add(punto.position);
        }
    }
    void Start()
    {

    }
    private void OnEnable()
    {
        agent.stoppingDistance = 0f;
        indiceRutaActual--;
        agent.speed = velocidadPatruya;
        //comunico al main que el sistema de patruya soy yo
        StartCoroutine(PatrullasYEsperar());
        
    }

    private IEnumerator PatrullasYEsperar()
    {
        while (true) //1. calculas un nuevo destino 
        {
            CalcularDestino();//2. se te marca dicho destino
            agent.SetDestination(destinoActual);
            //3. esperas a llegar a dicho destino y repites
            yield return new WaitUntil(() => !agent.pathPending && agent.remainingDistance<=0.2f);
            yield return new WaitForSeconds(tiempoEntrePuntos=Random.Range(0.5f,1.5f));
        }
       
    }
    private void CalcularDestino()
    {
        indiceRutaActual++;
        //count es lo mismo que length en los arrays
        if (indiceRutaActual >= listadoPuntos.Count)
        {
            //si no me quedan puntos bolvere am punto 0
            indiceRutaActual = 0;
        }
        destinoActual = listadoPuntos[indiceRutaActual];
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StopAllCoroutines(); //paro corrutinas
            main.ActivaCombate(other.transform);
      
            this.enabled = false;//desabilito patruya
        }
    }
    

}
