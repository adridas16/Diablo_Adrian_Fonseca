using DG.Tweening;
using System;
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
    [SerializeField]private int tiempoInteraccion;
    //Guardo la informacion del NPC actual con el que voy a hablar
    private Transform ultimoClick;
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
        if (Time.timeScale == 1)
        {

          Movimiento();
        }
        if (ultimoClick&& ultimoClick.TryGetComponent(out IInteractuable interactuable))
        {
            agent.stoppingDistance=distanciaInteraccion;
            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {
                
              LanzarInteraccion(interactuable);

                
            }
        }
        else if(ultimoClick)
        {
            agent.stoppingDistance = 0f;    
        }
       
    }
    private void LanzarInteraccion(IInteractuable interactuable)
    {
        interactuable.Interactuar(transform);
        ultimoClick = null;
    }
    private void Movimiento()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Time.timeScale == 1)
        {
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (Input.GetMouseButtonDown(0))
                {
               
                  //Mirrar a ver si el punto donde e impactado tiene el script NPC
                  agent.SetDestination(hit.point);
                  ultimoClick=hit.transform;
                } 

            }

        }
    }

    public void HacerDanho(float danhoAtaque)
    {
        Debug.Log("me hace danho"+danhoAtaque);
    }
}
