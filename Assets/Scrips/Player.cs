using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] private float distanciaInteraccion;
    private NavMeshAgent agent;
    private Camera cam;
    //Guardo la informacion del NPC actual con el que voy a hablar
    private NPC npcActual;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        
    }
    void Start()
    {
       
        cam=Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
        if (npcActual)
        {
            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {
                npcActual.Interactuar(this.transform);
                npcActual = null;
                agent.isStopped = true;
                agent.stoppingDistance = 0;
                
            }
        }
       
    }

    private void Movimiento()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (hit.transform.TryGetComponent(out NPC npc))
                {
                    //En ese caso ese npc es el actual.
                    npcActual = npc;
                    //Ahora mi distancia de parada es la de interaccion     
                    agent.stoppingDistance = distanciaInteraccion;
                }
                //Mirrar a ver si el punto donde e impactado tiene el script NPC
                agent.SetDestination(hit.point);
            }

        }
    }
}
