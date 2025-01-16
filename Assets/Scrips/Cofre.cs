using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cofre : MonoBehaviour,IInteractuable
{
    // Start is called before the first frame update
    private Outline outline;
    [SerializeField]private Texture2D cursorCofre;
    [SerializeField]private Texture2D cursorIdl;
    //Antes del start() (una vez)
    //2 Este o no este el script habilitado,el Awake se lanza ,el Start NO. Para tus componentes 
    public void Interactuar(Transform cofre)
    {

    }
    public void Interactuar()
    {

    }
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

    private void OnMouseEnter()
    {
        Cursor.SetCursor(cursorCofre, Vector2.zero, CursorMode.Auto);
        outline.enabled = true;       
    }
    private void OnMouseExit()
    {
        Cursor.SetCursor(cursorIdl, Vector2.zero, CursorMode.Auto);
        outline.enabled = false;        
    }

    
}
