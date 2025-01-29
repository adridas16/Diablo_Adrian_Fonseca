using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour,IInteractuable
{
    // Start is called before the first frame update
    [SerializeField] private DialogaSO dialogo;
    private Outline outline;
    [SerializeField]private Texture2D cursorNPC;
    [SerializeField]private Texture2D cursorIdl;
    [SerializeField]float tiempoRotacion;
    [SerializeField] private Transform cameraPoint;
    [SerializeField] EventManagerSO eventManager;
    [SerializeField]MisionSO misionAsociada;
    [SerializeField] DialogaSO dialogo2;
    [SerializeField] DialogaSO dialogo1;
    
    //Antes del start() (una vez)
    //2 Este o no este el script habilitado,el Awake se lanza ,el Start NO. Para tus componentes 
    private void Awake()
    {
        outline = GetComponent<Outline>();
        dialogo1 = dialogo;
    }
    private void OnEnable()
    {
        //me suscribo al evento para estar atento de cuando cambiar el dialogo
        eventManager.OnTerminarMision += CambiarDialogo;
    }

    private void CambiarDialogo(MisionSO misionTerminada)
    {
        if(misionTerminada == misionAsociada)
        {
            dialogo = dialogo2;
        }
    }

    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Interactuar(Transform interactuador)
    {
        transform.DOLookAt(interactuador.position, tiempoRotacion,AxisConstraint.Y).OnComplete(() => SistemaDialogo.sistema.IniciarDialogo(dialogo, cameraPoint));

    }


    private void OnMouseEnter()
    {
        Cursor.SetCursor(cursorNPC, Vector2.zero, CursorMode.Auto);
        outline.enabled = true;       
    }


    private void OnMouseExit()
    {
        Cursor.SetCursor(cursorIdl, Vector2.zero, CursorMode.Auto);
        outline.enabled = false;        
    }
}
