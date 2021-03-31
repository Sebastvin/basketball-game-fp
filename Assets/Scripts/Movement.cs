using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{

    public Text forPoints;
    public GameObject[] points;
    public int spawns;
    public static int counter = 3;

    

    private void Start()
    {
        forPoints.text = "For: " + 3.ToString();
        Cursor.lockState = CursorLockMode.Confined; // keep confined in the game window
        Cursor.lockState = CursorLockMode.Locked;   // keep confined to center of screen
        Cursor.lockState = CursorLockMode.None;
        StartCoroutine(ChangePosition(10, points));
    }

    IEnumerator ChangePosition(float time, GameObject[] points)
    {
        int randomNumber = 0;
        int currentNumber = 0;
        int forThree = 1;
        int forTwo = 0;
        Vector3 pos = points[0].transform.position;


        for (int i = 0; i < spawns -1; i++)
        {          
            yield return new WaitForSeconds(time);

            while (randomNumber == currentNumber)
            {
                randomNumber = Random.Range(0, points.Length);        
            }

            if (points[randomNumber].tag == "3" && forThree <= 3)//for 3
            {
                forPoints.text = "For: " + 3.ToString();
                counter = 3;
                forThree++;
                pos = points[randomNumber].transform.position;
            }
            else 
            {
                while (points[randomNumber].tag != "2")
                {
                   randomNumber = Random.Range(0, points.Length);
                }
            }

            if (points[randomNumber].tag == "2" && forTwo <= 4) //for 2
            {
                forPoints.text = "For: " + 2.ToString();
                counter = 2;
                forTwo++;
                pos = points[randomNumber].transform.position;
            }
            else
            {
                while (points[randomNumber].tag != "3")
                {
                    randomNumber = Random.Range(0, points.Length);
                }
            }

            currentNumber = randomNumber;
            transform.position = pos;
        }
    }
}
