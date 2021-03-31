using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changePosition : MonoBehaviour
{
    void Update()
    {
        //Change position player on Y-axe 

        if (Input.GetKeyDown("w") && transform.position.y <= 10)
        {
            transform.position += new Vector3(0, 1, 0);
        }

        if (Input.GetKeyDown("s") && transform.position.y >= 1.5)
        {
            transform.position += new Vector3(0, -1, 0);
        }
    }
}
