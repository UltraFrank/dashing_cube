using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectsManager : MonoBehaviour
{
    public static SoundEffectsManager instance; //creazione di un singleton

    [SerializeField] private AudioSource soundEffectsClip; //Effetto audio del Salto del Player

    private void Awake()
    {
        if (instance == null)   //Se il singleton non esiste, lo crea
            instance = this;
    }

    public void PlaySoundEffectClip(AudioClip audioClip, Transform spawnTransform, float volume)  //Fa partire qualsiasi soundeffect tramite richiamo di questo metodo
    {
        //spawn del GameObject AudioSource
        AudioSource audioSource = Instantiate(soundEffectsClip, spawnTransform.position, Quaternion.identity);

        //Assegnazione clip 
        audioSource.clip = audioClip;

        //Volume modificabile
        audioSource.volume = volume;

        audioSource.Play();

        //Lunghezza del SoundEffect
        float clipLength = audioSource.clip.length;

        //Lo distrugge a fine effetto
        Destroy(audioSource.gameObject, clipLength);
    }
}
