using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCameraControl : MonoBehaviour
{
    private float cameraSpeed = 5.0f;
    [SerializeField] private Transform player;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = player.position + offset;
        transform.position = Vector3.Lerp(pos, transform.position, cameraSpeed*Time.deltaTime);
    }
}
