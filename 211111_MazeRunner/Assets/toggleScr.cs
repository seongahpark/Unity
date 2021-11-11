using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleScr : MonoBehaviour
{
    public void isToggled(bool b) {
        Debug.Log("Toggle is Change!");
    }
    //토글
    //버튼에서 해당 버튼을 켰는지 껐는지를 나타내는 bool값이 추가된 형태.
    //떄문에 함수를 연결할때도 매개변수로 bool값을 줘서 사용한다
    //단, 매개변수가 있는 함수를 연결할때는 반드시 dynamic 함수와 연결한다.
    //static 함수와 연결하면 에디터에서 지정한 매개변수만 전달이 된다.

    //토글 여러개를 하나로 묶어서 라디오버튼(여러개중 하나만 선택가능한 토글)으로
    //구현도 가능하며 이 경우 토글그룹으로 묶어준다.
}
