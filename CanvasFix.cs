using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasFix : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
