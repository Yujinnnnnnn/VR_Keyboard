using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.UI;

public class VrKeyboard : MonoBehaviour
{
    private string keyInfo = "q,w,e,r,t,y,u,i,o,p\n" +
                            "a,s,d,f,g,h,j,k,l,:\n" +
                            "ABC-250,z,x,c,v,b,n,m,BACK-250\n" +
                            "123-250,SPACE-800,@-100,.-100,ENTER-350";


    public HorizontalLayoutGroup rowPrefab;
    public VrKey keyPrefab;

    //입력된 문자열이 출력 될 TExt
    public TMP_Text enteredString;

    //캔버스의 rectTransform
    private RectTransform rectTransform;

    //행의 높이
   // [SerializeField] private float height = 50;

    //rowPrefab 이 연결될 장소
    private VerticalLayoutGroup verticalLayoutGroup;

    //대소문자 여부
    private bool isLower = true;

    //대소문자 변경등에 사용하기 위해서 저장 될 별수가 필요함
    private List<VrKey> keyList = new List<VrKey>();

    public string EnteredString => enteredString.text;

    //VRkeyborad 에 있는 내용을 받고자 할때 연결할 델리게이트
    public event System.Action<string> Onsubmit;


    public ScreenKeyboardControl screenKeyboardControl;

    public T Find<T>(string path) where T : Component // 컴포넌트를 상속받은무엇인가를 넘겨주겠다는 뜻 
    {
        Transform t = transform.Find(path);
        if(t !=null)
        {
            T component =t.GetComponent<T>();
            return component;
        
        }
        return null;
    } 

    //T 는 사용자가 지정한 타입을 넘겨주겠다는 리턴 타입. 


    public void Initialize()
    {
        verticalLayoutGroup = GetComponentInChildren<VerticalLayoutGroup>(true);
        rectTransform = GetComponent<RectTransform>();
        enteredString.text = " ";
        parsing(keyInfo);
    }

    void parsing(string info)
    {

        //개행 문자를 기준으로행을 분리
        string[] row = info.Split('\n');
        float width = 0;
        for(int i = 0; i < row.Length; i++)
        {
            HorizontalLayoutGroup horizontal = Instantiate(rowPrefab, verticalLayoutGroup.transform);

            string[] column = row[i].Split(",");
            float hSize = 0;
            for (int j = 0; j < column.Length; j++)
            {

                VrKey vrKey = Instantiate(keyPrefab, horizontal.transform);
                vrKey.Initialize(column[j]);
                vrKey.Button.onClick.RemoveAllListeners();
                vrKey.Button.onClick.AddListener(() => OnClickButton(vrKey));
                keyList.Add(vrKey);


                //VrKey vrKey = Instantiate(keyPrefab,horizontal.transform);
                //vrKey.Initialize(column[j]);
                //vrKey.Button.onClick.AddListener(() => OnClickButton(vrKey)); // 글자 클릭
                //keyList.Add(vrKey);
                //글자 사이즈는 다를 수 있음. 글자의 너비 사이즈를 누적해 구합니다. 
                //hSize += vrKey.SizeDelta.x + horizontal.spacing;


            }
            //좌우 여백을 더 주기 위해서 40 만큼 확장.
            //hSize += 40;
            //if (width < hSize)
            //{
            //    width = hSize;
            //}

            //=> : 이건 람다식
            //delegate (){} // 무명형식

        }
        //row에 대한 전체 간격 값을 계산
        float verticalSpacing = verticalLayoutGroup.transform.childCount * verticalLayoutGroup.spacing;
        //rectTransform.sizeDelta =  new Vector2(width, verticalSpacing + height * row.Length);
    }

    public void ChangeUpperOrLower(VrKey button)
    {
        isLower = !isLower;
        if (isLower)
        {
            button.ToUpper();
        }
        else
        {
            button.ToLower();
        }
   
    }



    void OnClickButton (VrKey button)
    {

        switch(button.Key)//내가 가지고잇는 문자열이 누군지 체크
        {
            case "SPACE":
                enteredString.text += " ";
                break;
            case "ABC":
                ChangeUpperOrLower(button);
                break;
            case "abc":
                ChangeUpperOrLower(button);
                break;

            case "BACK":
                //enteredString.text += enteredString.text.Substring(0, Mathf.Max(0, enteredString.text.Length - 1));
                enteredString.text = enteredString.text.Substring(0, enteredString.text.Length - 1);
                break;

            case "ENTER":
                screenKeyboardControl.sendMessage(enteredString.text);
                if (Onsubmit != null)
                {
                    Onsubmit(enteredString.text);
                   
                }

                enteredString.text = ""; 
                break;

            default:
                enteredString.text += button.Key;
                break;

           
        }
    }

    private void Start()
    {
        Initialize();
    }

}
