using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject scoreGUI;
    public GameObject durationGUI;

    public static long duration = 0;

    public static long score = 0;
    public static long maxScore = 0;

    public static float speed;

    public static float areaWidth;

    public static float areaHeight;

    public static float positionScaleRatio = 1;

    public GameObject ground;

    public static GameManager instance;


    public static GameObject lastItem;
    // Start is called before the first frame update
    void Start()
    {

        instance = this;

        duration = 0;
        score = 0;
        maxScore = 0;

        speed = 15;

        areaWidth = ground.transform.localScale.x * positionScaleRatio;
        areaHeight = ground.transform.localScale.z * positionScaleRatio;

        ground.transform.localScale = new Vector3(ground.transform.localScale.x,
            ground.transform.localScale.y,
            ground.transform.localScale.z * 10);

        StartCoroutine(SpeedUp());
        StartCoroutine(countTime());

        instance.scoreGUI.GetComponent<TextMeshProUGUI>().text = "Score: " + score;

    }

    // Update is called once per frame
    void Update()
    {

        if (PoolManager.Instance.isPoolingEnabled)
        {
            if (!PoolManager.Instance.CanGet(2)) return;

            // left
            var newBall = PoolManager.Instance.GetFromPool();

            // right
            var newBall2 = PoolManager.Instance.GetFromPool();

            // item position left and right
            var gap = 1.5f;
            if (lastItem != null)
            {
                newBall.transform.position = lastItem.transform.position + new Vector3(0, 0, Mathf.Sqrt(speed) * 3.5f);
                newBall2.transform.position = lastItem.transform.position + new Vector3(gap * 2, 0, Mathf.Sqrt(speed) * 3.5f);
            }
            else
            {
                newBall.transform.position = new Vector3(-gap, 0.5f, areaHeight);
                newBall2.transform.position = new Vector3(gap, 0.5f, areaHeight);
            }

            // random positive and negative rewards
            var pos = Random.Range(0, 2);
            var negative = Random.Range(-20, -5);
            var positive = Random.Range(1, 10);
            if (pos == 0)
            {
                newBall.GetComponent<Items>().setValue(negative);
                newBall2.GetComponent<Items>().setValue(positive);

            }
            else if (pos == 1)
            {
                newBall.GetComponent<Items>().setValue(positive);
                newBall2.GetComponent<Items>().setValue(negative);

            }

            // memorize the last item in order to use its position to create the next item
            lastItem = newBall;

        }
    }

    public static void addScore(long reward)
    {

        score += reward;

        if (score > maxScore)
        {
            maxScore = score;
        }

        instance.scoreGUI.GetComponent<TextMeshProUGUI>().text = "Score: " + score;

        if (score < 0)
        {
            SceneManager.LoadScene("GameOver");
        }

    }

    IEnumerator SpeedUp()
    {
        while (speed < 60)
        {
            speed += 0.2f;
            yield return new WaitForSeconds(.1f);
        }
    }

    IEnumerator countTime()
    {
        while (true)
        {
            duration += 1;
            durationGUI.GetComponent<TextMeshProUGUI>().text = "Duration: " + duration;

            yield return new WaitForSeconds(1);
        }
    }

}
