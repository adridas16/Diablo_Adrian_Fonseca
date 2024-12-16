using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bilboard : MonoBehaviour
{
    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // para que la barra pueda mirar a camara (Solo funciona con camara ortografica
        transform.forward=-cam.transform.forward;
    }
}
