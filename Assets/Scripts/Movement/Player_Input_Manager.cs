using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;
public class Player_Input_Manager : MonoBehaviour
{

    [SerializeField] private float unitsToMoveForward;
    [SerializeField] private float timeToMoveForward;
    [SerializeField] private Transform _XR_Rig;
    [SerializeField] private InputActionReference leftA, rightA;

    [SerializeField] private AudioClip correct,incorrect;
    [SerializeField] private AudioSource source;

    private bool isOnLeft = true;
    void Update()
    {
        if(leftA.action.WasPressedThisFrame())
        {
            if(isOnLeft && Metronome_Manager.isOnMarginToMove)
            {
                HandlePlayerMovement();
            }
            else
            {
                source.PlayOneShot(incorrect);
            }
        }
        if(rightA.action.WasPressedThisFrame())
        {
            if(!isOnLeft && Metronome_Manager.isOnMarginToMove)
            {   
                HandlePlayerMovement();
            }
            else
            {
                source.PlayOneShot(incorrect);
            }
        }
    }

    private void HandlePlayerMovement()
    {
        isOnLeft = !isOnLeft;
        source.PlayOneShot(correct);

        _XR_Rig.DOMove(_XR_Rig.position + (Vector3.forward * unitsToMoveForward),timeToMoveForward);
    }
}
