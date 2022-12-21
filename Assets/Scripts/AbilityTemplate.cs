using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    public float rarity;
    public float cooldown;
    public float power;
    public string skillName;
    public string sprite;
    public Vector2 momentum;

    public Ability(float startRarity, float startCooldown, float startPower, string defaultSkillName, string spritePath, Vector2 startMomentum){
        rarity = startRarity;
        cooldown = startCooldown;
        power = startPower;
        skillName = defaultSkillName;
        sprite = spritePath;
        momentum = startMomentum;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        

    }
}
