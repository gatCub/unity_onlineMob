using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using Photon.Realtime;

public class GameManager : MonoBehaviourPunCallbacks
{
    public GameObject PlaeyrPrefab;
    public Camera camPlayer;


    void Start()
    {
        Vector3 pos = new Vector3(Random.Range(-6f, 6f), 0);
        PhotonNetwork.Instantiate(PlaeyrPrefab.name, pos, Quaternion.identity);
        camPlayer.transform.position = new Vector3(pos.x, pos.y, -10);
    }

    void Update()
    {
        
    }

    public override void OnLeftRoom()
    {
        SceneManager.LoadScene("Lobby");
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.LogFormat("Plaeyr {0} entered room", newPlayer.NickName);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.LogFormat("Plaeyr {0} left room", otherPlayer.NickName);
    }

    public void Leave()
    {
        PhotonNetwork.LeaveRoom();
    }

}
