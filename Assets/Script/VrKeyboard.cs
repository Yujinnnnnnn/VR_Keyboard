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

    //�Էµ� ���ڿ��� ��� �� TExt
    public TMP_Text enteredString;

    //ĵ������ rectTransform
    private RectTransform rectTransform;

    //���� ����
   // [SerializeField] private float height = 50;

    //rowPrefab �� ����� ���
    private VerticalLayoutGroup verticalLayoutGroup;

    //��ҹ��� ����
    private bool isLower = true;

    //��ҹ��� ���� ����ϱ� ���ؼ� ���� �� ������ �ʿ���
    private List<VrKey> keyList = new List<VrKey>();

    public string EnteredString => enteredString.text;

    //VRkeyborad �� �ִ� ������ �ް��� �Ҷ� ������ ��������Ʈ
    public event System.Action<string> Onsubmit;


    public ScreenKeyboardControl screenKeyboardControl;

    public T Find<T>(string path) where T : Component // ������Ʈ�� ��ӹ��������ΰ��� �Ѱ��ְڴٴ� �� 
    {
        Transform t = transform.Find(path);
        if(t !=null)
        {
            T component =t.GetComponent<T>();
            return component;
        
        }
        return null;
    } 

    //T �� ����ڰ� ������ Ÿ���� �Ѱ��ְڴٴ� ���� Ÿ��. 


    public void Initialize()
    {
        verticalLayoutGroup = GetComponentInChildren<VerticalLayoutGroup>(true);
        rectTransform = GetComponent<RectTransform>();
        enteredString.text = " ";
        parsing(keyInfo);
    }

    void parsing(string info)
    {

        //���� ���ڸ� ������������ �и�
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
                //vrKey.Button.onClick.AddListener(() => OnClickButton(vrKey)); // ���� Ŭ��
                //keyList.Add(vrKey);
                //���� ������� �ٸ� �� ����. ������ �ʺ� ����� ������ ���մϴ�. 
                //hSize += vrKey.SizeDelta.x + horizontal.spacing;


            }
            //�¿� ������ �� �ֱ� ���ؼ� 40 ��ŭ Ȯ��.
            //hSize += 40;
            //if (width < hSize)
            //{
            //    width = hSize;
            //}

            //=> : �̰� ���ٽ�
            //delegate (){} // ��������

        }
        //row�� ���� ��ü ���� ���� ���
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

        switch(button.Key)//���� �������մ� ���ڿ��� ������ üũ
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
