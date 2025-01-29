using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seta : MonoBehaviour, IInteractuable
{
    private Outline outline;
    [SerializeField] EventManagerSO eventManager;
    [SerializeField] private MisionSO misionAsociada;
    public void Interactuar(Transform interactuador)
    {
         misionAsociada.estadoActual++;//estamos a un paso mas de completar la mision
        if (misionAsociada.estadoActual < misionAsociada.repeticionesTotales)
        {
            eventManager.ActualizarMision(misionAsociada);
        }
        else 
        { 
            eventManager.TerminarMision(misionAsociada);
        }
         Destroy(this.gameObject);  
    }

    private void Awake()
    {
        outline = GetComponent<Outline>();
    }
    private void OnMouseEnter()
    {
        outline.enabled = true;
    }
    private void OnMouseExit()
    {
        outline.enabled = false;
    }

}
