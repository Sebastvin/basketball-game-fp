using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    public Text text;

    public static int points = 0;


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball" && Movement.counter == 3)
        {
            points += 3;
            text.text = "Points: " + points.ToString();
        }

        if (other.gameObject.tag == "Ball" && Movement.counter == 2)
        {
            points += 2;
            text.text = "Points: " + points.ToString();
        }
    }
}
