using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    void Start()
    {

    }


    public float MovementSpeedPerSecond = 10.0f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) // up
        {
            Vector3 characterPosition = transform.position;
            characterPosition.y += MovementSpeedPerSecond * Time.deltaTime;
            transform.position = characterPosition;
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

    }
}