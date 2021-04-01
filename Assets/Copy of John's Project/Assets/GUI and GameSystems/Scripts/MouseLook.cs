using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Errors : 17

[AddComponentMenu("RPG/Player/Mouse Look")]
public class MouseLook : MonoBehaviour
{
    public enum RotationalAxis
    {
        MouseX,
        MouseY
    }
        
    [Header("Rotation Variables")]
    public RotationalAxis axis = RotationalAxis.MouseX;
    [Range(0,500)]
    public float sensitivity = 200;
    public float minY = -60, maxY = 60;
    private float _rotY;

    void Start()
    {
        if(GetComponent<Rigidbody>())
        {
            GetComponent<Rigidbody>().freezeRotation = true;
        }
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        if(axis == RotationalAxis.MouseX)
        {
            transform.Rotate(0,Input.GetAxisRaw("Mouse X") * sensitivity * Time.fixedDeltaTime, 0);
        }
        else
        {
            _rotY += Input.GetAxisRaw("Mouse Y") * sensitivity * Time.fixedDeltaTime;
            _rotY = Mathf.Clamp(_rotY, minY,maxY);
            transform.localEulerAngles = new Vector3(-_rotY, 0.0f);
        }
    }


}