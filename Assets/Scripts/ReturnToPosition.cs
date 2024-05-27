using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToPosition : MonoBehaviour
{
    public Transform targetObject; // Objeto cuja posi��o ser� usada como refer�ncia
    public float returnSpeed = 5f; // Velocidade de retorno do objeto

    private Vector3 originalPosition; // Posi��o original do objeto

    void Start()
    {
        originalPosition = transform.position; // Guarda a posi��o original do objeto
    }

    void OnCollisionEnter(Collision collision)
    {
        // Se o objeto colidir com o ch�o
        if (collision.gameObject.CompareTag("Ground"))
        {
            // Chama a fun��o para iniciar o movimento de retorno
            StartCoroutine(ReturnToObject());
        }
    }

    IEnumerator ReturnToObject()
    {
        float journeyLength = Vector3.Distance(transform.position, targetObject.position);
        float startTime = Time.time;

        while (true)
        {
            float distanceCovered = (Time.time - startTime) * returnSpeed;
            float fractionOfJourney = distanceCovered / journeyLength;
            transform.position = Vector3.Lerp(transform.position, targetObject.position, fractionOfJourney);

            if (fractionOfJourney >= 1f)
            {
                break;
            }

            yield return null;
        }
    }
}
