using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeGestion : MonoBehaviour
{

    [SerializeField] public float LifeCurrent = 20.0f;
    [SerializeField] public float LifeMax = 20.0f; // Ajout de la vie maximale

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
            SceneManager.LoadScene("S_GameOver");
        }
    }

    public void TakeHealth(float health)
    {
        LifeCurrent += health;
        if (LifeCurrent > LifeMax)
        {
            LifeCurrent = LifeMax; // Limiter la vie à la vie maximale
        }
    }
}
