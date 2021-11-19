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
    public bool isHittable = true; //�÷��̾ �浹 ������ �������� Ȯ���ϴ� �Լ�
    Rigidbody2D rb;
    float myZ_Angle = 0;//������� z������ ������ �����ϱ����� ����
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

        onGameRestart(); // ���� ����� �Լ�
        
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
            //AddForce�� ������ٵ� ���� �����Ҷ�
            //������ ������ ������ �������� ���� ������ ���ϰ� �ȴ�.
            //���� ���� ���������� ������ �ټ� �������µ�
            //������ ���� ��������(��������) ���� �ʿ��� ���
            //���� ���Ⱚ �ڿ� ���� �ִ� �����
            //ForceMode�� Impulse�� �ְԵǸ�
            //������ ���� �������� �ð��� �����ϱ� ������
            //���� �����ε� ����� �������� �� �ִ�.

            this.transform.Rotate(Vector3.forward * 20);
            myZ_Angle += 20;

            if (myZ_Angle > 30)
            {
                myZ_Angle = 30;
                this.transform.eulerAngles = Vector3.forward * 30;
                //������� ������ 40���� �Ѿ��
                //�ִ밢������ 40���� �ǵ��� ��ġ�� �������ش�.
            }


        }
    }
    //float gravityVelocity = 0.98f;  //�߷°��ӵ�
    //float myDropVelocity = 0;       //�÷��̾��� ���ϼӵ�
   
    private void FixedUpdate()
    {
        //myDropVelocity += gravityVelocity * Time.deltaTime;
        ////�÷��̾��� ���ϼӵ��� �߷°��ӵ��� ����ؼ�
        ////���� �����Ѵ�.
        //this.transform.position += Vector3.down * myDropVelocity;
        ////�÷��̾��� y��ǥ�� ���� ���ϼӵ���ŭ �Ʒ��� �̵�

        Debug.Log(this.transform.eulerAngles.z);

        if (myZ_Angle > -20)
        {
            //eulerAngles: ������Ʈ�� �������� rotation��
            //�����Ϳ��� ���̴� Vector3�� �ƴ϶�
            //Quataniun(���)�� ���·� ������ �ȴ�.
            //���� �������� �����ϱⰡ �ټ� ���������� ������
            //���ʹϾ� ��� Vec3�� ���·� ������ �ٲܼ� �ֵ���
            //���ִ� ������ eulerAngles�̴�.
            this.transform.Rotate(Vector3.back * Time.deltaTime * 30);
            //Rotate: ���� ������ ������ ��ġ��ŭ ȸ����Ű�� �Լ�
            
            myZ_Angle -= 1 * Time.deltaTime * 30;
        }
    }

    IEnumerator blink()
    {
        //�÷��̾ ��ֹ�(��)�� �ε����� ��
        //�÷��̾ ����(�����Ÿ���)��Ű�� �Լ�
        SpriteRenderer sr = this.GetComponent<SpriteRenderer>();
        for(int i=0; i<30; i++)
        {
            sr.enabled = !sr.enabled;
            //��Ʈ����Ʈ �������� ���� ������ �ݴ밪���� �ٲ� �� �ֵ���

            yield return new WaitForSeconds(0.1f);
            //�������� on/off�� 0.1�ʸ��� �ݺ�
        }
        //����Ƽ���� �ݺ����� �ش� �ݺ����� ������������
        //����Ƽ�� ������ ���ߴ°� ����������
        //�ڷ�ƾ �Լ��� �̿��ϸ� �ݺ����� ���ÿ� ������ ����ǵ��� ���� �� ����
        
        isHittable = true; //�ݺ����� ���� �����ð� end, �ε��� �� �ִ�.
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
            //�ڷ�ƾ �Լ��� StartCoroutine�̶�� �ڷ�ƾ�Լ��� �����Ű��
            //��ü�� ����־�� �Լ��� ������ ��
            //���� �ڷ�ƾ�Լ��� ȣ���� ����� �����ȴٸ�
            //�ڷ�ƾ�� ������� �ʴ´�.
            //�ܺο��� �ڷ�ƾ�Լ� �ҷ����⺸�ٴ� �ڷ�ƾ�Լ��� �����Ű�� �Լ��� �ܺο��� ȣ��
            
        }
    }

    public void hitMedal()
    {
        StopCoroutine("blink"); //�Լ��� �̸����� �θ�����
        //��ũ �ڷ�ƾ�� ��ġ�� �ʵ��� ���� ��ũ ���� ����
        this.GetComponent<SpriteRenderer>().enabled = true;
        //��ũ�� ���� ���¿��� �������� �� �ֱ� ������ ��������Ʈ ����

        isHittable = false;
        StartCoroutine("blink");

        //�ڷ�ƾ ���� ���
        //1. �Լ��� ���� ���
        //2. �Լ��� ���� ���� ���
        //1�� ����� �̸��� �������� ���� ���� ����
        //2�� ����� �Լ��� �θ��� ���̶� ������Ű���� ��ÿ� �θ� �Լ��� ���� �����س���
        //�����س��� �Լ��� �������Ѿ� �Ѵ�.
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
            Time.timeScale = 1; // �⺻
            SceneManager.LoadScene(0);
        }
    }
}
