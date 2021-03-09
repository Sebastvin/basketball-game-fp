using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    // Start is called before the first frame update
    public float timeDestroy = 10;
    void Start()
    {
        Invoke("onDestroy", timeDestroy);
    }

    // Update is called once per frame
    void onDestroy()
    {
        Destroy(gameObject);
    }
}
