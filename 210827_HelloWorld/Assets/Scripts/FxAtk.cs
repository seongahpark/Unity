using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FxAtk : MonoBehaviour
{
    private float scale = 0.1f;

    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector3.one * scale;
        //Vector3.one = (1,1,1) »ý¼º
        scale += Time.deltaTime * 10f;

        if (scale >= 3f) Destroy(gameObject);
    }
}
