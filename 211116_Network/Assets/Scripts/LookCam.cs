using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookCam : MonoBehaviour
{
    public Camera Cam;
      private void Start()
    {
        Cam = Camera.main;
    }
    void Update()
    {
        transform.rotation = Cam.transform.rotation;
        Vector3 pos = this.transform.parent.transform.position;
        pos.z += 4;
        transform.position = pos;
    }
}
