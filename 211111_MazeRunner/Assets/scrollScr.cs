using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollScr : MonoBehaviour
{
    public void scrolled(Vector2 v) {
        Debug.Log(v);
    }

    //스크롤바를 통해 화면보다 큰 공간을 작은 화면으로
    //보여줄 수 있는 스크롤 영역을 만들어주는 ui
    //Viewport는 실제로 볼 수 있는 영역의 크기(창문)를 나타내며
    //Content는 실제 내부 공간의 크기(방 크기)를 나타낸다.
    //스크롤뷰를 통해 보여줄 오브젝트는 Content의 자식으로 들어가야 한다.
    //Horizontal, Vertical은 스크롤 내부를 드래그하여 스크롤할수 있도록 할지를
    //나타내며 비활성화시 스크롤 바를 움직이는 것으로만 이동할 수 있다.
    //Movement Type은 스크롤뷰를 컨텐트 영역보다 밖으로 드래그했을 떄의 처리를 나타내며
    //Elastic은 정상범위로 부드럽게 돌려놓으며
    //Unrestricted는 정상범위 밖으로 스크롤되면 그대로 방치하며
    //Clamped는 애초에 정상범위 밖으로 스크롤이 안되도록 막는다.
    //Elasticity는 정상범위로 돌려놓을떄 얼마나 빨리, 혹은 부드럽게 돌려놓을지를 나타낸다.

    //Inertia는 드래그를 통한 스크롤을 할 때 스크롤하던 중 마우스를 땠을때
    //관성을 줄지를 나타낸다.
    //Deceleration Rate가 1보다 크면 마우스를 때도 가속하며 스크롤이 빨라지며
    //1보다 작으면 서서히 감속하며 스크롤이 멈춘다.

}
