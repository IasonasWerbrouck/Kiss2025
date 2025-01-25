using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUD_Player : MonoBehaviour
{
    public Image[] weaponImages;
    public TextMeshProUGUI munitionText, Nb_vague, Nb_ennemieRestant;
    public Slider lifeSlider;
    public Color highLifeColor = Color.green;
    public Color mediumLifeColor = Color.yellow;
    public Color lowLifeColor = Color.red;

    private int currentWeaponIndex = 0;
    private LifeGestion playerLifeGestion;

    public Image CineImage;
    public Sprite[] CineImages;

    void Start(){
        foreach (Image img in weaponImages){
            img.enabled = false;
        }
        UpdateWeapon(currentWeaponIndex);
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null){
            playerLifeGestion = player.GetComponent<LifeGestion>();
            if (playerLifeGestion != null){
                lifeSlider.maxValue = playerLifeGestion.LifeMax;
                lifeSlider.value = playerLifeGestion.LifeCurrent;
                UpdateLifeSliderColor();
            }
        }
        if (CineImage != null){
            CineImage.enabled = false;
        }
    }

    void Update(){
        if (playerLifeGestion != null){
            lifeSlider.maxValue = playerLifeGestion.LifeMax;
            lifeSlider.value = playerLifeGestion.LifeCurrent;
            UpdateLifeSliderColor();
        }
    }

    private void UpdateLifeSliderColor(){
        float lifePercentage = playerLifeGestion.LifeCurrent / playerLifeGestion.LifeMax;

        if (lifePercentage > 0.6f){
            lifeSlider.fillRect.GetComponent<Image>().color = highLifeColor;
        }else if (lifePercentage > 0.3f){
            lifeSlider.fillRect.GetComponent<Image>().color = mediumLifeColor;
        }else if (lifePercentage > 0.0f){
            lifeSlider.fillRect.GetComponent<Image>().color = lowLifeColor;
        }else{
            lifeSlider.gameObject.SetActive(false);
        }
    }

    public void UpdateWeapon(int weaponIndex){
        if (weaponIndex >= 0 && weaponIndex < weaponImages.Length){
            currentWeaponIndex = weaponIndex;
            for (int i = 0; i < weaponImages.Length; i++){
                weaponImages[i].enabled = (i == weaponIndex);
            }
        }
    }

    public void UpdateMunitionText(int currentMunition){
        if (munitionText != null){
            if (currentMunition < 0){
                munitionText.gameObject.SetActive(false);
            }else if (currentMunition == 0){
                munitionText.gameObject.SetActive(false);
                SetWeaponImageAlpha(currentWeaponIndex, 65);
            }else{
                munitionText.gameObject.SetActive(true);
                munitionText.text = currentMunition.ToString();
                SetWeaponImageAlpha(currentWeaponIndex, 255);
            }
        }
    }

    private void SetWeaponImageAlpha(int weaponIndex, byte alpha){
        if (weaponIndex >= 0 && weaponIndex < weaponImages.Length){
            Color color = weaponImages[weaponIndex].color;
            color.a = alpha / 255f;
            weaponImages[weaponIndex].color = color;
        }
    }

    public int GetCurrentWeaponIndex(){
        return currentWeaponIndex;
    }
    public void UpdateWaveText(int currentWave){
        if (Nb_vague != null){
            Nb_vague.text = "Vague: " + currentWave.ToString();
        }
    }

    public void UpdateEnemiesRemainingText(int enemiesRemaining){
        if (Nb_ennemieRestant != null){
            Nb_ennemieRestant.text = "Ennemis restants: " + enemiesRemaining.ToString();
        }
    }
    public void ShowCineImageForWave(int currentWave, float displayDuration)
    {
        if (currentWave >= 0 && currentWave < CineImages.Length)
        {
            StartCoroutine(DisplayCineImage(currentWave, displayDuration));
        }
    }

    private IEnumerator DisplayCineImage(int waveIndex, float duration)
    {
        if (CineImage != null)
        {
            CineImage.sprite = CineImages[waveIndex];
            CineImage.enabled = true;
            yield return new WaitForSeconds(duration);
            CineImage.enabled = false;
        }
    }

}

