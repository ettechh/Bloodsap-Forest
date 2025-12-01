using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] GameObject FlashlightLight;
    [SerializeField] AudioSource flashlightSound;

    private bool FlashlightActive = false;

    void Start()
    {
        FlashlightLight.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (FlashlightActive == false)
            {
                FlashlightLight.SetActive(true);
                FlashlightActive = true;
            }
            else
            {
                FlashlightLight.SetActive(false);
                FlashlightActive = false;
            }

            // 2. Play the sound
            // We put this here so it plays regardless of whether turning ON or OFF
            flashlightSound.Play();
        }
    }
}
