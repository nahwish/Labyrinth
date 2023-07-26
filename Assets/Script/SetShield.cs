using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SetShield : MonoBehaviour
{
    public float immobilizeDuration = 2.0f;
    private Coroutine immobilizeCoroutine;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Duck"))
        {
            NavMeshAgent enemyNavAgent = other.GetComponent<NavMeshAgent>();
            if (enemyNavAgent != null && enemyNavAgent.enabled)
            {
                if (immobilizeCoroutine != null)
                {
                    StopCoroutine(immobilizeCoroutine);
                }

                enemyNavAgent.isStopped = true;
                enemyNavAgent.velocity = Vector3.zero; // Para asegurarnos de que no haya movimiento residual

                immobilizeCoroutine = StartCoroutine(ImmobilizeEnemy(enemyNavAgent));
            }
        }
    }

    private IEnumerator ImmobilizeEnemy(NavMeshAgent enemyNavAgent)
    {
        yield return new WaitForSeconds(immobilizeDuration);

        enemyNavAgent.isStopped = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Duck"))
        {
            NavMeshAgent enemyNavAgent = other.GetComponent<NavMeshAgent>();
            if (enemyNavAgent != null)
            {
                enemyNavAgent.isStopped = false;
                if (immobilizeCoroutine != null)
                {
                    StopCoroutine(immobilizeCoroutine);
                }
            }
        }
    }
}
