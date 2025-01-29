using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaMisiones : MonoBehaviour
{
    [SerializeField] private EventManagerSO eventManager;

    [SerializeField] private ToggleMision[] toggleMision;
    // Start is called before the first frame update
    private void OnEnable()
    {
        eventManager.OnNuevaMision += ActivarToogleMision;
        eventManager.OnActualizarMision += ActualizarToggle;
        eventManager.OnTerminarMision += FinalizarMisionToggle;
    }


    private void ActivarToogleMision(MisionSO mision)
    {
        toggleMision[mision.indiceMision].TextoMision.text = mision.ordenInicial;
        if (mision.repeticion)
        {
            toggleMision[mision.indiceMision].TextoMision.text +=" ("+mision.estadoActual+"/"+ mision.repeticionesTotales+")";
        }
        toggleMision[mision.indiceMision].gameObject.SetActive(true);
    }
    private void ActualizarToggle(MisionSO mision)
    {
        //actualizar el texto de la mision correspondiente
        toggleMision[mision.indiceMision].TextoMision.text = mision.ordenInicial;
        toggleMision[mision.indiceMision].TextoMision.text += " (" + mision.estadoActual + "/" + mision.repeticionesTotales + ")";
    }
    private void FinalizarMisionToggle(MisionSO mision)
    {
        //marcar el toggle como true;
        toggleMision[mision.indiceMision].Toggle.isOn = true;
        toggleMision[mision.indiceMision].TextoMision.text = mision.ordenFinal;
    }
}
