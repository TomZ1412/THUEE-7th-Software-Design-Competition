using System;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    //public Canvas can;

    public GameObject obj;
    public Text _text;


    String[] strings = { "你来了！过来，你看，这就是王国维研究过的甲骨文。当时王国维就任清华讲师，曾致力于破解甲骨的秘密，可惜他不到50岁便不幸离世，只留下了这尚未破解的甲骨谜题。",
                          "直到两个月前，我们的团队才从王国维生前的手稿中发现了一些蛛丝马迹，并借此成功破解了甲骨文的秘密。", 
                          "顺着甲骨的指示，我们发现了一张地图，可以指示那件神秘机关的位置。",
                          "此事事关重大，我们没有立刻将机关取出，而是向外封锁了消息，并将地图藏在了清华大学的校医院。",
                          "既然如今中央决定启用此神器，并派你前来，那就请你赶快前往校医院吧，我们已经安排好人接应你了。",

                          "你是从甲骨那边过来的吧。你来看，这是我从染病尸体上提取的血液中的一种新型病毒。这种病毒变异速度极快，以人类目前的能力，根本无法研发出可用的疫苗。",
                          "留给我们的时间已经不多了",
                          "这就是我们发现的那张地图，上面标记了11个地点，请你依次前往这11个地点，然后就能找到那件机关了",
                          "此事事关人类前途命运，请你务必找到那件机关，使世间重回安宁。"};

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
