using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCounter : MonoBehaviour
{
    GameObject Gm;
    // Start is called before the first frame update
    void Start()
    {
        Gm = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            Gm.GetComponent<GameManager>().AddScore();
        }
    }
}
