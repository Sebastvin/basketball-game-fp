using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PredictionManager : Singleton<PredictionManager>
{
    public int longTail;

    Scene currentScene;
    Scene predictionScene;

    PhysicsScene currentPhysicsScene;
    PhysicsScene predictionPhysicsScene;


    LineRenderer lineRenderer;
    GameObject dummy;

    void Start()
    {

        Physics.autoSimulation = false;

        currentScene = SceneManager.GetActiveScene();
        currentPhysicsScene = currentScene.GetPhysicsScene();

        CreateSceneParameters parameters = new CreateSceneParameters(LocalPhysicsMode.Physics3D);
        predictionScene = SceneManager.CreateScene("Prediction", parameters);
        predictionPhysicsScene = predictionScene.GetPhysicsScene();

        lineRenderer = GetComponent<LineRenderer>();
    }

    void FixedUpdate()
    {
        if (currentPhysicsScene.IsValid())
        {
            currentPhysicsScene.Simulate(Time.fixedDeltaTime);
        }
    }


    public void predict(GameObject subject, Vector3 currentPosition, Vector3 force)
    {
        if (currentPhysicsScene.IsValid() && predictionPhysicsScene.IsValid())
        {
            if (dummy == null)
            {
                dummy = Instantiate(subject);
                SceneManager.MoveGameObjectToScene(dummy, predictionScene);
            }

            dummy.transform.position = currentPosition;
            dummy.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
            lineRenderer.positionCount = 0;
            lineRenderer.positionCount = longTail;


            for (int i = 0; i < longTail; i++)
            {
                predictionPhysicsScene.Simulate(Time.fixedDeltaTime);
                lineRenderer.SetPosition(i, dummy.transform.position);
            }

            Destroy(dummy);
        }
    }
}

