using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TypewriterEffect : MonoBehaviour
{

    public float charsPerSecond ;//����ʱ����
    private string words;//������Ҫ��ʾ������

    private bool isActive = false;
    private float timer;//��ʱ��
    private Text myText;
    private int currentPos = 0;//��ǰ����λ��

    // Use this for initialization
    void Start()
    {
        timer = 0;
        isActive = true;
        myText = GetComponent<Text>();
        words = myText.text;
        myText.text = "";//��ȡText���ı���Ϣ�����浽words�У�Ȼ��̬�����ı���ʾ���ݣ�ʵ�ִ��ֻ���Ч��
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            charsPerSecond = 0.01f;
        }
        OnStartWriter();
    }

    public void StartEffect()
    {
        isActive = true;
    }
    /// <summary>
    /// ִ�д�������
    /// </summary>
    void OnStartWriter()
    {

        if (isActive)
        {
            timer += Time.deltaTime;
            if (timer >= charsPerSecond)
            {//�жϼ�ʱ��ʱ���Ƿ񵽴�
                timer = 0;
                currentPos++;
                myText.text = words.Substring(0, currentPos);//ˢ���ı���ʾ����

                if (currentPos >= words.Length)
                {
                    OnFinish();
                }
            }

        }
    }
    /// <summary>
    /// �������֣���ʼ������
    /// </summary>
    void OnFinish()
    {
        isActive = false;
        timer = 0;
        currentPos = 0;
        myText.text = words;
    }
}
