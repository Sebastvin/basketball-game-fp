using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject ball;

    public static Vector3 startPosition = new Vector3(0.8f, 4.8f, -33.2f);

    public void Spawn()
    {
        Instantiate(ball, startPosition, Quaternion.identity);
    }
}
