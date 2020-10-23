using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public float score = 0;
    private Text textscore;
    // Start is called before the first frame update
    void Start()
    {
        textscore = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        textscore.text = "Score : " + score;
    }
}
