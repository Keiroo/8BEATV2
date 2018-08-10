using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BGM : MonoBehaviour {

    public AudioClip[] AudioClips;

    public void PlayBGM(int lvl)
    {
        List<AudioClip> clips = new List<AudioClip>();

        // Get clips
        foreach (AudioClip clip in AudioClips)
        {
            if (clip.name.StartsWith("s0" + lvl))
            {
                clips.Add(clip);
            }
        }


        // Randomize audio clip
        int ranIndex = Random.Range(0, clips.Count);

        if (clips.Count > 0)
        {
            AudioSource src = GetComponent<AudioSource>();
            src.clip = clips[ranIndex];
            src.loop = true;
            src.Play();
        }        
    }

    public void StopBGM()
    {
        GetComponent<AudioSource>().Stop();
    }
}
