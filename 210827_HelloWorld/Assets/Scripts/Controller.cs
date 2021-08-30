using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour //Component의 역할을 하려면 MonoBehaviour로 해줘야 됨
{
    //Variables
    [Range(0f, 10f)] //바로 뒤의 변수 범위 지정
    [SerializeField] private float speed = 10f; //private이기 때문에 외부에서는 접근 x
                                                //public으로 하면 unity 플랫폼에서도 변수 값 변환 가능
                                                //앞에 serializedField를 붙여주면 private이어도 unity에서도 변환 가능
    private float rotSpeed = 30f;

    private Gun gun = null;

    //Property(Getter / Setter)
    public float Speed //꼭 대문자로 쓸 것
    {
        set { speed = value; }
        get { return speed; }
    }

    public int val { get; set; } //기본적인 get/set이 만들어짐


    //Functions
    // Start is called before the first frame update
    private void Start()
    {
        //아두이노에서 setup 같은 함수, 프로그램이 시작 될 때 최초로 한 번만 실행
        //Speed = 100f;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            //Transform tr = GetComponent<Transform>(); 이 작업을 안해도 트랜스폼에 바로 접근이 가능하도록 되어있음
            transform.position =
                transform.position +
                (Vector3.forward * speed * Time.deltaTime);//Time.deltaTime을 해줘야 일정한 시간으로 돈다
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(
                Vector3.back * speed * Time.deltaTime); //위의 코드와 동작은 같음
        }
        if (Input.GetKey(KeyCode.A)) MoveWithDir(Vector3.left);
        if (Input.GetKey(KeyCode.D)) MoveWithDir(Vector3.right);
        //MoveWithDir(transform.forward); 내 캐릭터가 보는 방향 기준
        //MoveWithDir(Vector3.right); 절대축 기준

        //Rotate
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0f, -rotSpeed * Time.deltaTime, 0f); //x, y, z
            //반대로 돌고싶으면 -speed 하면 된다
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up, rotSpeed * Time.deltaTime); // 해당 축을 기준으로 돌림
        }

        //Local, Model Coordinate / Space
        // World Space
        // Pitch, Yaw, Roll
        // Euler Angle -> Gimbal Lock1
        // Quaternion

        if (Input.GetMouseButtonDown(0)) //마우스가 눌러졌는지 검사
        {
            gun.Fire();
        }
    }

    private void MoveWithDir(Vector3 _dir)
    {
        //transform.Translate(_dir * speed * Time.deltaTime); //회전하냐에 따라서 움직이는 방향 달라짐
        transform.position =
            transform.position +
            (_dir * speed * Time.deltaTime); //절대 축 기준으로 움직여서 회전하냐 마냐 영향이 X
    }

    private void Awake()
    {
        gun = GetComponent<Gun>();
    }
}
