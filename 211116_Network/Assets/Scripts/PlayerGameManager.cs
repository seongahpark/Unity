using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;


public class PlayerGameManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject playerPrefab = null;
    [SerializeField] private Color[] colors = null;

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
}