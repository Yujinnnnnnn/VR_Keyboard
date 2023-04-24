using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
   
    public GameObject mainUi;


    [Header("1.Screen Keyborad")]
    public GameObject screenKeyborad;
    public GameObject chatPopUp;
    public GameObject getMasege;

    [Header("Physical KeyBorad")]
    public GameObject deskObject;
    public GameObject monitorObject;


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

            //Instantiate(deskObject);
            //Instantiate(monitorObject);
        }
        else if (keyboradNum == 2) //Physical Keyboard
        {
            mainUi.SetActive(false);
            // Instantiate(deskObject);
            // Instantiate(monitorObject);
        }
        else if (keyboradNum == 3)//iPhone keyboard
        {
            mainUi.SetActive(false);
        }
    }


    public void GetMasege()
    {
        getMasege.SetActive(true);
    }
    


}

  