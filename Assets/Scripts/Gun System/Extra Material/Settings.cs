using UnityEngine;
using System;

public class Settings : MonoBehaviour
{
    public event Action OnDisableGun2; //Disable the gun
    public event Action OnEnableGun; //Enable the gun
    public static Settings Instance { get; private set; } //Singleton

    [SerializeField] GameObject settingsPanel;
    [SerializeField] GameObject closeGuidanceTextButton;

    public static event Action OnOpenSettingsPanel;

    private void Awake() //Singleton
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            Debug.LogError("There can only be one Settings" + transform + " " + Instance);
            return;
        }
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            OnDisableGun2?.Invoke(); //Disable the TopDownGunController3D scipt, call method DisableGun -> TopDownGunController3D.cs

            OnOpenSettingsPanel?.Invoke();
        }
    }

    private void OnEnable()
    {
        OnOpenSettingsPanel += OpenSettingsPanel;
    }

    public void OpenSettingsPanel()
    {
        if (settingsPanel == null) { return; }
        if (closeGuidanceTextButton == null) { return; }

        closeGuidanceTextButton.SetActive(false);
        Cursor.visible = true;
        settingsPanel.SetActive(true);
        Time.timeScale = 0; // Pause the game
    }

    public void CloseSettingsPanel()
    {
        Cursor.visible = false;
        closeGuidanceTextButton.SetActive(true);
        Time.timeScale = 1; // Resume the game
        OnEnableGun?.Invoke(); //Enable the Gun scipt, call method EnableGun -> TopDownGunController3D.cs
    }

    public void CallOnDisableGun2()
    {
        OnDisableGun2?.Invoke();
    }
}
