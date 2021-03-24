using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public float timeDestroy = 10;
    void Start()
    {
        Invoke("onDestroy", timeDestroy);
    }

    void onDestroy()
    {
        Destroy(gameObject);
    }
}
