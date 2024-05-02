using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] voiceOverClips;
    [SerializeField] private AudioClip successfulSFX;
    
    public void PlayVoiceOver(int clipIndex, Action onFinished = null)
    {
        Debug.Log($"Attempting to play voice over with clip index: {clipIndex}");
        if (clipIndex < 0 || clipIndex >= voiceOverClips.Length)
        {
            Debug.LogError("Clip index out of range.");
            return;
        }
        Debug.Log($"Playing clip: {voiceOverClips[clipIndex].name}");

        audioSource.clip = voiceOverClips[clipIndex];
        if (audioSource.clip == null)
        {
            Debug.LogError("Assigned clip is null.");
            return;
        }
    
        audioSource.Play();
        Debug.Log("Audio should be playing now.");

        StartCoroutine(WaitForSoundToFinish(onFinished));
    }

    private IEnumerator WaitForSoundToFinish(Action onFinished)
    {
        yield return new WaitWhile(() => audioSource.isPlaying);
        onFinished?.Invoke();
    }
    
    public void PlaySuccessSFX()
    {
        if (successfulSFX != null) 
        {
            audioSource.PlayOneShot(successfulSFX); 
        }

        
    }

}
