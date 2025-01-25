using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUD_Player : MonoBehaviour
{
    public Image[] weaponImages;
    public TextMeshProUGUI munitionText, Nb_vague, Nb_ennemieRestant;
    public Slider lifeSlider; // Ajout de la référence au slider
    public Color highLifeColor = Color.green; // Couleur pour > 60%
    public Color mediumLifeColor = Color.yellow; // Couleur pour 30% - 60%
    public Color lowLifeColor = Color.red; // Couleur pour < 30%

    private int currentWeaponIndex = 0;
    private LifeGestion playerLifeGestion; // Référence au script LifeGestion

    void Start()
    {
        // Désactiver toutes les images au démarrage
        foreach (Image img in weaponImages)
        {
            img.enabled = false;
        }
        // Activer l'image de l'arme initiale
        UpdateWeapon(currentWeaponIndex);

        // Récupérer le script LifeGestion du joueur
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerLifeGestion = player.GetComponent<LifeGestion>();
            if (playerLifeGestion != null)
            {
                // Initialiser le slider avec la valeur de vie actuelle et maximale
                lifeSlider.maxValue = playerLifeGestion.LifeMax;
                lifeSlider.value = playerLifeGestion.LifeCurrent;
                UpdateLifeSliderColor();
            }
        }
    }

    void Update()
    {
        if (playerLifeGestion != null)
        {
            // Mettre à jour la valeur et la valeur maximale du slider en fonction de la vie du joueur
            lifeSlider.maxValue = playerLifeGestion.LifeMax;
            lifeSlider.value = playerLifeGestion.LifeCurrent;
            UpdateLifeSliderColor();
        }
    }

    private void UpdateLifeSliderColor()
    {
        float lifePercentage = playerLifeGestion.LifeCurrent / playerLifeGestion.LifeMax;

        if (lifePercentage > 0.6f)
        {
            lifeSlider.fillRect.GetComponent<Image>().color = highLifeColor;
        }
        else if (lifePercentage > 0.3f)
        {
            lifeSlider.fillRect.GetComponent<Image>().color = mediumLifeColor;
        }
        else if (lifePercentage > 0.0f)
        {
            lifeSlider.fillRect.GetComponent<Image>().color = lowLifeColor;
        }
        else
        {
            lifeSlider.gameObject.SetActive(false);
        }
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
    // Méthode pour mettre à jour le texte du nombre de vagues
    public void UpdateWaveText(int currentWave)
    {
        if (Nb_vague != null)
        {
            Nb_vague.text = "Vague: " + currentWave.ToString();
        }
    }

    // Méthode pour mettre à jour le texte du nombre d'ennemis restants
    public void UpdateEnemiesRemainingText(int enemiesRemaining)
    {
        if (Nb_ennemieRestant != null)
        {
            Nb_ennemieRestant.text = "Ennemis restants: " + enemiesRemaining.ToString();
        }
    }
}

