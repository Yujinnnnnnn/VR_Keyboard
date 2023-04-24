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
  

    private Button button; // ��ư ������Ʈ ������ ����
    private TMP_Text tmpText; // Tmp_text ������Ʈ�� ������ ����
    private RectTransform rectTransform; // RectTransform ������Ʈ�� ������ ����


    public string Key  // tmpText�� �ؽ�Ʈ ���� �������ų� �����ϴ� �Ӽ�
    {
        get => tmpText.text;
        set => tmpText.text = value;    
    }
    public Button Button => button; // ��ư ������Ʈ�� �������� �Ӽ�
    public Vector2 SizeDelta => rectTransform.sizeDelta;// RectTransform�� ũ�� ���� �������� �Ӽ�
    public bool IsAlpabet// tmpText�� ���ĺ��� ���ԵǾ� �ִ����� �˻��ϴ� �Ӽ�
    {
        get
        {
            if(tmpText.text.Length !=1)
                return false;

            Regex reg = new Regex(@"^[a-zA-Z]+$");
            //tmpText���� ������ ������ �ִ��� �������� üũ��.
            return reg.IsMatch(tmpText.text);
        }
    }
    public void ToLower() //�ҹ��ڷ� �����ϴ� �Լ�. 
    {
        tmpText.text = tmpText.text.ToLower();
    }

    public void ToUpper() //�빮�ڷ� �����ϴ� �Լ�. 
    {
        tmpText.text = tmpText.text.ToUpper();
    }
    public void SetSizeDelta(Vector2 delta)// RectTransform�� ũ�� ���� �����ϴ� �޼ҵ�
    {
        rectTransform.sizeDelta = delta;
    }

    public void Initialize(string data) // VrKey ��ü�� �ʱ�ȭ�ϴ� �޼ҵ�
    {
        //�Ϲ� ������ ���
        button = GetComponent<Button>(); // ���� ������Ʈ���� Button ������Ʈ ��������
        tmpText = GetComponentInChildren<TMP_Text>(true);// ���� ������Ʈ�� �ڽ� �߿��� TMP_Text ������Ʈ ��������
        rectTransform = GetComponent<RectTransform>(); // ���� ������Ʈ���� RectTransform ������Ʈ ��������


        //SPACE-600-96-1\1\0 ������ ���ڿ��� ���
        //�̸� - ũ��
        if (data.Contains('-'))
        {
            string[] keyinfoArray = data.Split('-');
            tmpText.text = keyinfoArray[0]; // �迭�� 0��°�� Ű���忡 ���� ���� 

            //��ư�� RectTransform ������ ����
            // ���� ��ü�� �ڽ� �� ù ��° ��ü�� �����ͼ� Image ������Ʈ�� ����
            Image imageComponent = transform.GetComponent<Image>();
            // �̹��� ������Ʈ�� RectTransform ������Ʈ�� ����
            RectTransform imageRectTransform = imageComponent.rectTransform;
            // �̹����� ���� ũ�⸦ ���ͼ� Vector2 ���·� ������
            Vector2 sizeDeltaImg = imageRectTransform.sizeDelta;
            tmpText.fontSize = 50; //���� ũ��
            sizeDeltaImg.x = int.Parse(keyinfoArray[1]);
            // ����� ũ�⸦ �ٽ� �̹����� RectTransform ������Ʈ�� ������
            imageRectTransform.sizeDelta = sizeDeltaImg;



            if(type == KeyType.iPhone)
            {
                Image imageIphone = transform.GetChild(0).GetComponent<Image>();
                tmpText.fontSize = 20; //���� ũ��
               

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
