using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.SceneManagement;

public class LobbyManeger : MonoBehaviourPunCallbacks
{
    public InputField Nikename;
    public Text LogText;
    
    void Start()
    {
        PhotonNetwork.GameVersion = "1";
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.ConnectUsingSettings();
        if (PlayerPrefs.HasKey("Nick"))
            PhotonNetwork.NickName = Nikename.text = PlayerPrefs.GetString("Nick");
    }

    public void ConnectToMaster()
    {
        if (Nikename.text == "")
             PhotonNetwork.NickName = Nikename.text = "Player " + Random.Range(100, 999);
        else PhotonNetwork.NickName = Nikename.text;
        PlayerPrefs.SetString("Nick", Nikename.text);
        Log("Player name: " + PhotonNetwork.NickName);
    }
    public void Log(string message)
    {
        Debug.Log(message);
        LogText.text += "\n" + message;
    }
 
    void Update()
    {
        
    }

    public override void OnConnectedToMaster()
    {
        Log("Connected to Master");
    }

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(null);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinedRoom()
    {
        Log("Connect the Room");
        PhotonNetwork.LoadLevel("Game");
    }

}
