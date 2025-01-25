using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySword : MonoBehaviour
{
    [SerializeField] public float damage ;
    void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")){
            LifeGestion lifeGestion = other.GetComponent<LifeGestion>();
            if (lifeGestion != null){
                lifeGestion.TakeDamage(damage);
            }
        }
    }
}
