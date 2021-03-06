using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;


public class PlayerCtrl : MonoBehaviourPun, IPunInstantiateMagicCallback
{
    private PlayerGameManager gm = null;
    private Rigidbody rb = null;

    [SerializeField] private GameObject bulletPrefab = null;

    [SerializeField] private Color[] colors = null;
    [SerializeField] private float speed = 3.0f;

    //NICKNAME 표시
    [SerializeField] private GameObject t_nick;
    TextMesh t_mesh;
    public Camera cam;

    private int hp = 3;
    private bool isDead = false;

    private void Awake()
    {
        gm = GameObject.Find("GameManager").GetComponent<PlayerGameManager>();
        rb = this.GetComponent<Rigidbody>();
        t_mesh = t_nick.GetComponent<TextMesh>();
        cam = Camera.main;
    }

    private void Start()
    {
        isDead = false;
    }

    private void Update()
    {
        if (!photonView.IsMine) return;
        if (isDead) return;

        if (Input.GetKey(KeyCode.W))
            rb.AddForce(Vector3.forward * speed);
        if (Input.GetKey(KeyCode.S))
            rb.AddForce(Vector3.back * speed);
        if (Input.GetKey(KeyCode.A))
            rb.AddForce(Vector3.left * speed);
        if (Input.GetKey(KeyCode.D))
            rb.AddForce(Vector3.right * speed);

        if (Input.GetMouseButtonDown(0)) ShootBullet();

        LookAtMouseCursor();

        SetNick();
    }

    private void SetNick()
    {
        t_mesh.text = PhotonNetwork.NickName;
        t_nick.transform.rotation = cam.transform.rotation;
        Vector3 pos = this.transform.position;
        pos.z += 6;
        t_nick.transform.position = pos;
    }

    public void SetMaterial(int _playerNum)
    {
        Debug.LogError(_playerNum + " : " + colors.Length);
        if (_playerNum > colors.Length) return;

        this.GetComponent<MeshRenderer>().material.color = colors[_playerNum - 1];
    }

    private void ShootBullet()
    {
        if (bulletPrefab)
        {
            GameObject go = PhotonNetwork.Instantiate(
                bulletPrefab.name,
                this.transform.position,
                Quaternion.identity);
            go.GetComponent<PlayerBullet>().Shoot(this.gameObject, this.transform.forward);
        }
    }

    public void LookAtMouseCursor()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerPos = Camera.main.WorldToScreenPoint(this.transform.position);
        Vector3 dir = mousePos - playerPos;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.AngleAxis(-angle + 90.0f, Vector3.up);
    }

    [PunRPC]
    public void ApplyHp(int _hp)
    {
        hp = _hp;
        Debug.LogErrorFormat("{0} Hp: {1}",
            PhotonNetwork.NickName,
            hp
            );

        if (hp <= 0)
        {
            Debug.LogErrorFormat("Destroy: {0}", PhotonNetwork.NickName);
            isDead = true;
            gm.isDead(t_mesh.text);
            gm.DiePlayerCnt++;
            gm.ChkGameOver();
            PhotonNetwork.Destroy(this.gameObject);
        }
    }

    [PunRPC]
    public void OnDamage(int _dmg)
    {
        hp -= _dmg;
        photonView.RPC("ApplyHp", RpcTarget.All, hp);
        //photonView.RPC("ApplyHp", RpcTarget.Others, hp);
    }

    // PhotonNetwork.Instantiate로 객체가 생성되면 호출되는 콜백함수
    // -> IPunInstantiateMagicCallback 필요
    public void OnPhotonInstantiate(PhotonMessageInfo info)
    {
        // 전체에게 통지하기 떄문에 마스터만 처리
        if (!PhotonNetwork.IsMasterClient) return;

        // 게임매니저에 정의되어 있는 함수 호출
        FindObjectOfType<PlayerGameManager>().ApplyPlayerList();
    }
}