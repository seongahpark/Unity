using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;


public class PlayerGameManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject playerPrefab = null;
    [SerializeField] private Color[] colors = null;

    public bool gameStart = false;
    public bool gameOver = false;
    [SerializeField] private Text t_gamestart;
    [SerializeField] private Text t_playerdie;
    public int CurPlayerCnt = 1;
    public int DiePlayerCnt = 0;
    

    // �� Ŭ���̾�Ʈ ���� ������ �÷��̾� ���� ������Ʈ�� ����Ʈ�� ����
    private List<GameObject> playerGoList = new List<GameObject>();


    private void Start()
    {
        if (playerPrefab != null)
        {
            GameObject go = PhotonNetwork.Instantiate(
                playerPrefab.name,
                new Vector3(
                    Random.Range(-10.0f, 10.0f),
                    0.0f,
                    Random.Range(-10.0f, 10.0f)),
                Quaternion.identity,
                0);
            go.GetComponent<PlayerCtrl>().SetMaterial(PhotonNetwork.CurrentRoom.PlayerCount);
        }

        t_gamestart.gameObject.SetActive(false);
        t_playerdie.gameObject.SetActive(false);
    }

    // PhotonNetwork.LeaveRooom �Լ��� ȣ��Ǹ� ȣ��
    public override void OnLeftRoom()
    {
        Debug.Log("Left Room");

        SceneManager.LoadScene("Launcher");
    }

    // �÷��̾ ������ �� ȣ��Ǵ� �Լ�
    public override void OnPlayerEnteredRoom(Player otherPlayer)
    {
        Debug.LogFormat("Player Entered Room: {0}",
                        otherPlayer.NickName);
    }

    public void ApplyPlayerList()
    {
        // ��ü Ŭ���̾�Ʈ���� �Լ� ȣ��
        photonView.RPC("RPCApplyPlayerList", RpcTarget.AllBuffered);
    }

    [PunRPC]
    public void RPCApplyPlayerList()
    {
        int playerCnt = PhotonNetwork.CurrentRoom.PlayerCount;
        // �÷��̾� ����Ʈ�� �ֽ��̶�� �ǳʶ�
        if (playerCnt == playerGoList.Count) return;

        ChkGameStart(playerCnt); //2�� �̻��� ��� ���� ����
        CurPlayerCnt = playerCnt;

        // ���� �濡 ������ �ִ� �÷��̾��� ��
        Debug.LogError("CurrentRoom PlayerCount : " + playerCnt);

        // ���� �����Ǿ� �ִ� ��� ����� ��������
        PhotonView[] photonViews = FindObjectsOfType<PhotonView>();

        // �Ź� �������� �ϴ°� �����Ƿ� �÷��̾� ���ӿ�����Ʈ ����Ʈ�� �ʱ�ȭ
        playerGoList.Clear();

        // ���� �����Ǿ� �ִ� ����� ��ü��
        // �������� �÷��̾���� ���ͳѹ��� ����,
        // �÷��̾� ���ӿ�����Ʈ ����Ʈ�� �߰�
        for (int i = 0; i < playerCnt; ++i)
        {
            // Ű�� 0�� �ƴ� 1���� ����
            int key = i + 1;
            for (int j = 0; j < photonViews.Length; ++j)
            {
                // ���� PhotonNetwork.Instantiate�� ���ؼ� ������ ����䰡 �ƴ϶�� �ѱ�
                if (photonViews[j].isRuntimeInstantiated == false) continue;
                // ���� ���� Ű ���� ��ųʸ� ���� �������� �ʴ´ٸ� �ѱ�
                if (PhotonNetwork.CurrentRoom.Players.ContainsKey(key) == false) continue;

                // ������� ���ͳѹ�
                int viewNum = photonViews[j].Owner.ActorNumber;
                // �������� �÷��̾��� ���ͳѹ�
                int playerNum = PhotonNetwork.CurrentRoom.Players[key].ActorNumber;

                // ���ͳѹ��� ���� ������Ʈ�� �ִٸ�,
                if (viewNum == playerNum)
                {
                    // ���ӿ�����Ʈ �̸��� �˾ƺ��� ���� ����
                    photonViews[j].gameObject.name = "Player_" + photonViews[j].Owner.NickName;
                    // ���� ���ӿ�����Ʈ�� ����Ʈ�� �߰�
                    playerGoList.Add(photonViews[j].gameObject);

                    //���� �� �����ϱ�
                    photonViews[j].gameObject.GetComponent<MeshRenderer>().material.color = colors[playerNum-1];
                    
                    //���� �г��� ǥ���ϱ�
                    TextMesh t_mesh = photonViews[j].gameObject.GetComponentInChildren<TextMesh>();
                    t_mesh.text = photonViews[j].Owner.NickName;
                }
            }
        }

        // ����׿�
        PrintPlayerList();
    }

    private void PrintPlayerList()
    {
        foreach (GameObject go in playerGoList)
        {
            if (go != null)
            {
                Debug.LogError(go.name);
            }
        }
    }

    // �÷��̾ ���� �� ȣ��Ǵ� �Լ�
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.LogFormat("Player Left Room: {0}",
                        otherPlayer.NickName);
    }

    public void LeaveRoom()
    {
        Debug.Log("Leave Room");

        PhotonNetwork.LeaveRoom();
    }

    public void ChkGameStart(int playerCnt)
    {
        if(playerCnt > 2)
        {
            t_gamestart.text = "New Player Found";
            t_gamestart.gameObject.SetActive(true);
            Invoke("TextGameStart", 2.0f);
        }
        else if(playerCnt > 1)
        {
            gameStart = true;
            t_gamestart.text = "Game Start";
            t_gamestart.gameObject.SetActive(true);
            Invoke("TextGameStart", 2.0f);
        }
    }

    private void TextGameStart()
    {
        t_gamestart.gameObject.SetActive(false);
        t_playerdie.gameObject.SetActive(false);
    }

    public void isDead(string player)
    {
        t_playerdie.text = player + " has been Killed";
        t_playerdie.gameObject.SetActive(true);
        Invoke("TextGameStart", 2.0f);
    }

    public void ChkGameOver()
    {
        Debug.LogError("cur & die " + CurPlayerCnt + ", " + DiePlayerCnt);
        int chkcnt = CurPlayerCnt - DiePlayerCnt;
        if (gameStart && (chkcnt <=1))
        {    
            gameOver = true;
            t_gamestart.text = "GAME OVER";
            t_gamestart.gameObject.SetActive(true);
            Invoke("SetTimeScale", 1.5f);
        }
    }

    public void SetTimeScale()
    {
        Time.timeScale = 0;
        t_playerdie.gameObject.SetActive(false);
    }
}