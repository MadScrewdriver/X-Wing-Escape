using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public AudioSource efxSource;
    public AudioSource musicSource;


    public static SoundManager instanced = null;

    public float lowPitchRange = 0.95f;
    public float highPitchRange = 1.05f;

    
    void Awake ()
    {
        if (instanced == null) instanced = this;
        else if (instanced != this) Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
	}
	

    public void PlaySingle (AudioClip clip)
    {
        efxSource.clip = clip;
        efxSource.Play();  
    }

    public void RandomizeSfx (params AudioClip [] clips)
    {
        int RandomIndex = Random.Range(0, clips.Length);
        float randomPitch = Random.Range(lowPitchRange, highPitchRange);
        efxSource.pitch = randomPitch;
        efxSource.clip = clips[RandomIndex];
        efxSource.Play();


    }
     
}