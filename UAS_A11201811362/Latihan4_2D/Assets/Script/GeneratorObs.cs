using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorObs : MonoBehaviour
{
    public GameObject Rocks;
    public int score = 0;
    GUIStyle guiStyle = new GUIStyle();
    // Start is called before the first frame update
    void Start()
    {
        //digunakan untuk memanggil fungsi CreateObstacle setiap 1.5 detik dengan lama eksekusi dari fungsi tersebut terbatas hanya 1 detik
        InvokeRepeating ("CreateObstacle", 1f, 1.5f);
    }
    void CreateObstacle()
    {
        //digunakan untuk membuat object batu secara otomatis 
        Instantiate(Rocks);
        score++;
        SaveLoadHighScore.SaveHighScore(score); // SaveLoadHighScore diperoleh dari file SaveLoadHighScore
        if (score >= 2)
            GUIManager.SaveLevel (1);
        if (score >= 4)
            GUIManager.SaveLevel (2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnGUI()
    {
        GUI.color = Color.black;
        guiStyle.fontSize = 40;
        GUI.Label(new Rect(0,0,300,50), "Score : "+score.ToString(), guiStyle);
    }
}
