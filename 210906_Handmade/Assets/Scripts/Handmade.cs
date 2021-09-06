using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handmade : MonoBehaviour
{
    private void Awake()
    {
        // 매쉬필터 추가
        MeshFilter mf = gameObject.AddComponent<MeshFilter>();
        if (mf == null) mf = GetComponent<MeshFilter>();

        // 매쉬 동적 할당
        Mesh mesh = new Mesh();
        mesh.name = "MyQuad"; // 사각형

        // 버텍스 버퍼 준비(Vertex Buffer)
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

        //인덱스 버퍼 준비(Index Buffer)
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

        //법선 벡터(Normal Vector) <- Normal 연산이 있어야 조명이 제대로 들어간다
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
        //mat.color = new Color(1f, 0f, 0f); // RGB 값

        //Texture2D tex = Resources.Load<Texture2D>("Textures\\T_Maple");
        //Texture2D tex = (Texture2D)Resources.Load("Textures\\T_Maple"); //명시적 형변환
        Texture2D tex = Resources.Load("Textures\\T_Maple") as Texture2D; // 이 방법이 가장 안정적
        mat.mainTexture = tex;
       
        mr.material = mat;

    }
}
