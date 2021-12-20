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
    

    // 각 클라이언트 마다 생성된 플레이어 게임 오브젝트를 리스트로 관리
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

    // PhotonNetwork.LeaveRooom 함수가 호출되면 호출
    public override void OnLeftRoom()
    {
        Debug.Log("Left Room");

        SceneManager.LoadScene("Launcher");
    }

    // 플레이어가 입장할 때 호출되는 함수
    public override void OnPlayerEnteredRoom(Player otherPlayer)
    {
        Debug.LogFormat("Player Entered Room: {0}",
                        otherPlayer.NickName);
    }

    public void ApplyPlayerList()
    {
        // 전체 클라이언트에서 함수 호출
        photonView.RPC("RPCApplyPlayerList", RpcTarget.AllBuffered);
    }

    [PunRPC]
    public void RPCApplyPlayerList()
    {
        int playerCnt = PhotonNetwork.CurrentRoom.PlayerCount;
        // 플레이어 리스트가 최신이라면 건너뜀
        if (playerCnt == playerGoList.Count) return;

        ChkGameStart(playerCnt); //2명 이상일 경우 게임 시작
        CurPlayerCnt = playerCnt;

        // 현재 방에 접속해 있는 플레이어의 수
        Debug.LogError("CurrentRoom PlayerCount : " + playerCnt);

        // 현재 생성되어 있는 모든 포톤뷰 가져오기
        PhotonView[] photonViews = FindObjectsOfType<PhotonView>();

        // 매번 재정렬을 하는게 좋으므로 플레이어 게임오브젝트 리스트를 초기화
        playerGoList.Clear();

        // 현재 생성되어 있는 포톤뷰 전체와
        // 접속중인 플레이어들의 액터넘버를 비교해,
        // 플레이어 게임오브젝트 리스트에 추가
        for (int i = 0; i < playerCnt; ++i)
        {
            // 키는 0이 아닌 1부터 시작
            int key = i + 1;
            for (int j = 0; j < photonViews.Length; ++j)
            {
                // 만약 PhotonNetwork.Instantiate를 통해서 생성된 포톤뷰가 아니라면 넘김
                if (photonViews[j].isRuntimeInstantiated == false) continue;
                // 만약 현재 키 값이 딕셔너리 내에 존재하지 않는다면 넘김
                if (PhotonNetwork.CurrentRoom.Players.ContainsKey(key) == false) continue;

                // 포톤뷰의 액터넘버
                int viewNum = photonViews[j].Owner.ActorNumber;
                // 접속중인 플레이어의 액터넘버
                int playerNum = PhotonNetwork.CurrentRoom.Players[key].ActorNumber;

                // 액터넘버가 같은 오브젝트가 있다면,
                if (viewNum == playerNum)
                {
                    // 게임오브젝트 이름도 알아보기 쉽게 변경
                    photonViews[j].gameObject.name = "Player_" + photonViews[j].Owner.NickName;
                    // 실제 게임오브젝트를 리스트에 추가
                    playerGoList.Add(photonViews[j].gameObject);

                    //유저 색 적용하기
                    photonViews[j].gameObject.GetComponent<MeshRenderer>().material.color = colors[playerNum-1];
                    
                    //유저 닉네임 표시하기
                    TextMesh t_mesh = photonViews[j].gameObject.GetComponentInChildren<TextMesh>();
                    t_mesh.text = photonViews[j].Owner.NickName;
                }
            }
        }

        // 디버그용
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

    // 플레이어가 나갈 때 호출되는 함수
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