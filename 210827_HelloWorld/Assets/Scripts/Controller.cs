using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour //Component�� ������ �Ϸ��� MonoBehaviour�� ����� ��
{
    //Variables
    [Range(0f, 10f)] //�ٷ� ���� ���� ���� ����
    [SerializeField] private float speed = 10f; //private�̱� ������ �ܺο����� ���� x
                                                //public���� �ϸ� unity �÷��������� ���� �� ��ȯ ����
                                                //�տ� serializedField�� �ٿ��ָ� private�̾ unity������ ��ȯ ����
    private float rotSpeed = 30f;

    private Gun gun = null;

    //Property(Getter / Setter)
    public float Speed //�� �빮�ڷ� �� ��
    {
        set { speed = value; }
        get { return speed; }
    }

    public int val { get; set; } //�⺻���� get/set�� �������


    //Functions
    // Start is called before the first frame update
    private void Start()
    {
        //�Ƶ��̳뿡�� setup ���� �Լ�, ���α׷��� ���� �� �� ���ʷ� �� ���� ����
        //Speed = 100f;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            //Transform tr = GetComponent<Transform>(); �� �۾��� ���ص� Ʈ�������� �ٷ� ������ �����ϵ��� �Ǿ�����
            transform.position =
                transform.position +
                (Vector3.forward * speed * Time.deltaTime);//Time.deltaTime�� ����� ������ �ð����� ����
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(
                Vector3.back * speed * Time.deltaTime); //���� �ڵ�� ������ ����
        }
        if (Input.GetKey(KeyCode.A)) MoveWithDir(Vector3.left);
        if (Input.GetKey(KeyCode.D)) MoveWithDir(Vector3.right);
        //MoveWithDir(transform.forward); �� ĳ���Ͱ� ���� ���� ����
        //MoveWithDir(Vector3.right); ������ ����

        //Rotate
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0f, -rotSpeed * Time.deltaTime, 0f); //x, y, z
            //�ݴ�� ��������� -speed �ϸ� �ȴ�
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up, rotSpeed * Time.deltaTime); // �ش� ���� �������� ����
        }

        //Local, Model Coordinate / Space
        // World Space
        // Pitch, Yaw, Roll
        // Euler Angle -> Gimbal Lock1
        // Quaternion

        if (Input.GetMouseButtonDown(0)) //���콺�� ���������� �˻�
        {
            gun.Fire();
        }
    }

    private void MoveWithDir(Vector3 _dir)
    {
        //transform.Translate(_dir * speed * Time.deltaTime); //ȸ���ϳĿ� ���� �����̴� ���� �޶���
        transform.position =
            transform.position +
            (_dir * speed * Time.deltaTime); //���� �� �������� �������� ȸ���ϳ� ���� ������ X
    }

    private void Awake()
    {
        gun = GetComponent<Gun>();
    }
}
