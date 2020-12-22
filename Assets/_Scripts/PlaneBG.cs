using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneBG : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            StartCoroutine(destroyPlaneBG(this.gameObject));
        }
    }

    private IEnumerator destroyPlaneBG(GameObject plane)
    {
        yield return new WaitForSeconds(2f);
        Destroy(plane);
    }
}
