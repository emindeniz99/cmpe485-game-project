using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour


{

    public float speed = 5;

    private Vector2 start;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(x, 0, z);

        transform.Translate(movement * Time.deltaTime * speed);




        foreach (var touch in Input.touches)
        {

            transform.Translate(new Vector3(touch.deltaPosition.x, 0, touch.deltaPosition.y) * touch.deltaTime / 2);

            //     if(touch.phase == TouchPhase.Began)
            //     {
            //         start= touch.position;

            //     }else if(touch.phase== TouchPhase.Ended){


            // Vector3 movement = new Vector3(x, 0, z);

            // transform.Translate(movement * Time.deltaTime * speed);




            //         start = Vector2.zero;
            //     }
        }

        gameObject.transform.position = new Vector3(Mathf.Clamp(gameObject.transform.position.x, -2, 2), gameObject.transform.position.y, Mathf.Clamp(gameObject.transform.position.z, -0, 0));

    }



}
