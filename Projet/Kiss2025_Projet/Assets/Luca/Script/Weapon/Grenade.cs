using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField]   public float damage, TimeBeforeBOOM, speed = 10f, height = 5f;

    public void Boom(){
        StartCoroutine(ExplodeAfterDelay());
    }

    private IEnumerator ExplodeAfterDelay(){
        yield return new WaitForSeconds(TimeBeforeBOOM);

        Collider[] hitColliders = Physics.OverlapBox(transform.position, GetComponent<BoxCollider>().size / 2);
        foreach (var hitCollider in hitColliders){
            if (hitCollider.CompareTag("Ennemy")){
                LifeGestion lifeGestion = hitCollider.GetComponent<LifeGestion>();
                if (lifeGestion != null){
                    lifeGestion.TakeDamage(damage);
                }
            }
        }
        print("BOOM");
        Destroy(gameObject);
    }
}
