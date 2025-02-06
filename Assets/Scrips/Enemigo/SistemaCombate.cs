
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SistemaCombate : MonoBehaviour
{
    [SerializeField] private Enemigo main;
    [SerializeField] private float velocidadCombate = 4.5f;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] private float distanciaAtaque = 1.5f; 
    [SerializeField] private Animator animator;
    [SerializeField] private float danhoAtaque;


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

        //si el tarjet es alcanzable voy a por el 
        if (main.MainTarjet != null && agent.CalculatePath(main.MainTarjet.position, new NavMeshPath()))
        {
            EnfocarObjetivo();
            agent.SetDestination(main.MainTarjet.position);
            if (!agent.pathPending && agent.remainingDistance <= distanciaAtaque) 
            { 
                animator.SetBool("Atacar",true);
                
            }
            else
            {
                animator.SetBool("Atacar", false);
            }

        }
        else//si no es alcanzable
        {
            main.ActivarPatruya();
            
        }
    }
    #region Ejecutados por eventos de animacion
    public void Atacar()
    {
        //cuando termino animacion me muevo
        main.MainTarjet.GetComponent<Player>().RecibirDanho(danhoAtaque);
    }
    private void FinAnimacionAtaque()
    {
        animator.SetBool("Atacar", false);
        agent.isStopped = false;
    }

    private void EnfocarObjetivo()
    {
        Vector3 direccionAlTarjet=(main.MainTarjet.position-this.transform.position).normalized;
        direccionAlTarjet.y=0;
        Quaternion rotacionAlTarjet =Quaternion.LookRotation(direccionAlTarjet);
        transform.rotation = rotacionAlTarjet;
    }
    
}
#endregion