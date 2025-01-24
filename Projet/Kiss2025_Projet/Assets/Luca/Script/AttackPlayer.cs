using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    public GameObject[] weaponPrefabs; // Tableau des prefabs d'armes
    private Move moveScript;
    private int currentAttackIndex = 0;

    void Start()
    {
        moveScript = GetComponent<Move>();
        ChangeWeapon(0); // Initialiser avec la première arme du tableau
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PerformAttack();
        }
        SwitchWeapon();
    }

    void SwitchWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) ChangeWeapon(0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) ChangeWeapon(1);
        if (Input.GetKeyDown(KeyCode.Alpha3)) ChangeWeapon(2);
        if (Input.GetKeyDown(KeyCode.Alpha4)) ChangeWeapon(3);
        if (Input.GetKeyDown(KeyCode.Alpha5)) ChangeWeapon(4);

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0)
        {
            if (scroll > 0)
            {
                currentAttackIndex = (currentAttackIndex + 1) % weaponPrefabs.Length;
            }
            else
            {
                currentAttackIndex = (currentAttackIndex - 1 + weaponPrefabs.Length) % weaponPrefabs.Length;
            }
        }
    }

    void ChangeWeapon(int index)
    {
        if (index >= 0 && index < weaponPrefabs.Length)
        {
            currentAttackIndex = index;
        }
    }

    void PerformAttack()
    {
        Debug.Log("Attaque de " + weaponPrefabs[currentAttackIndex].name);
        if (weaponPrefabs[currentAttackIndex].name == "Sardinnne")
        {
            ThrowSardinne();
        }
        if (weaponPrefabs[currentAttackIndex].name == "Grenade")
        {
            ThrowGrenade();
        }

        // Ajoutez ici la logique pour d'autres armes si nécessaire
    }

    //ATTAQUE DU LANCER DE POISSON, Dague//
    public void ThrowSardinne()
    {
        Vector3 mousePosition = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            GameObject sardinne = Instantiate(weaponPrefabs[currentAttackIndex], transform.position, Quaternion.identity);
            Vector3 direction = (hit.point - transform.position).normalized;
            StartCoroutine(MoveSardinne(sardinne, direction));
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

    //ATTAQUE DU LANCER DE GRENADE//
    public void ThrowGrenade()
    {
        Vector3 mousePosition = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 targetPosition = new Vector3(hit.point.x, 0.2f, hit.point.z);
            GameObject grenade = Instantiate(weaponPrefabs[currentAttackIndex], transform.position, Quaternion.identity);
            StartCoroutine(MoveGrenade(grenade, targetPosition));
        }
    }

    private IEnumerator MoveGrenade(GameObject grenade, Vector3 targetPosition)
    {
        Grenade grenadeScript = grenade.GetComponent<Grenade>();
        float speed = grenadeScript != null ? grenadeScript.speed : 10f;
        float height = grenadeScript != null ? grenadeScript.height : 5f;
        Vector3 startPosition = grenade.transform.position;
        float journeyLength = Vector3.Distance(startPosition, targetPosition);
        float startTime = Time.time;

        while (grenade != null && Vector3.Distance(grenade.transform.position, targetPosition) > 0.1f)
        {
            float distCovered = (Time.time - startTime) * speed;
            float fractionOfJourney = distCovered / journeyLength;
            Vector3 currentPosition = Vector3.Lerp(startPosition, targetPosition, fractionOfJourney);
            currentPosition.y += height * Mathf.Sin(Mathf.PI * fractionOfJourney);

            grenade.transform.position = currentPosition;
            yield return null;
        }

        if (grenadeScript != null){
            grenadeScript.Boom();
        }
    }
}
