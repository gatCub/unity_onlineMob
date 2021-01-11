using JetBrains.Annotations;
using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaeyrControls : MonoBehaviour, IPunObservable
{
    public PhotonView photonView;
    public SpriteRenderer spriteR;
    public GameObject _interface;
    public Sprite[] Skin;
    public Sprite OtherSprite;
    public Camera cameraPlayer;//
    public Vector2 biasCam = new Vector2(2f, 0.5f);
    public Vector3 currentPosition;
    public bool faceLeft;//
    public bool Side;
    public bool cameraBack;
    //public bool _interfaceOnOff;
    public byte i, j;
    public int lastX;//
    public float damping;//

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(Side);
            stream.SendNext(i);
        }
        else
        {
            Side = (bool) stream.ReceiveNext();
            j = (byte) stream.ReceiveNext();
        }
    }

    void Start()
    {
        photonView = GetComponent<PhotonView>();
        spriteR = GetComponent<SpriteRenderer>();
        i = (byte)PlayerPrefs.GetInt("Sprite");
        spriteR.sprite = Skin[i];
        faceLeft = true;
        cameraBack = false;
        //_interfaceOnOff = false;
        damping = 10f;
        cameraPlayer = Camera.main;
    }

    void Update()
    {
        if (photonView.IsMine)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(Time.deltaTime * 5, 0, 0);
                faceLeft = false;
                FindPlayerCam(faceLeft);
                Side = true;
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(-Time.deltaTime * 5, 0, 0);
                faceLeft = true;
                FindPlayerCam(faceLeft);
                Side = false;
            }
            /*if (Input.GetKeyDown(KeyCode.Escape))
            {
                _interfaceOnOff = !_interfaceOnOff;
                _interface.SetActive(_interfaceOnOff);
            }*/

            if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
            {
                cameraBack = true;
            } 
            if (cameraBack)
            {
                BackCam();
            }
        }
        else spriteR.sprite = Skin[j]; // Спрайт другого игрока каждую секунду 
        if (Side)
        {
            spriteR.flipX = true;
        }
        else 
        {
            spriteR.flipX = false;
        }
        
    }

    // Движение камеры
    public void FindPlayerCam(bool playerFace)
    {
        lastX = Mathf.RoundToInt(transform.position.x); // временно для проверки позиции 

        Vector3 target;
        if (playerFace)
        {
            target = new Vector3(transform.position.x - biasCam.x, transform.position.y + biasCam.y, cameraPlayer.transform.position.z);
        }
        else
        {
            target = new Vector3(transform.position.x + biasCam.x, transform.position.y + biasCam.y, cameraPlayer.transform.position.z);
        }
        currentPosition = Vector3.Lerp(cameraPlayer.transform.position, target, damping * Time.deltaTime);
        cameraPlayer.transform.position = new Vector3(currentPosition.x, currentPosition.y, cameraPlayer.transform.position.z);
    }
    public void BackCam()
    {
        if (cameraPlayer.transform.position == transform.position)
            cameraBack = false;
        currentPosition = Vector3.Lerp(cameraPlayer.transform.position, transform.position, damping * Time.deltaTime);
        cameraPlayer.transform.position = new Vector3(currentPosition.x, currentPosition.y, cameraPlayer.transform.position.z);
    }
}
