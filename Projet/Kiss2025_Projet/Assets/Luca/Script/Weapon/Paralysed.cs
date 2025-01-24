using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralysed : MonoBehaviour
{
    [SerializeField]
    public float TimeLife;
    public float damage;
    public float speed;
    void Start()
    {
        Destroy(gameObject, TimeLife);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ennemy"))
        {
            print("Paralysed");
        }
    }
}
