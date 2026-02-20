using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MiniMapCam : MonoBehaviour
{
    public Transform Player;
    public Camera MainCamera;
    public bool RotateWithPlayer = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetPosition();
        SetRotation();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        SetPosition();

        if (RotateWithPlayer && MainCamera)
        {
            SetRotation();
        }
    }

    private void SetRotation()
    {
        transform.rotation = Quaternion.Euler(90.0f, MainCamera.transform.eulerAngles.y, 0.0f);
    }
    private void SetPosition()
    {
        var newPos = Player.position;
        newPos.y = transform.position.y;

        transform.position = newPos;
    }
}
