using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretButton : MonoBehaviour
{
    public Camera _camera;
    public Turret _turret;
    public Canvas _canvas;

    
    
    public void SpawnTurret()
    {
        if (EndBehaviour.BuyTurret())
        {
            Instantiate(_turret, transform.position, transform.rotation);
            _canvas.enabled = false;
        };
        
    }
}
