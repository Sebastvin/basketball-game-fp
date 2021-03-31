using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    public AudioClip[] sound;
    public AudioSource xd;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bounce")
        {
            int tmp = Random.Range(0, sound.Length);
            xd.clip = sound[tmp];
            xd.Play();
        }
    }
}
