using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ToggleMision : MonoBehaviour
{
    [SerializeField] TMP_Text textoMision;//Recipiente de donde poner los textos de cada mision

    private Toggle toggle; //La cajita con el check.

    public TMP_Text TextoMision { get => textoMision; }
    public Toggle Toggle { get => toggle; }

    // Start is called before the first frame update
    private void Awake()
    {
        toggle = GetComponent<Toggle>();
    }

}
