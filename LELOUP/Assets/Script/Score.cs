using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public float score = 0;
    private TMP_Text textscore;
    void Start()
    {
        textscore = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        textscore.text = "Score : " + score;
    }
}
