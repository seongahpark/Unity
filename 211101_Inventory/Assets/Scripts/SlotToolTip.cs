using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SlotToolTip : MonoBehaviour
{
    [SerializeField] GameObject go_base;
    [SerializeField] Text t_name;
    [SerializeField] Text t_context;
    public void ShowToolTip(string name, string context, Vector3 pos)
    {
        go_base.SetActive(true);
        pos += new Vector3(go_base.GetComponent<RectTransform>().rect.width * 0.5f,
            -go_base.GetComponent<RectTransform>().rect.height * 0.5f, 0);
        go_base.transform.position = pos;

        t_name.text = name;
        t_context.text = context;
    }

    public void HideToolTip()
    {
        go_base.SetActive(false);
    }
}
