using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp_Munition : MonoBehaviour
{
    [SerializeField] private int munitionAmount = 10;
    [SerializeField] private int weaponIndex = 0; // Index de l'arme à recharger

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MunitionPlayer munitionPlayer = other.GetComponent<MunitionPlayer>();
            if (munitionPlayer != null)
            {
                munitionPlayer.ReloadMunition(weaponIndex, munitionAmount);
                Destroy(gameObject); // Détruire l'objet de munitions après utilisation
            }
        }
    }
}
