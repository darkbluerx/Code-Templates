using UnityEngine;

[CreateAssetMenu(fileName = "newCharacterData", menuName = "ScriptableObjects/CharacterData", order = 1)]
public class CharacterDataSO : ScriptableObject //Remember to set the values of the variables
{
    public int maxHealth;

    public int dmg;

    public Sprite healthBar;
    public Sprite characterImage;

    public GameObject characterPrefab;
    public GameObject healthBarPrefab;

     public Color characterColor; //Different color for each character/enemys
     public Color healthBarColor;
     public Color healthTextColor;

    public CharacterDataSO(int health, int dmg) //Constructor
    {
        this.maxHealth = health;
        this.dmg = dmg;
    }
}
