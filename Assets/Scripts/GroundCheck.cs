using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public UnityController myCharacterController = null;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        myCharacterController.JumpingState = CharacterState.Grounded;
    }
}