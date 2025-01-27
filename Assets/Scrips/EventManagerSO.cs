using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Event Manager")]
public class EventManagerSO : ScriptableObject
{
    public event Action<MisionSO> OnNuevaMision; //EVENTO
    public event Action<MisionSO> OnActualizarMision;
    public event Action<MisionSO> OnTerminarMision;
    public void NuevaMision(MisionSO mision)
    {
        //Aqui lanzo la notificacion (el evento) por si a alguien le interesa.
        //OnNuevaMision?.Invoke(mision);.: Invocacion SEGURA Se asegura de que haya suscriptores. si no hay suscriptires te crashean mejor que este el ?
        OnNuevaMision?.Invoke(mision);

    } 
    public void ActualizarMision (MisionSO mision)
    {
        //Aqui lanzo la notificacion (el evento) por si a alguien le interesa.
        //OnNuevaMision?.Invoke(mision);.: Invocacion SEGURA Se asegura de que haya suscriptores. si no hay suscriptires te crashean mejor que este el ?
        OnActualizarMision?.Invoke(mision);

    }
    public void TerminarMision (MisionSO mision)
    {
        //Aqui lanzo la notificacion (el evento) por si a alguien le interesa.
        //OnNuevaMision?.Invoke(mision);.: Invocacion SEGURA Se asegura de que haya suscriptores. si no hay suscriptires te crashean mejor que este el ?
        OnTerminarMision?.Invoke(mision);

    }
}
