using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour{
    [SerializeField] public float speed = 20.0f;

    void Update(){
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.Translate(movement * speed * Time.deltaTime, Space.World);

        if (Input.GetKey(KeyCode.Z)){
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S)){
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Q)){
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D)){
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }
}
