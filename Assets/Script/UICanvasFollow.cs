using UnityEngine;

public class UICanvasFollow: MonoBehaviour
{
    public float speed = 1f; // ĵ������ �̵� �ӵ�

    void Update()
    {
        //Vector3 gazeDirection = Camera.main.transform.forward;
       // transform.position += gazeDirection * speed * Time.deltaTime;


        // ī�޶� �ٶ󺸵��� ȸ��
        transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward,
            Camera.main.transform.rotation * Vector3.up);
    }
}