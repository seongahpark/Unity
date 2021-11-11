using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnScr : MonoBehaviour
{
    public void btnClick() {
        Debug.Log("Button is Clicked!");
    }
    //버튼
    //ui 공통요소
    //interactable:상호작용(조작)가능유무
    //             켜져있으면 플래이어가 해당 ui를 직접 조작할 수 있고
    //             꺼져있으면 조작할 수 없다.
    //Transition:ui의 상태.
    //           Normal-아무것도 하지 않음
    //           Highlighted-마우스가 올라와있음
    //           Pressed-마우스로 누름
    //           Selected-가장 마우스로 클릭했던 ui를 표시함.
    //           Disabled-비활성화됨(interactable이 꺼짐)

    //Navigation:조작가능한 각 ui들을 키보드로 이동할 수 있도록
    //           ui간의 위치관계를 기반으로 하여 연결해줌.
    //           기본값은 자동이며 필요에 따라 직접 설정도 가능하고
    //           필요가 없다면 꺼버려도 상관없음.
}
