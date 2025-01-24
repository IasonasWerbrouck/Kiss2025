using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MunitionPlayer : MonoBehaviour
{
    public int[] maxMunitions;
    private int[] currentMunitions;
    private HUD_Player hudPlayer;

    void Start()
    {
        currentMunitions = new int[maxMunitions.Length];
        for (int i = 0; i < maxMunitions.Length; i++)
        {
            currentMunitions[i] = maxMunitions[i];
        }
        hudPlayer = FindObjectOfType<HUD_Player>();
    }

    public bool UseMunition(int weaponIndex)
    {
        if (weaponIndex >= 0 && weaponIndex < currentMunitions.Length && currentMunitions[weaponIndex] > 0)
        {
            currentMunitions[weaponIndex]--;
            hudPlayer.UpdateMunitionText(currentMunitions[weaponIndex]);
            return true;
        }
        return false;
    }

    public void ReloadMunition(int weaponIndex)
    {
        if (weaponIndex >= 0 && weaponIndex < maxMunitions.Length)
        {
            currentMunitions[weaponIndex] = maxMunitions[weaponIndex];
            hudPlayer.UpdateMunitionText(currentMunitions[weaponIndex]);
        }
    }

    public void ReloadAllMunitions()
    {
        for (int i = 0; i < maxMunitions.Length; i++)
        {
            currentMunitions[i] = maxMunitions[i];
        }
        hudPlayer.UpdateMunitionText(currentMunitions[hudPlayer.GetCurrentWeaponIndex()]);
    }

    public int GetCurrentMunition(int weaponIndex)
    {
        if (weaponIndex >= 0 && weaponIndex < currentMunitions.Length)
        {
            return currentMunitions[weaponIndex];
        }
        return 0;
    }
}

