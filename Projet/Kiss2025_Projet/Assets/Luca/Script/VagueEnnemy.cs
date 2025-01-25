using UnityEngine.SceneManagement;
using UnityEngine;

public class VagueEnnemy : MonoBehaviour
{
    [SerializeField] private int[] enemiesToEliminatePerWave;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform[] spawnPoints; // Changer en tableau de Transform
    [SerializeField] private float cineImageDisplayDuration = 3.0f; // Durée d'affichage de l'image

    private int enemiesRemaining, waveIndex;
    private HUD_Player hudPlayer;

    void Start()
    {
        waveIndex = 0;
        hudPlayer = FindObjectOfType<HUD_Player>();
        StartWave(waveIndex);
    }

    public int GetEnemiesToEliminateForWave(int waveIndex_p)
    {
        if (waveIndex_p < 0 || waveIndex_p >= enemiesToEliminatePerWave.Length)
        {
            return -1;
        }
        return enemiesToEliminatePerWave[waveIndex_p];
    }

    private void StartWave(int waveIndex_p)
    {
        if (hudPlayer != null)
        {
            hudPlayer.ShowCineImageForWave(waveIndex_p, cineImageDisplayDuration);
            Invoke(nameof(SpawnEnemiesForWave), cineImageDisplayDuration);
        }
        else
        {
            SpawnEnemiesForWave();
        }
    }

    private void SpawnEnemiesForWave()
    {
        enemiesRemaining = GetEnemiesToEliminateForWave(waveIndex);
        if (hudPlayer != null)
        {
            hudPlayer.UpdateWaveText(waveIndex + 1);
            hudPlayer.UpdateEnemiesRemainingText(enemiesRemaining);
        }
        if (enemiesRemaining > 0)
        {
            for (int i = 0; i < enemiesRemaining; i++)
            {
                Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)]; // Choisir un point de spawn aléatoire
                Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            }
        }
    }

    public void DecrementEnemiesRemaining()
    {
        if (enemiesRemaining > 0)
        {
            enemiesRemaining--;
            if (hudPlayer != null)
            {
                hudPlayer.UpdateEnemiesRemainingText(enemiesRemaining);
            }
            if (enemiesRemaining == 0)
            {
                print("Wave cleared!");
                NextWave();
            }
        }
    }

    private void NextWave()
    {
        waveIndex++;
        if (waveIndex < enemiesToEliminatePerWave.Length)
        {
            StartWave(waveIndex);
        }
        else
        {
            SceneManager.LoadScene("S_Win");
        }
    }
}
