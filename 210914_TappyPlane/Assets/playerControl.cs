using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerControl : MonoBehaviour
{
    public GameObject getReady;
    public GameObject gameOver;
    public Text countText;
    public int count = 0; // score
    float countTime = 0;
    bool isLive = true;

    public int HP = 3;
    public bool isHittable = true; //플레이어가 충돌 가능한 상태인지 확인하는 함수
    Rigidbody2D rb;
    float myZ_Angle = 0;//비행기의 z각도를 별도로 저장하기위한 변수
    private void Awake()
    {
        isLive = true;
        getReady.SetActive(true);
        gameOver.SetActive(false);
        Time.timeScale = 0;

    }

    void Start()
    {
        getReady.SetActive(true);
        rb = this.GetComponent<Rigidbody2D>();
        countText.text = count.ToString("D3");
    }

    // Update is called once per frame
    void Update()
    {
        if (isLive != false && Input.GetKeyDown(KeyCode.S))
        {
            getReady.SetActive(false);
            Time.timeScale = 1;
        }

        onGameRestart(); // 게임 재시작 함수
        
        countTime += Time.deltaTime;
        if (countTime > 1.0f)
        {
            count += 5;
            countText.text = count.ToString("D3");
            countTime -= 1.0f;
        }
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Click");
            rb.AddForce(Vector3.up * 5, ForceMode2D.Impulse);
            //AddForce는 리지드바디에 힘을 전달할때
            //별도의 지정이 없으면 지속적인 힘을 서서히 가하게 된다.
            //따라서 힘을 가했을때의 반응이 다소 느려지는데
            //점프와 같은 순간적인(폭발적인) 힘이 필요한 경우
            //힘의 방향값 뒤에 힘을 주는 방식인
            //ForceMode를 Impulse로 주게되면
            //지정한 힘을 순간적인 시간에 전달하기 때문에
            //적은 힘으로도 대상을 움직여줄 수 있다.

            this.transform.Rotate(Vector3.forward * 20);
            myZ_Angle += 20;

            if (myZ_Angle > 30)
            {
                myZ_Angle = 30;
                this.transform.eulerAngles = Vector3.forward * 30;
                //비행기의 각도가 40도를 넘어가면
                //최대각도값인 40도가 되도록 수치를 수정해준다.
            }


        }
    }
    //float gravityVelocity = 0.98f;  //중력가속도
    //float myDropVelocity = 0;       //플래이어의 낙하속도
   
    private void FixedUpdate()
    {
        //myDropVelocity += gravityVelocity * Time.deltaTime;
        ////플래이어의 낙하속도는 중력가속도에 비례해서
        ////점점 증가한다.
        //this.transform.position += Vector3.down * myDropVelocity;
        ////플래이어의 y좌표는 위의 낙하속도만큼 아래로 이동

        Debug.Log(this.transform.eulerAngles.z);

        if (myZ_Angle > -20)
        {
            //eulerAngles: 오브젝트의 각도값인 rotation은
            //에디터에서 보이는 Vector3가 아니라
            //Quataniun(사수)의 형태로 저장이 된다.
            //따라서 각도값을 조절하기가 다소 복잡해지기 때문에
            //쿼터니언 대신 Vec3의 형태로 각도를 바꿀수 있도록
            //해주는 변수가 eulerAngles이다.
            this.transform.Rotate(Vector3.back * Time.deltaTime * 30);
            //Rotate: 현재 각도를 지정한 수치만큼 회전시키는 함수
            
            myZ_Angle -= 1 * Time.deltaTime * 30;
        }
    }

    IEnumerator blink()
    {
        //플레이어가 장애물(적)과 부딪혔을 때
        //플레이어를 점멸(깜빡거리게)시키는 함수
        SpriteRenderer sr = this.GetComponent<SpriteRenderer>();
        for(int i=0; i<30; i++)
        {
            sr.enabled = !sr.enabled;
            //스트라이트 랜더러의 현재 상태의 반대값으로 바꿀 수 있도록

            yield return new WaitForSeconds(0.1f);
            //랜더러의 on/off는 0.1초마다 반복
        }
        //유니티에서 반복문은 해당 반복문이 끝날때까지는
        //유니티가 동작을 멈추는게 보통이지만
        //코루틴 함수를 이용하면 반복문과 동시에 게임이 진행되도록 만들 수 있음
        
        isHittable = true; //반복문이 끝나 무적시간 end, 부딪힐 수 있다.
    }

    public void playerHit()
    {
        if(isHittable == true)
        {
            isHittable = false;
            HP--;

            if(HP <= 0)
                onGameOver();

            StartCoroutine("blink");
            //코루틴 함수는 StartCoroutine이라는 코루틴함수를 실행시키는
            //주체가 살아있어야 함수가 진행이 됨
            //만약 코루틴함수를 호출한 대상이 삭제된다면
            //코루틴이 실행되지 않는다.
            //외부에서 코루틴함수 불러오기보다는 코루틴함수를 실행시키는 함수를 외부에서 호출
            
        }
    }

    public void hitMedal()
    {
        StopCoroutine("blink"); //함수의 이름으로 부르도록
        //블링크 코루틴이 겹치지 않도록 기존 블링크 강제 종료
        this.GetComponent<SpriteRenderer>().enabled = true;
        //블링크가 꺼진 상태에서 중지됐을 수 있기 때문에 스프라이트 켜줌

        isHittable = false;
        StartCoroutine("blink");

        //코루틴 실행 방법
        //1. 함수명 적는 방법
        //2. 함수를 직접 적는 방법
        //1번 방법은 이름을 기준으로 쉽게 정지 가능
        //2번 방법은 함수를 부르는 것이라 정지시키려면 당시에 부른 함수를 따로 저장해놓고
        //저장해놨던 함수를 정지시켜야 한다.
    }

    public void onGameOver()
    {
        isLive = false;
        gameOver.SetActive(true);
        Time.timeScale = 0;
    }

    public void onGameRestart()
    {
        if (isLive == false && Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1; // 기본
            SceneManager.LoadScene(0);
        }
    }
}
