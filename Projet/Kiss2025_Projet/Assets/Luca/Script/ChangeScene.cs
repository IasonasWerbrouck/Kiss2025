using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private AudioClip changeSceneSound;
    [SerializeField] private AudioClip quitGameSound;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component is missing.");
        }
    }

    public void OnChangeScene()
    {
        if (audioSource != null && changeSceneSound != null)
        {
            StartCoroutine(PlaySoundAndChangeScene(changeSceneSound, sceneName));
        }
        else
        {
            if (!string.IsNullOrEmpty(sceneName))
            {
                SceneManager.LoadScene(sceneName);
            }
            else
            {
                Debug.LogWarning("Scene name is not set.");
            }
        }
    }

    public void OnQuitGame()
    {
        if (audioSource != null && quitGameSound != null)
        {
            StartCoroutine(PlaySoundAndQuitGame(quitGameSound));
        }
        else
        {
            Application.Quit();
        }
    }

    private IEnumerator PlaySoundAndChangeScene(AudioClip clip, string scene)
    {
        audioSource.PlayOneShot(clip);
        yield return new WaitForSeconds(clip.length);
        SceneManager.LoadScene(scene);
    }

    private IEnumerator PlaySoundAndQuitGame(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
        yield return new WaitForSeconds(clip.length);
        Application.Quit();
    }
}
