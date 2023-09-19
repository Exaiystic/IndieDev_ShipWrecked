using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackTilt : MonoBehaviour
{
    public int tiltAngle = 45;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, -tiltAngle));
        }
        else if (Input.GetAxisRaw("Horizontal") == -1)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, tiltAngle));
        }
        else
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
    }
}
