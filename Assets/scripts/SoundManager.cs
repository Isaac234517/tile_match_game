using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

    // Use this for initialization
    public AudioClip crincleAudioClip;
    AudioSource crincle;
	void Awake () {
        crincle = AddAudio(crincleAudioClip);
	}

    AudioSource AddAudio(AudioClip clip)
    {
        AudioSource source = this.gameObject.AddComponent<AudioSource>();
        source.playOnAwake = false;
        source.clip = clip;
        return source;
    }

    public void playCrincle()
    {
        crincle.Play();
    }
}
