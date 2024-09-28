using UnityEngine;

public class SingletonPattern : MonoBehaviour
{
    public static SingletonPattern Instance { get; private set; } //Singleton

    private void Awake()
    {
        if (Instance != null) //Singleton
        {
            Debug.LogWarning("More than one instance of SingletonPattern found!" + Instance + transform);
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
}
