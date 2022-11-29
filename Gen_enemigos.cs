using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gen_enemigos : MonoBehaviour
{
    public GameObject enemigo;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(Random.Range(-10, 10), 0.5f, Random.Range(-10, 10));
        Instantiate(enemigo, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
