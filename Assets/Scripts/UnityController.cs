using System.Runtime.InteropServices;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnityController : MonoBehaviour
{
    //Refrence to rigidbody on same object
    public Rigidbody2D myRigidBody = null;
    public CharacterState JumpingState = CharacterState.Airborne;
    //Is Our character on the ground or in the air?

    //Gravity
    //public float GravityPerSecond = 160.0f; //Falling Speed
    //public float GroundLevel = 0.0f; //Ground Value

    //Jump
    public float JumpSpeedFactor = 3.0f; //How much faster is the jump than the movespeed?
    public float JumpMaxHeight = 150.0f;
    [SerializeField]
    private float JumpHeightDelta = 0.0f;
    
    public int HP = 1;
    public SpriteRenderer mySpriteRenderer = null;  

    //Movement
    public float MovementSpeedPerSecond = 10.0f; //Movement Speed

    public List<Sprite> CharacterSprites = new List<Sprite>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && JumpingState == CharacterState.Grounded)
        {
            JumpingState = CharacterState.Jumping; //Set character to jumping
            JumpHeightDelta = 0.0f; 
        }

        mySpriteRenderer.sprite = CharacterSprites[HP -1];

       //coppy out HP-1 to a new variable
        int hpCopy = HP - 1;
        //if hp less then 0 then set it to 0
        if (hpCopy < 0) 
        {  
            hpCopy = 0; 
        }
        //id hp larger then or equal to the number of diffrent sprites in Charactersprites, set it to that number minus one(-1)
        if (hpCopy >= CharacterSprites.Count)
        {
            hpCopy = CharacterSprites.Count -1 ;
        }

        mySpriteRenderer.sprite = CharacterSprites[hpCopy];
    }


    void FixedUpdate()
    {
        Vector3 characterVelocity = myRigidBody.velocity;
        characterVelocity.x = 0.0f;

        if (JumpingState == CharacterState.Jumping)
        {
            float totalJumpMovementThisFrame = MovementSpeedPerSecond * JumpSpeedFactor;
            characterVelocity.y = totalJumpMovementThisFrame;

            JumpHeightDelta += totalJumpMovementThisFrame * Time.deltaTime;

            if (JumpHeightDelta >= JumpMaxHeight)
            {
                JumpingState = CharacterState.Airborne;
                JumpHeightDelta = 0.0f;
                characterVelocity.y = 0.0f;
            }
        }

        //Left
        if (Input.GetKey(KeyCode.A))
        {
            characterVelocity.x -= MovementSpeedPerSecond;
        }
        //Right
        if (Input.GetKey(KeyCode.D))
        {
            characterVelocity.x += MovementSpeedPerSecond;
        }
        myRigidBody.velocity = characterVelocity;

    }
}