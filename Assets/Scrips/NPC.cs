using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    // Start is called before the first frame update
  
    private Outline outline;
    [SerializeField]private Texture2D cursorNPC;
    [SerializeField]private Texture2D cursorIdl;
    [SerializeField]float tiempoRotacion;
    //Antes del start() (una vez)
    //2 Este o no este el script habilitado,el Awake se lanza ,el Start NO. Para tus componentes 
    private void Awake()
    {
        outline = GetComponent<Outline>();
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
        Debug.Log("hola");
        transform.DOLookAt(interactuador.position, tiempoRotacion,AxisConstraint.Y);
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
