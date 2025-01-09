using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyVisual : MonoBehaviour
{
    private bool ventanaAbierta;
    [SerializeField] NavMeshAgent agent;
    Animator anim;
    // Start is called before the first frame update
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Atacar()
    {
        //cuando termino animacion me muevo
        anim.SetBool("Atacar", false);
        agent.isStopped = false;
    }
    
}
