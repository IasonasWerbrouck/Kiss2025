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
        if (hudPlayer == null)
        {
            Debug.LogError("HUD_Player not found in the scene.");
        }
        else
        {
            hudPlayer.UpdateMunitionText(currentMunitions[hudPlayer.GetCurrentWeaponIndex()]);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            int currentWeaponIndex = hudPlayer?.GetCurrentWeaponIndex() ?? -1;
            if (currentWeaponIndex != -1)
            {
                ReloadMunition(currentWeaponIndex, maxMunitions[currentWeaponIndex]);
            }
        }
    }

    public bool UseMunition(int weaponIndex)
    {
        if (weaponIndex >= 0 && weaponIndex < currentMunitions.Length && currentMunitions[weaponIndex] > 0)
        {
            currentMunitions[weaponIndex]--;
            if (weaponIndex == hudPlayer?.GetCurrentWeaponIndex())
            {
                hudPlayer.UpdateMunitionText(currentMunitions[weaponIndex]);
            }
            return true;
        }
        return false;
    }

    public void ReloadMunition(int weaponIndex, int amount)
    {
        if (weaponIndex >= 0 && weaponIndex < maxMunitions.Length)
        {
            currentMunitions[weaponIndex] = Mathf.Min(currentMunitions[weaponIndex] + amount, maxMunitions[weaponIndex]);
            if (weaponIndex == hudPlayer?.GetCurrentWeaponIndex())
            {
                hudPlayer.UpdateMunitionText(currentMunitions[weaponIndex]);
            }
        }
    }

    public void ReloadAllMunitions()
    {
        for (int i = 0; i < maxMunitions.Length; i++)
        {
            currentMunitions[i] = maxMunitions[i];
        }
        if (hudPlayer != null)
        {
            hudPlayer.UpdateMunitionText(currentMunitions[hudPlayer.GetCurrentWeaponIndex()]);
        }
    }

    public int GetCurrentMunition(int weaponIndex)
    {
        if (weaponIndex >= 0 && weaponIndex < currentMunitions.Length){
            return currentMunitions[weaponIndex];
        }
        return 0;
    }
}
