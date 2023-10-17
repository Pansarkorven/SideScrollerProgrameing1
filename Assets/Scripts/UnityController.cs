using System.Runtime.InteropServices;
using UnityEngine;


public class UnityController : MonoBehaviour
{
    public Rigidbody2D Myrigidbody2D = null;

    public CharacterState JumpingState = CharacterState.Airborne; // är karaktären på marken eller i luften?



    public float MovementSpeedPerSecond = 120.0f; // gå
    public float GravityPerSecond = 140.0f; // falla
    public float GroundLevel = 0.0f; // grunden

    //hoppa
    public float JumpSpeedFactor = 3.0f; // Hur mycket snabbare hoppet är
    public float JumpMaxHeight = 150;
    private float JumpHeightDelta = 0.0f;
    


    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.y <= GroundLevel)
        {
            Vector3 characterPosition = transform.position;
            characterPosition.y = GroundLevel;
            transform.position = characterPosition;
            JumpingState = CharacterState.Grounded;
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
        Vector3 CharacterVelocity = Myrigidbody2D.velocity;
        CharacterVelocity.x = 0.0f;


        if (Input.GetKey(KeyCode.A)) // Left
        {
            CharacterVelocity.x -= MovementSpeedPerSecond;
        }
        if (Input.GetKey(KeyCode.D)) // right
        {
            CharacterVelocity.x += MovementSpeedPerSecond;
        }
    Myrigidbody2D.velocity = CharacterVelocity;
    }
}

