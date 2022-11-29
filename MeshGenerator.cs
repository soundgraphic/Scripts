using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]

public class MeshGenerator : MonoBehaviour
{
    Mesh mesh;
    MeshCollider meshCollider;

    Vector3[] vertices;
    int[] triangulos;

    Color[] colores;

    public GameObject tanque;
    public GameObject tanqueEnemigo;
    public GameObject[] objetos;
    public int numeroObjetos = 1;

    [Range(1, 200)]
    public int tamanoX = 100;

    [Range(1, 200)]
    public int tamanoZ = 100;
   
    [Range(0f, 0.1f)]
    public float accidentesX = 0.07f;

    public float accidentesY = 1f;

    [Range(0f, 0.1f)]
    public float accidentesZ = 0.07f;

    public Gradient gradiente;

    float alturaMinTerreno;
    float alturaMaxTerreno;

    Vector3 posTanque;
    Vector3 posTanqueEnemigo;

    void Start()
    {
        //transform.Translate(new Vector3(-tamanoX/2, -accidentesY/2, -tamanoZ/2));
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        meshCollider = GetComponent<MeshCollider>();
        
        CrearMalla();
        RefrescarMalla();
        CrearObjetos();
        PosicionarTanques();
    }

    void Update()
    {
        //CrearMalla();
        //RefrescarMalla();
    }

    void CrearMalla()
    {
        vertices = new Vector3[(tamanoX + 1) * (tamanoZ + 1)];

        for (int i = 0, z = 0; z <= tamanoZ; z++)
        {
            for (int x = 0; x <= tamanoX; x++)
            {
                float y = Mathf.PerlinNoise(x * accidentesX, z * accidentesZ) * accidentesY;
                vertices[i] = new Vector3(x, y, z);

                if (y > alturaMaxTerreno)
                    alturaMaxTerreno = y;
                if (y < alturaMinTerreno)
                    alturaMinTerreno = y;
                
                i++;
            }
        }

        triangulos = new int[tamanoX * tamanoZ * 6];

        int vert = 0;
        int triang = 0;

        for (int z = 0; z < tamanoZ; z++)
        {
            for (int x = 0; x < tamanoX; x++)
            {
                triangulos[triang + 0] = vert + 0;
                triangulos[triang + 1] = vert + tamanoX + 1;
                triangulos[triang + 2] = vert + 1;
                triangulos[triang + 3] = vert + 1;
                triangulos[triang + 4] = vert + tamanoX + 1;
                triangulos[triang + 5] = vert + tamanoX + 2;
                vert++;
                triang += 6;
            }
            vert++;
        }

        colores = new Color[vertices.Length];

        for (int i = 0, z = 0; z <= tamanoZ; z++)
        {
            for (int x = 0; x <= tamanoX; x++)
            {
                float altura = Mathf.InverseLerp(alturaMinTerreno, alturaMaxTerreno, vertices[i].y);
                colores[i] = gradiente.Evaluate(altura);
                i++;
            }
        }
    }

    void RefrescarMalla()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangulos;
        mesh.colors = colores;
        mesh.RecalculateNormals();
        meshCollider.sharedMesh = mesh;
    }

    void CrearObjetos()
    {
        for (int i = 0; i < numeroObjetos; i++)
        {
            Instantiate(objetos[Random.Range(0, objetos.Length)], 
                        vertices[Random.Range(0, vertices.Length)] + new Vector3 (0,2f,0),
                        Quaternion.Euler(Vector3.up * Random.Range(0, 360))
                        );
        }
    }

    void PosicionarTanques()
    {
        posTanque = vertices[Random.Range(0, vertices.Length)] + new Vector3(0, 2f, 0);
        posTanqueEnemigo = vertices[Random.Range(0, vertices.Length)] + new Vector3(0, 2f, 0);

        tanque.transform.position = posTanque;
        tanqueEnemigo.transform.position = posTanqueEnemigo;
    }
}
