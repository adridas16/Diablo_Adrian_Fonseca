using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    private Player main;
    // Start is called before the first frame update
    private void Awake()
    {
        anim = GetComponent<Animator>();
        main.PlayerAnimations=this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EjecutarAtaque()
    {
        anim.SetBool("attaking",true);
    }
    public void PararAtaque()
    {
        anim.SetBool("attaking", false);
        anim.SetBool("attaking", false);
    }
}
