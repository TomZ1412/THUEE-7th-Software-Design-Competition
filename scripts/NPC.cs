using System;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    //public Canvas can;

    public GameObject obj;
    public Text _text;


    String[] strings = { "�����ˣ��������㿴�����������ά�о����ļ׹��ġ���ʱ����ά�����廪��ʦ�����������ƽ�׹ǵ����ܣ���ϧ������50��㲻��������ֻ����������δ�ƽ�ļ׹����⡣",
                          "ֱ��������ǰ�����ǵ��ŶӲŴ�����ά��ǰ���ָ��з�����һЩ��˿��������˳ɹ��ƽ��˼׹��ĵ����ܡ�", 
                          "˳�ż׹ǵ�ָʾ�����Ƿ�����һ�ŵ�ͼ������ָʾ�Ǽ����ػ��ص�λ�á�",
                          "�����¹��ش�����û�����̽�����ȡ�������������������Ϣ��������ͼ�������廪��ѧ��УҽԺ��",
                          "��Ȼ�������������ô�������������ǰ�����Ǿ�����Ͽ�ǰ��УҽԺ�ɣ������Ѿ����ź��˽�Ӧ���ˡ�",

                          "���ǴӼ׹��Ǳ߹����İɡ��������������Ҵ�Ⱦ��ʬ������ȡ��ѪҺ�е�һ�����Ͳ��������ֲ��������ٶȼ��죬������Ŀǰ�������������޷��з������õ����硣",
                          "�������ǵ�ʱ���Ѿ�������",
                          "��������Ƿ��ֵ����ŵ�ͼ����������11���ص㣬��������ǰ����11���ص㣬Ȼ������ҵ��Ǽ�������",
                          "�����¹�����ǰ;���ˣ���������ҵ��Ǽ����أ�ʹ�����ػذ�����"};

    Rigidbody2D rigidbody2d;

    public int textNum ;

    public int maxNum;
    // Start is called before the first frame update
    private void Awake()
    {
    }

    void Start()
    {
        
        rigidbody2d = GetComponent<Rigidbody2D>();
        obj.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        _text.text = strings[textNum];
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        obj.SetActive(true);
        GameObject.Find("hospital").transform.Find("hosCanvas/tip").gameObject.SetActive(false);
        GameObject.Find("library").transform.Find("libCanvas/tip").gameObject.SetActive(false);
    }

    public void nextText()
    {
        if (textNum < maxNum)
        {
            textNum++;
        }
        else
        {
            obj.SetActive(false);
        }
        
    }
}
