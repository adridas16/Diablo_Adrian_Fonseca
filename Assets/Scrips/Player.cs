using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour,IDanhable
{
    // Start is called before the first frame update
    [SerializeField] private float interaccionAtaque = 2f; 
    [SerializeField] private float attakingDistance = 2f; 
    [SerializeField] private float distanciaInteraccion;
    [SerializeField] private float danhoAtaque;
    [SerializeField] private float vidas;
    private NavMeshAgent agent;
    private Camera cam;
    [SerializeField]private int tiempoInteraccion;
    //Guardo la informacion del NPC actual con el que voy a hablar
    private Transform ultimoClick;
    private PlayerAnimation playerAnimations;
    private Transform TargetActual;

    public PlayerAnimation PlayerAnimations { get => playerAnimations; set => playerAnimations = value; }

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
        if (Time.timeScale == 1 && vidas>0)
        {

          Movimiento();
        }
        if (Time.timeScale == 1 && vidas >0 && ultimoClick && ultimoClick.TryGetComponent(out IInteractuable interactuable))
        {
            agent.stoppingDistance=distanciaInteraccion;
            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {
                
              LanzarInteraccion(interactuable);

                
            }
        }
        else if (Time.timeScale == 1 && vidas > 0 && ultimoClick && ultimoClick.TryGetComponent(out IDanhable _))
        {
            TargetActual = ultimoClick;
            agent.stoppingDistance = attakingDistance;
            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {
                FaceTarget();
                playerAnimations.EjecutarAtaque();
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

    public void Atacar()
    {
        TargetActual.GetComponent<Enemigo>().RecibirDanho(danhoAtaque);
    }
    private void FaceTarget()
    {
        Vector3 directionToTarget = (TargetActual.transform.position - transform.position).normalized;
        directionToTarget.y = 0f;
        Quaternion rotationToTarget = Quaternion.LookRotation(directionToTarget);
        transform.rotation = rotationToTarget;
    }
    public void RecibirDanho(float danho)
    {
        vidas -= danho;
        if (vidas <= 0)
        {
            playerAnimations.EjecutarAnimacionMuerte();
        }
    }
}
