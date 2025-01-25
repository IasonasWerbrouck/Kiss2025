using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeGestion : MonoBehaviour
{
    [SerializeField] public float LifeCurrent = 20.0f;
    [SerializeField] public float LifeMax = 20.0f; // Ajout de la vie maximale
    [SerializeField] private bool isPlayer = false; // Ajout d'une variable pour v�rifier si c'est le joueur

    // Update is called once per frame
    void Update()
    {
        //DEBUG TEST DEGATS ET SOINS
        if (Input.GetKeyDown(KeyCode.V))
        {
            TakeDamage(1);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            TakeHealth(1);
        }
    }

    public void TakeDamage(float damage)
    {
        LifeCurrent -= damage;
        print(" DEGATS : Life: " + LifeCurrent);
        if (LifeCurrent <= 0)
        {
            Destroy(gameObject);
            if (isPlayer)
            {
                SceneManager.LoadScene("S_GameOver");
            }
            else if (gameObject.tag == "Ennemy")
            {
                VagueEnnemy vagueEnnemy = GameObject.Find("GameManager").GetComponent<VagueEnnemy>();
                vagueEnnemy.DecrementEnemiesRemaining();
            }
        }
    }

    public void TakeHealth(float health)
    {
        LifeCurrent += health;
        if (LifeCurrent > LifeMax)
        {
            LifeCurrent = LifeMax; // Limiter la vie � la vie maximale
        }
    }
}
