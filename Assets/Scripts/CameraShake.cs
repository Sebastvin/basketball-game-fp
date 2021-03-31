using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shake = 0;
    public float decreaseFactor = 1;
    void Update()
    {
        if (shake > 0)
        {
            this.transform.localPosition = new Vector3(Random.Range(-0.5f,0.5f), Random.Range(9.5f, 10.5f), transform.position.z); 
            shake -= Time.deltaTime * decreaseFactor;
        }
        else 
        {
            shake = 0; 
        }
    }
}
