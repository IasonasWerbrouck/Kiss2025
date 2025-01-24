using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeGestion : MonoBehaviour{

    [SerializeField] public float Life = 20.0f;

    // Update is called once per frame
    void Update(){
        //DEBUG TEST DEGATS ET SOINS
        if (Input.GetKeyDown(KeyCode.V)){
            TakeDamage(1);
        }
        if (Input.GetKeyDown(KeyCode.C)){
            TakeHealth(1);
        }
    }


    public void TakeDamage(float damage){
        Life -= damage;
        print(" DEGATS : Life: " + Life);
        if (Life <= 0){
            Destroy(gameObject);
        }
    }
    public void TakeHealth(float Health){
        Life += Health;
        print("SOIN : Life: " + Life);
    }
}
