using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapContloler : MonoBehaviour
{
    public GameObject[] Objects;
    // потом либо сортировать один массив обьектов
    //либо создавать несколько массивов и делить обьекты по редкости что бы спамить в нужном кол
    void Start()
    {
        Vector2 pos;
        for (byte i = 0; i < Objects.Length; i++)
        {
            pos = new Vector2(Random.Range(15, 30), 0);
            Instantiate(Objects[i], pos, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
