using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tourelle : MonoBehaviour
{
    [SerializeField] private float timeLife;
    [SerializeField] private GameObject weaponPrefab;
    [SerializeField] private float fireRate = 1f; // Intervalle de tir en secondes
    [SerializeField] private float detectionRadius = 10f; // Rayon de détection des ennemis
    [SerializeField] private AudioClip fireSound; // Assignez le fichier audio du tir dans l'inspecteur

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Destroy(gameObject, timeLife);
        StartCoroutine(FireRoutine());
    }

    private IEnumerator FireRoutine()
    {
        while (true)
        {
            ThrowSardinne();
            yield return new WaitForSeconds(fireRate);
        }
    }

    public void ThrowSardinne()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectionRadius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Ennemy"))
            {
                Vector3 direction = (hitCollider.transform.position - transform.position).normalized;
                GameObject sardinne = Instantiate(weaponPrefab, transform.position, Quaternion.identity);
                StartCoroutine(MoveSardinne(sardinne, direction));
                PlayFireSound();
                break; // Attaque un ennemi à la fois
            }
        }
    }

    private IEnumerator MoveSardinne(GameObject sardinne, Vector3 direction)
    {
        Sardinnne sardinneScript = sardinne.GetComponent<Sardinnne>();
        float speed = sardinneScript != null ? sardinneScript.speed : 5f;
        float fixedY = sardinne.transform.position.y;

        while (sardinne != null)
        {
            Vector3 newPosition = sardinne.transform.position + direction * speed * Time.deltaTime;
            newPosition.y = fixedY; // Fixer la position Y
            sardinne.transform.position = newPosition;
            yield return null;
        }
    }

    private void PlayFireSound()
    {
        if (fireSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(fireSound);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);

        // Dessiner un cube pour visualiser la zone de détection
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, new Vector3(detectionRadius * 2, detectionRadius * 2, detectionRadius * 2));
    }
}
