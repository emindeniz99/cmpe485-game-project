using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    public static float speed = 15;

    public static float areaWidth;

    public static float areaHeight;

    public static float positionScaleRatio = 10;

    public GameObject ground;

    // Start is called before the first frame update
    void Start()
    {
        areaWidth = ground.transform.localScale.x * positionScaleRatio;
        areaHeight = ground.transform.localScale.z * positionScaleRatio;

        ground.transform.localScale = new Vector3(ground.transform.localScale.x,
            ground.transform.localScale.y,
            ground.transform.localScale.z * 2);
    }

    Vector3 GetRandomPositionAtNextGround()
    {
        return new Vector3(Random.Range(-areaWidth, areaWidth), 1, Random.Range(areaHeight, areaHeight * 2));
    }



    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Space))
        {

            if (PoolManager.Instance.isPoolingEnabled)
            {
                if (!PoolManager.Instance.CanGet()) return;
                var newBall = PoolManager.Instance.GetFromPool();
                newBall.transform.position = GetRandomPositionAtNextGround();
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
}
