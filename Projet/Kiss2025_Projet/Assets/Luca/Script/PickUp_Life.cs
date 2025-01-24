using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp_Life : MonoBehaviour{
    [SerializeField] private float healthAmount = 10.0f;

    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")){
            LifeGestion lifeGestion = other.GetComponent<LifeGestion>();
            if (lifeGestion != null){
                lifeGestion.TakeHealth(healthAmount);
                Destroy(gameObject); // Détruire l'objet de soin après utilisation
            }
        }
    }
}
