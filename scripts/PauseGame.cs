using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasueGame : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PausePanel;

    void Start()
    {
        PausePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ResumeGame()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void PauseGame()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0f;
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
