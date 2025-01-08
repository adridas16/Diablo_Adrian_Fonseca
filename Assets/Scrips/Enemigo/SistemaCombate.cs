using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Playables;
using UnityEngine.UI;

public class SistemaCombate : MonoBehaviour
{
    [SerializeField] private Enemigo main;
    [SerializeField]private float velocidadCombate = 4.5f;
    [SerializeField] NavMeshAgent agent;
    [SerializeField]private float distanciaAtaque = 1.5f; 

    // Start is called before the first frame update

    private void Awake()
    {
        main.Combate = this;
        
        
    }
    private void OnEnable()
    {
        agent.speed=velocidadCombate;
        agent.stoppingDistance = distanciaAtaque;
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        

        agent.SetDestination(main.MainTarjet.position);
    }
}
