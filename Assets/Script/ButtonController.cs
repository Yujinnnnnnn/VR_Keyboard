using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
   
    public GameObject mainUi;


    [Header("1.Screen Keyborad")]
    public GameObject screenKeyborad;
    public GameObject chatPopUp;
    public GameObject getMasege;


    private void Start()
    {
        screenKeyborad.SetActive(false);
        mainUi.SetActive(true);
        
    }



    public void SelectKeyboard(int keyboradNum)
    {

        if (keyboradNum == 1) // Keyboard on Screen
        {
            screenKeyborad.SetActive(true);
            mainUi.SetActive(false);
            chatPopUp.SetActive(true);
            Invoke("GetMasege",2f);

        }
        else if (keyboradNum == 2) //Physical Keyboard
        {
            GameObject physicalButton = GameObject.Find("2.Physical Button");
            Text buttonText = physicalButton.GetComponentInChildren<Text>(); 
            buttonText.text = "Sorry. This is still being tested";
        }
        else if (keyboradNum == 3)//iPhone keyboard
        {
            GameObject iPhoneButton = GameObject.Find("3. iPhone Button"); 
            Text buttonText = iPhoneButton.GetComponentInChildren<Text>();
            buttonText.text = "Sorry. This is still being tested"; 
        }
    }

    

    public void GetMasege()
    {
        getMasege.SetActive(true);
    }
    


}

  