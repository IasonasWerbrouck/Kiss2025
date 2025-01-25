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
                int currentMunition = munitionPlayer.GetCurrentMunition(weaponIndex);
                int maxMunition = munitionPlayer.maxMunitions[weaponIndex];
                int amountToReload = Mathf.Min(munitionAmount, maxMunition - currentMunition);

                if (amountToReload > 0)
                {
                    munitionPlayer.ReloadMunition(weaponIndex, amountToReload);
                    Destroy(gameObject); // Détruire le pickup après utilisation
                }
            }
        }
    }
}
