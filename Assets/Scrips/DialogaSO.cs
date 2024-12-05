using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
[CreateAssetMenu(menuName ="Dialogo")]
public class DialogaSO : ScriptableObject 
{
    [TextArea]
    public string[] frases;
    public float tiempoEntreLetras;
    private void Start()
    {
        
    }
    private void Update()
    {
        
    }

}
