using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuSettings : MonoBehaviour
{
    public MeshRenderer bullet;
    public Slider redSlider, greenSlider, blueSlider;

    public Slider sizeSlider;

    public Slider bulletPerTapSlider;
    public TextMeshProUGUI bulletPerTapValueText;

    public Slider magazineSlider;
    public TextMeshProUGUI magazineValueText;

    public Slider bulletSpreadSlider;
    public TextMeshProUGUI spreadValueText;

    public Toggle explosiveToggle;

    public static bool isGamePaused = false;


    public GameObject pauseMenu, mainUi;

    public GameObject player;
    private Gun gun;

    private void Start()
    {
        gun = player.GetComponentInChildren<Gun>();
    }
    public void BulletColorChange()
    {
        Color color = bullet.sharedMaterial.color;
        color.r = redSlider.value;
        color.g = greenSlider.value;
        color.b = blueSlider.value;
        bullet.sharedMaterial.color = color;
        bullet.sharedMaterial.SetColor("_EmissionColor", color);
    }

    public void BulletSizeChange()
    {
        Vector3 size = bullet.transform.localScale;
        size.x = sizeSlider.value;
        size.y = sizeSlider.value;
        size.z = sizeSlider.value;
        bullet.transform.localScale = size;
    }
    public void BulletPerTapChange()
    {
        gun.bulletsPerTap = (int)bulletPerTapSlider.value;
        bulletPerTapValueText.text = bulletPerTapSlider.value.ToString();
    }
    public void MagazineChange()
    {
        gun.magazineSize = (int)magazineSlider.value;
        magazineValueText.text = magazineSlider.value.ToString();
    }
    public void BulletSpreadChange()
    {
        gun.spread = bulletSpreadSlider.value;
        spreadValueText.text = Math.Round((double)bulletSpreadSlider.value, 1).ToString();
    }
    public void ExplosiveChange()
    {
        Bullet.isExplosive = explosiveToggle.isOn;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
                Resume();
            else
                Pause();
        }
    }

    void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenu.SetActive(false);
        mainUi.SetActive(true);
        Time.timeScale = 1f;
        isGamePaused = false;
    }
    void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        mainUi.SetActive(false);
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;

    }
}
