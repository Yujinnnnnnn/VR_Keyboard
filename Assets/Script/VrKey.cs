using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class VrKey : MonoBehaviour
{
    public enum KeyType
    {
        Screen, Physical, iPhone
    }

    public KeyType type;
  

    private Button button; // 버튼 컴포넌트 저장할 변수
    private TMP_Text tmpText; // Tmp_text 컴포넌트를 저장할 변수
    private RectTransform rectTransform; // RectTransform 컴포넌트를 저장할 변수


    public string Key  // tmpText의 텍스트 값을 가져오거나 설정하는 속성
    {
        get => tmpText.text;
        set => tmpText.text = value;    
    }
    public Button Button => button; // 버튼 컴포넌트를 가져오는 속성
    public Vector2 SizeDelta => rectTransform.sizeDelta;// RectTransform의 크기 값을 가져오는 속성
    public bool IsAlpabet// tmpText에 알파벳만 포함되어 있는지를 검사하는 속성
    {
        get
        {
            if(tmpText.text.Length !=1)
                return false;

            Regex reg = new Regex(@"^[a-zA-Z]+$");
            //tmpText값이 지정된 범위에 있는지 문자인지 체크함.
            return reg.IsMatch(tmpText.text);
        }
    }
    public void ToLower() //소문자로 변경하는 함수. 
    {
        tmpText.text = tmpText.text.ToLower();
    }

    public void ToUpper() //대문자로 변경하는 함수. 
    {
        tmpText.text = tmpText.text.ToUpper();
    }
    public void SetSizeDelta(Vector2 delta)// RectTransform의 크기 값을 변경하는 메소드
    {
        rectTransform.sizeDelta = delta;
    }

    public void Initialize(string data) // VrKey 객체를 초기화하는 메소드
    {
        //일반 문자의 경우
        button = GetComponent<Button>(); // 게임 오브젝트에서 Button 컴포넌트 가져오기
        tmpText = GetComponentInChildren<TMP_Text>(true);// 게임 오브젝트의 자식 중에서 TMP_Text 컴포넌트 가져오기
        rectTransform = GetComponent<RectTransform>(); // 게임 오브젝트에서 RectTransform 컴포넌트 가져오기


        //SPACE-600-96-1\1\0 형태의 문자열일 경우
        //이름 - 크기
        if (data.Contains('-'))
        {
            string[] keyinfoArray = data.Split('-');
            tmpText.text = keyinfoArray[0]; // 배열의 0번째가 키보드에 나올 내용 

            //버튼의 RectTransform 영역을 변경
            // 현재 객체의 자식 중 첫 번째 객체를 가져와서 Image 컴포넌트를 얻어옴
            Image imageComponent = transform.GetComponent<Image>();
            // 이미지 컴포넌트의 RectTransform 컴포넌트를 얻어옴
            RectTransform imageRectTransform = imageComponent.rectTransform;
            // 이미지의 현재 크기를 얻어와서 Vector2 형태로 저장함
            Vector2 sizeDeltaImg = imageRectTransform.sizeDelta;
            tmpText.fontSize = 50; //문자 크기
            sizeDeltaImg.x = int.Parse(keyinfoArray[1]);
            // 변경된 크기를 다시 이미지의 RectTransform 컴포넌트에 저장함
            imageRectTransform.sizeDelta = sizeDeltaImg;



            if(type == KeyType.iPhone)
            {
                Image imageIphone = transform.GetChild(0).GetComponent<Image>();
                tmpText.fontSize = 20; //문자 크기
               

                if (keyinfoArray[0] == "SPACE")
                {
                    sizeDeltaImg.x = 600;
                }else if (keyinfoArray[0] == "@" || keyinfoArray[0] == ".")
                {
                    sizeDeltaImg.x = 110;
                }
                else if (keyinfoArray[0] == "ENTER")
                {
                    tmpText.text = "retune";
                    sizeDeltaImg.x = 400;
                    imageIphone.color = new Color32(171, 176, 186, 255);
                }
                else
                {
                    imageIphone.color = new Color32(171, 176, 186, 255);
                }


            }




        }
        else
        {
            Key = data;
        }




    }

}
