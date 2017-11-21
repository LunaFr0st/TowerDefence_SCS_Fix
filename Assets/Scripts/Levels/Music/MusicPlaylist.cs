using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlaylist : MonoBehaviour {

    public Object[] music;
    private AudioSource audi;
    void Awake()
    {
        audi = GetComponent<AudioSource>();
        audi.loop = false;
        music = Resources.LoadAll("Music", typeof(AudioClip));
    }
    AudioClip GetRandMusic()
    {
        return (AudioClip)music[Random.Range(0, music.Length)];
    }
    void Update()
    {
        if (!audi.isPlaying)
        {
            audi.clip = GetRandMusic();
            audi.Play();
        }
    }
}
