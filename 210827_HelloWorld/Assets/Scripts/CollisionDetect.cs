using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//컴포넌트 추가 첫 번째 방법 - 스크립트 추가시 바로 생성
[RequireComponent(typeof(Rigidbody))] 
//이 스크립트를 실행하기 위해서는 컴포넌트를 요청한다, 여기서는 Rigidbody 컴포넌트 요청
// -> 유니티에서 rigid body 컴포넌트를 추가하지 않아도 스크립트 추가시 자동으로 따라온다
public class CollisionDetect : MonoBehaviour
{
    //컴포넌트 추가 두 번째 방법 - 실행시 AddComponent 호출시 추가됨, 실행 끝나면 없어짐
    private void Awake()
    {
        //GetComponent<BoxCollider>();
        gameObject.AddComponent<BoxCollider>();
    }
    // Callback Function -> 함수가 만들어져있는데 시스템이 적절한 타이밍에 호출해주는 것
    private void OnCollisionEnter(Collision _collision)
    {
        /*
        //Rigid Body
        플레이어와 적 둘 중의 하나만 rigid body가 적용돼있으면 충돌 검출 가능
         */
        Debug.Log("OnCollisionEnter");
        //LogWarning, LogError 형태로 콘솔에 띄울 수 있음
    }
}
