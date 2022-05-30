using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetScore : MonoBehaviour
{

    public GameObject maxScoreText;
    public GameObject durationText;
    // Start is called before the first frame update
    void Start()
    {

        durationText.GetComponent<TextMeshProUGUI>().text = "Duration: " + GameManager.duration;
        maxScoreText.GetComponent<TextMeshProUGUI>().text = "Max Score: " + GameManager.maxScore;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
