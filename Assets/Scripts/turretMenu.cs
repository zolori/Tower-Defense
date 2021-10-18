using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretMenu : MonoBehaviour
{
    
    public Turret Turret;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Turret.UpgradeMenu(Turret);
    }
}
