using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Items : MonoBehaviour
{

    public int reward;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(0, 0, -1);
        gameObject.transform.Translate(movement * Time.deltaTime * GameManager.speed);

        if (gameObject.transform.position.z < -GameManager.areaHeight)
        {
            PoolManager.Instance.spawnPool.Release(gameObject);
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "ItemExitDetector")
        {
            PoolManager.Instance.spawnPool.Release(gameObject);
        }
        if (other.gameObject.name == "player")
        {
            GameManager.addScore(reward);

            PoolManager.Instance.spawnPool.Release(gameObject);
        }
    }

    public void setValue(int value)
    {

        var text = gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
        if (text != null)
        {
            text.GetComponent<TextMeshProUGUI>().text = "" + value;

            gameObject.GetComponent<Renderer>().material.color = value > 0 ? Color.blue : Color.red;

            reward = value;
        }

    }



}
