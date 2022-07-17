using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float angle;

    [SerializeField] private Vector2 minMaxAngle = new Vector2(-25, 60);

    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Locked; 
    }

    // Update is called once per frame
    void Update()
    {
        LimitAngle();   
    }

    void LimitAngle()
    {
        float y = Input.GetAxisRaw("Mouse Y") * -1;
        float rotate = (transform.eulerAngles.x > 180) ? transform.eulerAngles.x - 360 : transform.eulerAngles.x;
        angle = Mathf.Clamp(rotate + y, minMaxAngle.x, minMaxAngle.y);
        transform.localEulerAngles = new Vector3(angle, 0, 0);
    }
}
