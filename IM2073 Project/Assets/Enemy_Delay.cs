using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Delay : MonoBehaviour
{

    public int seconds;
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Coroutine());
        
    }

    IEnumerator Coroutine()
    {
        yield return new WaitForSeconds(seconds);
        enemy.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
