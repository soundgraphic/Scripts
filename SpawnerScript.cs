using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject Enemigo;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    /*void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            transform.position = new Vector3(Random.Range(-10, 10), 0.5f, Random.Range(-10, 10));
            Instantiate(Enemigo, transform.position, Quaternion.identity);
        }
    }*/
}
