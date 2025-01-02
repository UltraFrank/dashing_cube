using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundMixerManager : MonoBehaviour
{

    [SerializeField] AudioMixer audioMixer; //Mixer che gestisce le varie parti dell'audio: musica e sound effects
    
    public void SetMasterVolume(float level)
    {
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(level) * 20f); //Setta il valore del volume dell'intero audio
    }

    public void SetSoundEffectsVolume(float level)
    {
        audioMixer.SetFloat("SoundEffectsVolume", Mathf.Log10(level) * 20f); //Setta il valore del volume dei sound effects
    }

    public void SetMusicVolume(float level)
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(level) * 20f); //Setta il valore del volume della musica
    }
}
