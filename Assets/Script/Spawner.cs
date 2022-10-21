using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject obstacle;
    //public float maxTimer;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = Random.Range(1f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            Instantiate(obstacle);
            timer = Random.Range(1f, 3f);
        } 
    }
}
