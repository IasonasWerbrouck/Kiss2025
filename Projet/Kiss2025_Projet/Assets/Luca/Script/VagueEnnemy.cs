using UnityEngine.SceneManagement;
using UnityEngine;

public class VagueEnnemy : MonoBehaviour
{
    [SerializeField] private int[] enemiesToEliminatePerWave;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform spawnPoint;

    private int enemiesRemaining, waveIndex;
    private HUD_Player hudPlayer;

    void Start(){
        waveIndex = 0;
        hudPlayer = FindObjectOfType<HUD_Player>();
        SpawnEnemiesForWave(waveIndex);
    }

    public int GetEnemiesToEliminateForWave(int waveIndex_p){
        if (waveIndex_p < 0 || waveIndex_p >= enemiesToEliminatePerWave.Length){
            return -1;
        }
        return enemiesToEliminatePerWave[waveIndex_p];
    }

    private void SpawnEnemiesForWave(int waveIndex_p){
        enemiesRemaining = GetEnemiesToEliminateForWave(waveIndex_p);
        if (hudPlayer != null){
            hudPlayer.UpdateWaveText(waveIndex_p + 1);
            hudPlayer.UpdateEnemiesRemainingText(enemiesRemaining);
        }
        if (enemiesRemaining > 0){
            for (int i = 0; i < enemiesRemaining; i++){
                Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            }
        }
    }

    public void DecrementEnemiesRemaining(){
        if (enemiesRemaining > 0){
            enemiesRemaining--;
            if (hudPlayer != null){
                hudPlayer.UpdateEnemiesRemainingText(enemiesRemaining);
            }
            if (enemiesRemaining == 0){
                print("Wave cleared!");
                NextWave();
            }
        }
    }

    private void NextWave(){
        waveIndex++;
        if (waveIndex < enemiesToEliminatePerWave.Length){
            SpawnEnemiesForWave(waveIndex);
        }else{
            SceneManager.LoadScene("S_Win");
        }
    }
}
