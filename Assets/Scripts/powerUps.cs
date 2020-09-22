using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUps : MonoBehaviour
{
    public bool healthPoints;
    public bool safeMode;

    private powerUpManager thepowerupManager;

    public float powerupTime;
    // Start is called before the first frame update
    void Start()
    {
        thepowerupManager = FindObjectOfType<powerUpManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
       
        if (other.name == "Player")
        {
           
            thepowerupManager.ActivatePowerUp(healthPoints, safeMode, powerupTime);

        }
        gameObject.SetActive(false);
    }
}
