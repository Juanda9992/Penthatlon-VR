using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metronome_Manager : MonoBehaviour
{   
    public static bool isOnMarginToMove = false;
    [SerializeField] private AudioClip[] _audiosToPlay;
    [SerializeField] private float timeToPressInSeconds;


    private float timeBetweenBeats = 0.5f;
    private AudioSource _source;
    private void Start()
    {
        _source = GetComponent<AudioSource>();

        StartCoroutine(nameof(PlayBPMSounds));
        StartCoroutine(nameof(CalculateInputWindow));

    }

    private IEnumerator CalculateInputWindow()
    {
        float delayFirstInput = timeBetweenBeats - timeToPressInSeconds;
        while(true)
        {
            isOnMarginToMove = true;
            yield return new WaitForSeconds(delayFirstInput);
            isOnMarginToMove = false;
            yield return new WaitForSeconds(timeToPressInSeconds);
        }
    }

    private IEnumerator PlayBPMSounds()
    {
        while(true)
        {
            for(int i = 0; i< _audiosToPlay.Length; i++)
            {
                _source.PlayOneShot(_audiosToPlay[i]);
                yield return new WaitForSeconds(timeBetweenBeats);
            }
        }
    }

}
