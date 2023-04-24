using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate : MonoBehaviour
{

    //VR �׽�Ʈ�� ���� �ӽ� ī�޶� ��Ʈ��
    Vector3 angle;
    public float sensitivity = 200; //���콺�� ����

    void Start()
    {
        angle.y = -Camera.main.transform.eulerAngles.x;
        angle.x = Camera.main.transform.eulerAngles.y;
        angle.z = Camera.main.transform.eulerAngles.z;
    }


    void Update()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");
        angle.x += x * sensitivity * Time.deltaTime;
        angle.y += y * sensitivity * Time.deltaTime;
        transform.eulerAngles = new Vector3(-angle.y, angle.x, transform.eulerAngles.z);
    }
}