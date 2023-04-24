using UnityEngine;

public class UICanvasFollow: MonoBehaviour
{
    public float speed = 1f; // 캔버스의 이동 속도

    void Update()
    {
        //Vector3 gazeDirection = Camera.main.transform.forward;
       // transform.position += gazeDirection * speed * Time.deltaTime;


        // 카메라를 바라보도록 회전
        transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward,
            Camera.main.transform.rotation * Vector3.up);
    }
}