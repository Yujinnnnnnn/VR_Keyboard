using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScreenKeyboardControl : MonoBehaviour
{

    bool isTexting;
    public GameObject messagePrefab;
    public Transform chatRoom;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void sendMessage(string message)
    {
       
        GameObject newMessage = Instantiate(messagePrefab, chatRoom);
        Transform textTransform = newMessage.transform.Find("Text");
        Text messageText = textTransform.GetComponent<Text>();
        messageText.text = message;
    }

}
