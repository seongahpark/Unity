using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handmade : MonoBehaviour
{
    private void Awake()
    {
        // �Ž����� �߰�
        MeshFilter mf = gameObject.AddComponent<MeshFilter>();
        if (mf == null) mf = GetComponent<MeshFilter>();

        // �Ž� ���� �Ҵ�
        Mesh mesh = new Mesh();
        mesh.name = "MyQuad"; // �簢��

        // ���ؽ� ���� �غ�(Vertex Buffer)
        // v1 --- v2
        // |   c  |
        // v3 --- v4
        Vector3[] vertices = new Vector3[4]
        {
            new Vector3(-0.5f, 0.5f, 0f), //v1
            new Vector3(0.5f, 0.5f, 0f), //v2
            new Vector3(-0.5f, -0.5f, 0f), //v3
            new Vector3(0.5f, -0.5f, 0f) //v4
        };
        mesh.vertices = vertices;

        //�ε��� ���� �غ�(Index Buffer)
        //Indices, CW(Clock-Wise)
        int[] triangles = new int[6]
        {
            0,1,2, //t1
            1,3,2 //t2
        };

        mesh.triangles = triangles;

        //UV Coordinate
        Vector2[] uv = new Vector2[4]
        {
            new Vector2(0f, 0f),
            new Vector2(1f, 0f),
            new Vector2(0f, 1f),
            new Vector2(1f, 1f)
        };
        mesh.uv = uv;

        //���� ����(Normal Vector) <- Normal ������ �־�� ������ ����� ����
        Vector3[] normals = new Vector3[4]
        {
            new Vector3(0f, 0f, -1f),
            new Vector3(0f, 0f, -1f),
            new Vector3(0f, 0f, -1f),
            new Vector3(0f, 0f, -1f),
        };
        mesh.normals = normals;

        mf.mesh = mesh;

        ////////////////////////////////////////////////////////////

        MeshRenderer mr = gameObject.AddComponent<MeshRenderer>();

        Material mat = new Material(Shader.Find("Standard"));
        mat.name = "MyStandard";
        //mat.color = new Color(1f, 0f, 0f); // RGB ��

        //Texture2D tex = Resources.Load<Texture2D>("Textures\\T_Maple");
        //Texture2D tex = (Texture2D)Resources.Load("Textures\\T_Maple"); //����� ����ȯ
        Texture2D tex = Resources.Load("Textures\\T_Maple") as Texture2D; // �� ����� ���� ������
        mat.mainTexture = tex;
       
        mr.material = mat;

    }
}
