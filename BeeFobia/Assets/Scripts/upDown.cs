using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upDown : MonoBehaviour
{

    float MouseSensitivity = 4f;
    void Update()
    {
        float mouse = Input.GetAxis("Mouse Y");
        transform.Rotate(new Vector3(-mouse * MouseSensitivity, 0, 0));
    }
}
