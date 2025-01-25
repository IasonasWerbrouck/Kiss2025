using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeGestion : MonoBehaviour
{
    [SerializeField] public float LifeCurrent = 20.0f;
    [SerializeField] public float LifeMax = 20.0f;
    [SerializeField] private bool isPlayer = false;

    public void TakeDamage(float damage){
        LifeCurrent -= damage;
        print(" DEGATS : Life: " + LifeCurrent);
        if (LifeCurrent <= 0){
            Destroy(gameObject);
            if (isPlayer){
                SceneManager.LoadScene("S_GameOver");
            }else if (gameObject.tag == "Ennemy"){
                VagueEnnemy vagueEnnemy = GameObject.Find("GameManager").GetComponent<VagueEnnemy>();
                vagueEnnemy.DecrementEnemiesRemaining();
            }
        }
    }

    public void TakeHealth(float health){
        LifeCurrent += health;
        if (LifeCurrent > LifeMax){
            LifeCurrent = LifeMax;
        }
    }
}
