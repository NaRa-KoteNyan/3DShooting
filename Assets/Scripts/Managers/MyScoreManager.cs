using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MyScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static int score;
    TextMeshProUGUI text;
    void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Score :" + score;
    }
}
