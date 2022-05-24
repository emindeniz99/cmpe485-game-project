using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Items : MonoBehaviour


{


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(0, 0, -1);
        gameObject.transform.Translate(movement * Time.deltaTime * GameManager.speed);


    }




    void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
        Debug.Log(other.gameObject.name);
        if (other.gameObject.name == "ItemExitDetector")
        {
            PoolManager.Instance.spawnPool.Release(gameObject);
        }
    }

}
