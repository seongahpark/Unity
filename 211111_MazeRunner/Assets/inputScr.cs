using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputScr : MonoBehaviour
{
    public void textChange(string str) {
        Debug.Log(str);
    }

    public void endChange(string str) {
        Debug.Log("end : " + str);
    }

    //문자를 사용자가 직접 입력할 수 있도록 해주는 ui
    //글자수 제한을 할 수 있으며 적을 수 있는 글자의 종류도 제한할 수 있다.
    //Content Type에 따라 사용가능한 글자의 종류를 제한할 수 있으며
    //각 type에 맞는 글자 종류 외에는 입력이 불가능하다.
    //Place Holder는 아무런 텍스트가 입력되지 않았을때
    //사용자에게 어떤 텍스트를 입력해야하는지, 어떤식으로 입력해야하는지
    //보여주는 일종의 가이드 텍스트라 할 수 있다.
    //Caret은 커서의 속성값을 바꿔줄 수 있으며 깜빡이는 빈도, 색상, 크기 등을
    //바꿔줄 수 있다.
    //read only가 되면 텍스트를 수정할 순 없고
    //텍스트를 복사하거나 블럭지정 하는 등은 가능해진다.    
}
