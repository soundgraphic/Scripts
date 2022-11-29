using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public GameObject bala;
    public float tiempoDisparo = 0.5f;
    float proximoDisparo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("space") && Time.time > proximoDisparo)
        {
            proximoDisparo = Time.time + tiempoDisparo;
            disparo();
        }
    }
    void disparo()
    {
        Instantiate (bala, transform.position, transform.rotation);
    }
}