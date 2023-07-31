using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SetShield : MonoBehaviour
{
    [Header("Escudo protector del arco y flecha")]
    [SerializeField]
    [Tooltip("Escudo que proteje el arco y flecha")]
    GameObject escudo;

    [SerializeField]
    [Tooltip("Escudo que proteje el oraculo")]
    GameObject escudoOraculo;
    public float immobilizeDuration = 2.0f;
    private Coroutine immobilizeCoroutine;

    private void OnTriggerEnter(Collider other)
    {
        Invoke("ActiveTrue", 5f);
        Invoke("ActiveFalse", 1f);
        Invoke("DestroyOracleShield", 1f);
        Invoke("DestroyOracleShieldFalse", 10f);
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

    private void ActiveTrue()
    {
        escudo.SetActive(true);
    }

    private void DestroyOracleShield()
    {
        escudoOraculo.SetActive(false);
    }

    private void DestroyOracleShieldFalse()
    {
        escudoOraculo.SetActive(true);
    }

    private void ActiveFalse()
    {
        escudo.SetActive(false);
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
