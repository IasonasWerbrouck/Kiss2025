using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUD_Player : MonoBehaviour
{
    public Image[] weaponImages;
    public TextMeshProUGUI munitionText; // Correction de l'orthographe et du type
    private int currentWeaponIndex = 0;

    void Start()
    {
        // Désactiver toutes les images au démarrage
        foreach (Image img in weaponImages)
        {
            img.enabled = false;
        }
        // Activer l'image de l'arme initiale
        UpdateWeapon(currentWeaponIndex);
    }

    public void UpdateWeapon(int weaponIndex)
    {
        if (weaponIndex >= 0 && weaponIndex < weaponImages.Length)
        {
            currentWeaponIndex = weaponIndex;
            for (int i = 0; i < weaponImages.Length; i++)
            {
                weaponImages[i].enabled = (i == weaponIndex);
            }
        }
    }

    public void UpdateMunitionText(int currentMunition)
    {
        if (munitionText != null)
        {
            if (currentMunition < 0)
            {
                munitionText.gameObject.SetActive(false);
            }
            else if (currentMunition == 0)
            {
                munitionText.gameObject.SetActive(false);
                SetWeaponImageAlpha(currentWeaponIndex, 65);
            }
            else
            {
                munitionText.gameObject.SetActive(true);
                munitionText.text = currentMunition.ToString();
                SetWeaponImageAlpha(currentWeaponIndex, 255);
            }
        }
    }

    private void SetWeaponImageAlpha(int weaponIndex, byte alpha)
    {
        if (weaponIndex >= 0 && weaponIndex < weaponImages.Length)
        {
            Color color = weaponImages[weaponIndex].color;
            color.a = alpha / 255f;
            weaponImages[weaponIndex].color = color;
        }
    }

    public int GetCurrentWeaponIndex()
    {
        return currentWeaponIndex;
    }
}

