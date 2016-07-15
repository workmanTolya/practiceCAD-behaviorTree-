using UnityEngine;
using System.Collections;
using System;

public class SoundEffectsHelper : MonoBehaviour {

    public static SoundEffectsHelper Instance;
    public AudioClip playerShotSound;
    public AudioClip enemyShotSound;

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Несколько экземпляров SoundEffectsHelper!");
        }
        Instance = this;
    }

    public void MakePlayerShotSound()
    {
        MakeSound(playerShotSound);
    }

    public void MakeEnemyShotSound()
    {
        MakeSound(enemyShotSound);
    }

    private void MakeSound(AudioClip originalClip)
    {
        AudioSource.PlayClipAtPoint(originalClip, transform.position);
    }
}
