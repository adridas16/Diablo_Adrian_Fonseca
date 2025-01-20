using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camaraMinimapa : MonoBehaviour
{

    [SerializeField] private Player player;
    private Vector3 distanciaAlPlayer;
    // Start is called before the first frame update
    void Start()
    {
        //Mido la distancia original que se tiene en escena
        distanciaAlPlayer = transform.position-player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //mi posicion en todos los frames es la del player mas cierta distancia

        transform.position = player.transform.position+distanciaAlPlayer;
    }
}
