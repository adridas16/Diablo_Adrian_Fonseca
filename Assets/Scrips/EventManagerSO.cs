using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Event Manager")]
public class EventManagerSO : ScriptableObject
{
    public event Action OnNuevaMision; //EVENTO
    public void NuevaMision()
    {
       //Aqui lanzo la notificacion (el evento) por si a alguien le interesa.
       OnNuevaMision.Invoke();

    }
}
