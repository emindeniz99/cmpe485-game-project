using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject scoreGUI;

    public static long score = 0;

    public static float speed = 15;

    public static float areaWidth;

    public static float areaHeight;

    public static float positionScaleRatio = 1;

    public GameObject ground;


    public static GameObject lastItem;
    // Start is called before the first frame update
    void Start()
    {

        score = 0;
        speed = 15;
        areaWidth = ground.transform.localScale.x * positionScaleRatio;
        areaHeight = ground.transform.localScale.z * positionScaleRatio;

        ground.transform.localScale = new Vector3(ground.transform.localScale.x,
            ground.transform.localScale.y,
            ground.transform.localScale.z * 2);

        StartCoroutine(SpeedUp());
    }





    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Space))
        {

            if (PoolManager.Instance.isPoolingEnabled)
            {
                if (!PoolManager.Instance.CanGet(2)) return;

                // left
                var newBall = PoolManager.Instance.GetFromPool();
                var newBall2 = PoolManager.Instance.GetFromPool();

                var gap = 1.5f;
                if (lastItem != null)
                {
                    newBall.transform.position = lastItem.transform.position + new Vector3(0, 0, 10);
                    newBall2.transform.position = lastItem.transform.position + new Vector3(gap * 2, 0, 10);
                }
                else
                {
                    newBall.transform.position = new Vector3(-gap, 0.5f, areaHeight);
                    newBall2.transform.position = new Vector3(gap, 0.5f, areaHeight);
                }

                var pos = Random.Range(0, 2);
                if (pos == 0)
                {
                    newBall.GetComponent<Items>().setValue(Random.Range(-20, -5));
                    newBall2.GetComponent<Items>().setValue(Random.Range(1, 10));

                }
                else
                if (pos == 1)
                {
                    newBall.GetComponent<Items>().setValue(Random.Range(1, 10));
                    newBall2.GetComponent<Items>().setValue(Random.Range(-20, -5));

                }

                lastItem = newBall;

            }
            // else
            // {
            //     var newBall = Instantiate(PoolManager.Instance.Prefab, spawnPoint.position, Quaternion.identity);
            //     Rigidbody ballBody = newBall.GetComponent<Rigidbody>();
            //     if (ballBody != null)
            //     {
            //         ballBody.velocity = Vector3.zero;
            //         ballBody.angularVelocity = Vector3.zero;
            //         ballBody.AddForce((spawnPoint.position - basePoint.position) * 300f);
            //     }
            // }

        }
    }


    void FixedUpdate()
    {

        scoreGUI.GetComponent<TextMeshProUGUI>().text = "Score: " + score;

        if (score < 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }


    IEnumerator SpeedUp()
    {
        while (speed < 60)
        {
            speed += 0.1f;
            yield return new WaitForSeconds(.1f);
        }
    }

}
