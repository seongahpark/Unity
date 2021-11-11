using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollBarScr : MonoBehaviour
{
    public void scrolled(float f)
    {
        Debug.Log(f);
    }
    //스크롤바
    //슬라이더와 비슷하지만 Value값이 핵심이 아닌
    //핸들의 위치가 메인이 되기 떄문에
    //Value값의 범위는 별도로 지정할 수 없다.
    //보통 단독으로는 쓰이지 않고 스크롤뷰의 형태로 많이 사용한다.
    //Size를 변경하면 핸들의 크기가 변하고 핸들 크기가 클수록
    //조작할 수 있는 범위가 작아져 정밀한 수치조절이 어려워진다.
    //number of steps를 -1이나 0이 아닌 수치를 주게 되면
    //핸들의 위치가 움직이는 중간중간에 걸리게 된다.
    //특정한 위치에서 핸들이 멈추게 하고 싶을때 사용하며 -1~11까지 사용 가능.
    
}
