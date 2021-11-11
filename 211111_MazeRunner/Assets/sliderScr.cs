using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sliderScr : MonoBehaviour
{
    public void sliderChange(float f) {
        Debug.Log(f);
    }

    //핸들을 움직여서 수치값을 변경시킬 수 있는 ui
    //수치값의 범위를 min Value, max Value를 통해 조절할 수 있으며
    //음수, 양수, 소수점 모두 사용 가능하다.
    //Whole Numbers를 켜면 가질 수 있는 수치값이 정수만 적용된다.
}
