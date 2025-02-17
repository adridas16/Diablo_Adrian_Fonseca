using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyVisual : MonoBehaviour
{
    
    // Start is called before the first frame update
    [SerializeField] private Enemigo main;
    [SerializeField] private NavMeshAgent agent;

    private Animator anim;

   

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("velocity", agent.velocity.magnitude / agent.speed);
    }
    public void MuerteAnim()
    {
        anim.SetTrigger("Muerte");
       
    }
    
    
}
