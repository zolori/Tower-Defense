using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;
using Slider = UnityEngine.UI.Slider;

public class HealthBar : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public Camera camera;
    

    private void Start()
    {
        
    }

    private void Update()
    {
        Vector3 direction = transform.position - camera.transform.position; // calcule la direction
        Quaternion lookRotation = Quaternion.LookRotation(direction); // calcule la rotation
        Vector3 rotation = Quaternion.Lerp(slider.transform.rotation, lookRotation, Time.deltaTime * 50).eulerAngles;
        slider.transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    public void SetMaxHealth(int prmMaxHealth)
    {
        slider.maxValue = prmMaxHealth;
        slider.value = prmMaxHealth;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int prmHealth)
    {
        slider.value = prmHealth;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
