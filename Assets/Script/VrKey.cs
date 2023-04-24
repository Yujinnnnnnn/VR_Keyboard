using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class VrKey : MonoBehaviour
{
  
    private Button button;
    private TMP_Text tmpText;
    private RectTransform rectTransform;

    public string Key
    {
        get => tmpText.text;
        set => tmpText.text = value;    
    }
    public Button Button => button; 
    public Vector2 SizeDelta => rectTransform.sizeDelta;
    public bool IsAlpabet
    {
        get
        {
            if(tmpText.text.Length !=1)
                return false;
            Regex reg = new Regex(@"^[a-zA-Z]+$");
            return reg.IsMatch(tmpText.text);
        }
    }
    public void ToLower() //소문자로 변경
    {
        tmpText.text = tmpText.text.ToLower();
    }

    public void ToUpper() //대문자로 변경
    {
        tmpText.text = tmpText.text.ToUpper();
    }
    public void SetSizeDelta(Vector2 delta)
    {
        rectTransform.sizeDelta = delta;
    }

    public void Initialize(string data) 
    {
        //일반 문자
        button = GetComponent<Button>(); 
        tmpText = GetComponentInChildren<TMP_Text>(true);
        rectTransform = GetComponent<RectTransform>();


        //특수 버튼
        if (data.Contains('-'))
        {
            string[] keyinfoArray = data.Split('-');
            tmpText.text = keyinfoArray[0];

            Image imageComponent = transform.GetComponent<Image>();
            RectTransform imageRectTransform = imageComponent.rectTransform;
            Vector2 sizeDeltaImg = imageRectTransform.sizeDelta;
            tmpText.fontSize = 50; 
            sizeDeltaImg.x = int.Parse(keyinfoArray[1]);
            imageRectTransform.sizeDelta = sizeDeltaImg;

        }
        else
        {
            Key = data;
        }




    }

}
