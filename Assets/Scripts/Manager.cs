using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public static bool startGame = false;

    public AudioClip buttonClick;
    public AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        Cursor.visible = true;
    }

    public void ButtonClick()
    {
        source.clip = buttonClick;
        source.Play();
    }

    private void Update()
    {
        if (Input.GetKey("escape"))
        {
            SceneManager.LoadScene(0);
            startGame = false;
        }
    }

    // Update is called once per frame
    public void StartGame()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
        startGame = true;
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
