using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    void Start()
    {
        GameObject.Find("Canvas/Menu/UI").SetActive(false);
        animator = GetComponent<Animator>();
        Invoke("UIable", 0.75f);
        GameObject.Find("Canvas").transform.Find("Menu/UI/Panel").gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        animator.SetBool("FadeOut", true);
        GameObject.Find("Canvas/Menu/UI").SetActive(false);
        Invoke("loadGame", 1.0f);
    }
    
    public void openMaker()
    {
        GameObject.Find("Canvas").transform.Find("Menu/UI/Panel").gameObject.SetActive(true);
    }
    public void closeMaker()
    {
        GameObject.Find("Canvas").transform.Find("Menu/UI/Panel").gameObject.SetActive(false);
    }
    private void loadGame()
    {
        GlobalScript.Instance.stage++;
        GlobalScript.Instance.Sound();
        SceneManager.LoadScene(1);
    }
    


    public void UIable()
    {
        GameObject.Find("Canvas/Menu/UI").SetActive(true);
    }

    public void Quit()
    {
      #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
      #else
        Application.Quit();
      #endif
    }
}
