using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metronome_Manager : MonoBehaviour
{   
    public static bool isOnMarginToMove = false;
    [SerializeField] private AudioClip[] _audiosToPlay;
    [SerializeField] private float timeToPressInSeconds;

    [SerializeField] private float delay;
    private float timeBetweenBeats = 0.5f;
    private AudioSource _source;
    private void Start()
    {
        _source = GetComponent<AudioSource>();

        StartCoroutine(nameof(PlayBPMSounds));
    }

private IEnumerator PlayBPMSounds()
{

    float remainingTimeBetweenBeats = timeBetweenBeats - 2 * timeToPressInSeconds;

    yield return new WaitForSeconds(timeToPressInSeconds);

    while(true)
    {
        for(int i = 0; i < _audiosToPlay.Length; i++)
        {
            isOnMarginToMove = true;

            yield return new WaitForSeconds(timeToPressInSeconds);

            _source.PlayOneShot(_audiosToPlay[i]);

            yield return new WaitForSeconds(timeToPressInSeconds);
            isOnMarginToMove = false;
            yield return new WaitForSeconds(remainingTimeBetweenBeats);
        }
    }
}

}
