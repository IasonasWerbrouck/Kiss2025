using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Sword : MonoBehaviour{
    [SerializeField] public float damage = 1.0f;
    [SerializeField] public float attackRate = 1.0f;
    [SerializeField] public float animationDuration = 0.5f;
    [SerializeField] public float animationDistance = 1.0f;

    private Vector3 initialPosition;
    private Quaternion initialRotation;

    public void Start(){
        print("SWORD SPAWN");
        initialPosition = transform.localPosition;
        initialRotation = transform.localRotation;
        StartCoroutine(AnimateSword());
    }

    private IEnumerator AnimateSword(){
        float elapsedTime = 0f;
        while (elapsedTime < animationDuration){
            elapsedTime += Time.deltaTime;
            float progress = elapsedTime / animationDuration;

            if (initialRotation.eulerAngles.y == 90 || initialRotation.eulerAngles.y == -90){
                transform.localPosition = initialPosition + new Vector3(Mathf.Sin(progress * Mathf.PI) * animationDistance, 0, 0);
            }else{
                transform.localPosition = initialPosition + new Vector3(0, 0, Mathf.Sin(progress * Mathf.PI) * animationDistance);
            }

            yield return null;
        }

        transform.localPosition = initialPosition;
        transform.localRotation = initialRotation;
        Destroy(gameObject);
    }

    public void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "Enemy"){
            LifeGestion lifeGestion = other.gameObject.GetComponent<LifeGestion>();
            if (lifeGestion != null){
                lifeGestion.TakeDamage(damage);
                print("ON A TOUCHER  l'ENNEMY");
            }
        }
    }
}
