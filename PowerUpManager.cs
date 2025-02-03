using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class PowerUpManager : MonoBehaviour
{
    public GameObject powerUp;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreatePowerup());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CreatePowerup()
    {
        Instantiate(powerUp, new Vector3(Random.Range(-9f, 9f), 7.5f, 0), Quaternion.identity);
        yield return new WaitForSeconds(Random.Range(3f, 6f));
        StartCoroutine(CreatePowerup());
    }
}
