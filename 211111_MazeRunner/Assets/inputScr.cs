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

    //���ڸ� ����ڰ� ���� �Է��� �� �ֵ��� ���ִ� ui
    //���ڼ� ������ �� �� ������ ���� �� �ִ� ������ ������ ������ �� �ִ�.
    //Content Type�� ���� ��밡���� ������ ������ ������ �� ������
    //�� type�� �´� ���� ���� �ܿ��� �Է��� �Ұ����ϴ�.
    //Place Holder�� �ƹ��� �ؽ�Ʈ�� �Էµ��� �ʾ�����
    //����ڿ��� � �ؽ�Ʈ�� �Է��ؾ��ϴ���, ������� �Է��ؾ��ϴ���
    //�����ִ� ������ ���̵� �ؽ�Ʈ�� �� �� �ִ�.
    //Caret�� Ŀ���� �Ӽ����� �ٲ��� �� ������ �����̴� ��, ����, ũ�� ����
    //�ٲ��� �� �ִ�.
    //read only�� �Ǹ� �ؽ�Ʈ�� ������ �� ����
    //�ؽ�Ʈ�� �����ϰų� ������ �ϴ� ���� ����������.    
}
