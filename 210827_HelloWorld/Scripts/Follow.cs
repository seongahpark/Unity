using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] private GameObject targetGo = null;
    private float speed = 8f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (targetGo == null) return;

        Vector3 targetPos = targetGo.transform.position;
        Vector3 myPos = this.transform.position;
        Vector3 direction = targetPos - myPos;
        direction.Normalize(); //¡§±‘»≠
        transform.position =
            transform.position +
            (direction * speed * Time.deltaTime);

    }
}
