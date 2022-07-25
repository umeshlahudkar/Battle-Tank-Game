using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dstroy : MonoBehaviour
{
    public GameObject object1;
    public GameObject object2;
    public GameObject object3;
    public GameObject object4;
    public GameObject object5;
    public GameObject object6;
    public GameObject object7;

    private void Update()
    {
        if(TankService.Instance.isGameOver)
        {
            StartCoroutine(DestroyObject());
        }
    }
    public IEnumerator DestroyObject()
    {
        yield return StartCoroutine(DestroyObject1());
        yield return StartCoroutine(DestroyObject2());
        yield return StartCoroutine(DestroyObject3());
        yield return StartCoroutine(DestroyObject4());
        yield return StartCoroutine(DestroyObject5());
        yield return StartCoroutine(DestroyObject6());
        yield return StartCoroutine(DestroyObject7());
    }

    public IEnumerator DestroyObject1()
    {
        yield return new WaitForSeconds(1);
        Destroy(object1);

    }

    public IEnumerator DestroyObject2()
    {
        yield return new WaitForSeconds(1);
        Destroy(object2);

    }

    public IEnumerator DestroyObject3()
    {
        yield return new WaitForSeconds(1);
        Destroy(object3);

    }

    public IEnumerator DestroyObject4()
    {
        yield return new WaitForSeconds(1);
        Destroy(object4);

    }

    public IEnumerator DestroyObject5()
    {
        yield return new WaitForSeconds(1);
        Destroy(object5);

    }

    public IEnumerator DestroyObject6()
    {
        yield return new WaitForSeconds(1);
        Destroy(object6);

    }

    public IEnumerator DestroyObject7()
    {
        yield return new WaitForSeconds(1);
        Destroy(object7);

    }
}
