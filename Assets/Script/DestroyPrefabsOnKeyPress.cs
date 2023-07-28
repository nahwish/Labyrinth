using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPrefabsOnKeyPress : MonoBehaviour
{
    public ProgressBarCircle Pb;
    public GameObject[] prefabsToDestroy; // Los prefabs que se destruirán.
    public GameObject explosionPrefab; // Prefab de la explosión
    public float pressDurationThreshold = 10f; // Duración (en segundos) para mantener presionada la tecla "B".
    private bool isDestroying = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (!isDestroying)
            {
                StartCoroutine(DestroyPrefabsAfterDelay());
            }
        }
        else
        {
            isDestroying = false;
            StopCoroutine(DestroyPrefabsAfterDelay());
        }
    }

    

    private IEnumerator DestroyPrefabsAfterDelay()
{
    isDestroying = true;
    float elapsedTime = 0f;
    float startValue = Pb.BarValue;
    float targetValue = Pb.BarValue + 10f;

    while (elapsedTime < pressDurationThreshold)
    {
        elapsedTime += Time.deltaTime;
        var barValue = Mathf.Lerp(startValue, targetValue, elapsedTime / pressDurationThreshold);
        Pb.BarValue = Mathf.RoundToInt(barValue * 10);
        yield return null;
    }

    Pb.BarValue = targetValue;

    foreach (GameObject prefab in prefabsToDestroy)
    {
        if(prefab != null){
        Destroy(prefab);
        Instantiate(explosionPrefab, prefab.transform.position, prefab.transform.rotation);
        }
        // Instanciar la explosión en la posición del objeto destruido
    }

    isDestroying = false;
}

}
