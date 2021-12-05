using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSpace : MonoBehaviour
{
    public float speedCamera = 20;
    public float rangeToMove = 20;

    public float x1 = 12;
    public float x2 = 28;
    public float y1 = 5.5f;
    public float y2 = 35.5f;

    float screenWidth;
    float screenHeight;

    private void Start()
    {
        screenHeight = Screen.height;
        screenWidth = Screen.width;
    }
    private void Update()
    {
        Vector3 camPos = transform.position;

        if (Input.mousePosition.y >= screenHeight - rangeToMove
        || Input.GetKey(KeyCode.W))     //Up
        {
            camPos = Up(camPos);
        }
        if (Input.mousePosition.y <= rangeToMove
        || Input.GetKey(KeyCode.S))     //Down
        {
            camPos = Down(camPos);
        }
        if (Input.mousePosition.x >= screenWidth - rangeToMove
        || Input.GetKey(KeyCode.D))     //Right
        {
            camPos = Right(camPos);
        }
        if (Input.mousePosition.x <= rangeToMove
        || Input.GetKey(KeyCode.A))     //Left
        {
            camPos = Left(camPos);
        }
            transform.position = new Vector3(Mathf.Clamp(camPos.x, x1, x2), camPos.y, Mathf.Clamp(camPos.z, y1, y2));
    }
    private float Move()
    {
        return Time.deltaTime * speedCamera;
    }
    private Vector3 Up(Vector3 pos)
    {
        pos.z += Move();
        return pos;
    }
    private Vector3 Down(Vector3 pos)
    {
        pos.z -= Move();
        return pos;
    }
    private Vector3 Right(Vector3 pos)
    {
        pos.x += Move();
        return pos;
    }
    private Vector3 Left(Vector3 pos)
    {
        pos.x -= Move();
        return pos;
    }
}
