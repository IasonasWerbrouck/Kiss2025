using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour{
    public GameObject prefabToSword; // Ajoutez cette ligne pour déclarer le prefab

    void Update(){
        //DEBUG TEST DEGATS ET SOINS
        if (Input.GetKeyDown(KeyCode.B)){
            print("ON ATTAQUE l'ENNEMY a L'EPEE");
            GameObject spawnedObject = Instantiate(prefabToSword, transform.position, transform.rotation);
            spawnedObject.transform.SetParent(transform); // Attacher le prefab au GameObject parent
        }
    }
}
