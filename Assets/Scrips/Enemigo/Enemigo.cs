using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemigo : MonoBehaviour, IDanhable
{
    [SerializeField] private Texture2D cursorEnemigo;
    [SerializeField] private Texture2D cursorIdl;
    private SistemaCombate combate;
    private SistemaPatrulla patrulla;
    Transform mainTarjet;
    EnemyVisual mainVisual;
    [SerializeField] private float vidasActuales;
    private bool muerto;
    EnemyVisual enemigoVisual;
    [SerializeField] private GameObject localcanvas;
    [SerializeField] private float vidasIniciales;
    [SerializeField] private Image healthBar;
    [SerializeField] private Outline outline;
    public SistemaCombate Combate { get => combate; set => combate = value; }
    public SistemaPatrulla Patrulla { get => patrulla; set => patrulla = value; }
    public Transform MainTarjet { get => mainTarjet; }
    public EnemyVisual MainVisual { get => mainVisual; set => mainVisual = value; }
    public EnemyVisual EnemigoVisual { get => enemigoVisual; set => enemigoVisual = value; }

    private void Start()
    {
        patrulla.enabled = true;
        vidasActuales = vidasIniciales;
    }
    

    public void ActivaCombate(Transform target)
    {
       combate.enabled = true;
       mainTarjet = target;
       
    }

    public  void ActivarPatruya()
    {
        combate.enabled=false;
        patrulla.enabled=true;
    }
    public void RecibirDanho(float danho)
    {   
        vidasActuales -= 25;
        healthBar.fillAmount = vidasActuales / vidasIniciales;
        if (vidasActuales <= 0)
        {
            muerto = true;
            Muerte();
        }
    }
    private void Muerte()
    {

        Destroy(localcanvas);
        Destroy(combate);
        Destroy(patrulla.gameObject);
        Destroy(gameObject, 5);
        enemigoVisual.EjecutarAnimacionMuerte();
    }
    private void OnMouseEnter()
    {
        outline.enabled = true;
        Cursor.SetCursor(cursorEnemigo, Vector2.zero, CursorMode.Auto);
    }
    private void OnMouseExit()
    {
        outline.enabled = false;
        Cursor.SetCursor(cursorIdl, Vector2.zero, CursorMode.Auto);
    }
   

}

