using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class GUIManager : MonoBehaviour
{
    public Button bEasy, bMedium, bHard;
    // Start is called before the first frame update
    void Start()
    {
        try
        {
            LoadButtonLevel();
            int levelstate = LoadLevel();
            switch (levelstate)
            {
                case 0:
                    bEasy.interactable = true;
                    break;
                case 1:
                    bEasy.interactable = true;
                    bMedium.interactable = true;
                    break;
                case 2:
                    bEasy.interactable = true;
                    bMedium.interactable = true;
                    bHard.interactable = true;
                    break;
            }
        }
        catch(NullReferenceException e)
        {
            e = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnPlay ()
    {
        SceneManager.LoadScene("MultiLevel");
    }
    public void OnLevel1()
    {
        SceneManager.LoadScene("Main");
    }
    public void OnLevel2()
    {
        SceneManager.LoadScene("Main");
    }
    public void OnLevel3()
    {
        SceneManager.LoadScene("Main");
    }
    public void OnCredit ()
    {
        SceneManager.LoadScene("Credit");
    }

    public void OnHelp ()
    {
        SceneManager.LoadScene("Help");
    }

    public void OnBack ()
    {
        SceneManager.LoadScene("Menu");
    }

    public static int LoadLevel()
    {
        int hg = 0;
        if (!PlayerPrefs.HasKey("level"))
            PlayerPrefs.SetInt("level", 0);
        else
            hg = PlayerPrefs.GetInt("level");
        return hg;
    }

    public static void SaveLevel(int lvl)
    {
        if (!PlayerPrefs.HasKey("level"))
            PlayerPrefs.SetInt("level", 0);
        else
            PlayerPrefs.SetInt("level", lvl);
    }

    void LoadButtonLevel()
    {
        bEasy = GameObject.Find("Easy").GetComponent<Button>();
        bMedium = GameObject.Find("Medium").GetComponent<Button>();
        bHard = GameObject.Find("Hard").GetComponent<Button>();
        bEasy.interactable = bMedium.interactable = bHard.interactable = false;
    }
}
