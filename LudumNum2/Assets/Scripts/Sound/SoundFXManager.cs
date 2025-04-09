using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    public static SoundFXManager SFXinstance;

    [SerializeField] private AudioSource soundFXPlayer;

    private void Awake()
    {
        if (SFXinstance == null)
        {
            SFXinstance = this;
        }
    }

    public void PlaySoundFXClip(AudioClip audioClip, Transform spawnedGoTransform, float volume)
    {
        AudioSource audioSource = Instantiate(soundFXPlayer, spawnedGoTransform.position, Quaternion.identity);

        audioSource.clip = audioClip;

        audioSource.volume = volume;

        audioSource.Play();

        float clipLength = audioSource.clip.length;

        Destroy(audioSource.gameObject, clipLength);
    }
}
