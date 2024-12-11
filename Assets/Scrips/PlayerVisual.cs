using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayerVisual : MonoBehaviour
{

    [SerializeField] private NavMeshAgent agent;

    private Animator anim;
    // Start is called before the first frame update
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        //Velocdad maxima:
        //angent.speed

        //velocidad actual:
        //agent.velocity

    }

    // Update is called once per frame
    void Update()
    {
        //Todos los frames voy actualizando mi velocity en funcion de mi velocidad acutal
        anim.SetFloat("velocity", agent.velocity.magnitude/agent.speed);   
    }
}
