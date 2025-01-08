using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    private SistemaCombate combate;
    private SistemaPatrulla patrulla;
    private Transform mainTarjet;

    public SistemaCombate Combate { get => combate; set => combate = value; }
    public SistemaPatrulla Patrulla { get => patrulla; set => patrulla = value; }
    public Transform MainTarjet { get => mainTarjet; }

    private void Start()
    {
        patrulla.enabled = true;
    }
    

    public void ActivaCombate(Transform target)
    {
       combate.enabled = true;
       mainTarjet = target;
       
    }
}

