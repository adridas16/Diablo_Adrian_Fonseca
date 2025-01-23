using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaMisiones : MonoBehaviour
{
    [SerializeField] private EventManagerSO eventManager;
    [SerializeField] private GameObject toggleMision;
    // Start is called before the first frame update
    private void OnEnable()
    {
        eventManager.OnNuevaMision += ActivarToogleMision;
    }

    private void ActivarToogleMision()
    {
       toggleMision.SetActive(true);
    }
}
