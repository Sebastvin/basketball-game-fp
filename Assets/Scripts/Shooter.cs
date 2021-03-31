using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shooter : MonoBehaviour
{
    public GameObject firePoint;
    public GameObject ballPrefab;
    public float power;
    public float rotationSpeed;

    Vector3 currentPosition;
    Quaternion currentRotation;


    void Start()
    {
        currentPosition = transform.position;
        currentRotation = transform.rotation;
        predict();
    }

    public Vector3 calculateForce()
    {
        return transform.forward * power;
    }

    void shoot()
    {
        GameObject ball = Instantiate(ballPrefab, firePoint.transform.position, Quaternion.identity);
        ball.GetComponent<Rigidbody>().AddForce(calculateForce(), ForceMode.Impulse);
    }

    void Update()
    {  
         float vertical = Input.GetAxis("Mouse Y");
         float Horizontal = Input.GetAxis("Mouse X");
         var view = Camera.main.ScreenToViewportPoint(Input.mousePosition);
         var isOutside = view.x < 0 || view.x > 1 || view.y < 0 || view.y > 1;

        if (isOutside == false && Manager.startGame == true)
        {
            
             //currentRotation x,y defines coordinates in which space the "prediction tail" can move
             //transform.Rotate() is responsible for the movement of the "prediction tail" 
            

            if (currentRotation.x >= -0.45f && currentRotation.x <= 0.3f && currentRotation.y >= -0.4f && currentRotation.y <= 0.4f)
            {

                transform.Rotate(
                      -vertical * rotationSpeed,
                      Horizontal * rotationSpeed, //Horizontal * rotationSpeed
                      0.0f
                  );

                if (Input.GetKeyUp(KeyCode.Space))
                {
                    shoot();
                }
            }
            else
            {

                vertical = Input.GetAxis("Mouse Y");
                Horizontal = Input.GetAxis("Mouse X");

                transform.Rotate(
                      -vertical * rotationSpeed,
                      Horizontal * rotationSpeed, //Horizontal * rotationSpeed
                      0.0f
                  );
            }

            if (currentRotation != transform.rotation && currentRotation.x >= -0.45f && currentRotation.x <= 0.3f && currentRotation.y >= -0.4f && currentRotation.y <= 0.4f)
            {
                predict();
            }

            if (currentPosition != transform.transform.position && currentRotation.x >= -0.45f && currentRotation.x <= 0.3f && currentRotation.y >= -0.4f && currentRotation.y <= 0.4f)
            {
                predict();
            }

            currentRotation = transform.rotation;
            currentPosition = transform.position;
        }
    }

    void predict()
    {
        PredictionManager.instance.predict(ballPrefab, firePoint.transform.position, calculateForce());
    }
}
