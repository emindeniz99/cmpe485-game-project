using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetScore : MonoBehaviour
{

    public GameObject scoreText;
    // Start is called before the first frame update
    void Start()
    {

        scoreText.GetComponent<TextMeshProUGUI>().text = "Score: " + GameManager.score;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
