using System.Runtime.InteropServices;
using UnityEngine;

public enum CharacterState // uppräknade lista av karaktär tillstånd
{
    Grounded = 0,
    Airborne = 1,
    Jumping = 2,
    OutOfBounds = 3,
    Total

}



public class CharacterController : MonoBehaviour
{

    public int JumpsAllowed = 0;

    public CharacterState JumpingState = CharacterState.Airborne; // är karaktären på marken eller i luften?

    public float HP = 1.0f;

    public float MovementSpeedPerSecond = 120.0f; // gå
    public float GravityPerSecond = 140.0f; // falla
    public float GroundLevel = 0.0f; // grunden

    //hoppa
    public float JumpSpeedFactor = 3.0f; // Hur mycket snabbare hoppet är
    public float JumpMaxHeight = 150;
    private float JumpHeightDelta = 0.0f;

    // Update is called once per frame
  
    
    void Update()
    {
        if (transform.position.y <= GroundLevel)
        {
            Vector3 characterPosition = transform.position;
            characterPosition.y = GroundLevel;
            transform.position = characterPosition;
            JumpingState = CharacterState.Grounded;
        }


        if (Input.GetKey(KeyCode.W) && (JumpsAllowed < 0)) // up
        {
            JumpingState = CharacterState.Jumping;
            JumpHeightDelta = 0.0f;

        }
        if (JumpingState == CharacterState.Jumping)
        {
            Vector3 characterPosition = transform.position;
            float totalJumpMovementThisFrame = MovementSpeedPerSecond * JumpSpeedFactor * Time.deltaTime;
            characterPosition.y += totalJumpMovementThisFrame;
            transform.position = characterPosition;
            JumpHeightDelta += totalJumpMovementThisFrame;
            if (JumpHeightDelta >= JumpMaxHeight)
            {
                JumpingState = CharacterState.Airborne;
                JumpHeightDelta = 0.0f;
            }
        }

        if (Input.GetKey(KeyCode.S)) // ner
        {
            Vector3 characterPosition = transform.position;
            characterPosition.y -= MovementSpeedPerSecond * Time.deltaTime;
            transform.position = characterPosition;
        }
        if (Input.GetKey(KeyCode.A)) // vänster
        {
            Vector3 characterPosition = transform.position;
            characterPosition.x -= MovementSpeedPerSecond * Time.deltaTime;
            transform.position = characterPosition;
        }
        if (Input.GetKey(KeyCode.D)) // höger
        {
            Vector3 characterPosition = transform.position;
            characterPosition.x += MovementSpeedPerSecond * Time.deltaTime;
            transform.position = characterPosition;
        }
        {
            // Gravitation
            Vector3 gravityPosition = transform.position;
            gravityPosition.y -= GravityPerSecond * Time.deltaTime;
            if (gravityPosition.y < GroundLevel) { gravityPosition.y = GroundLevel; }
            transform.position = gravityPosition;
        }
        
    
    
    
    
    }

}
        