using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStats 
{
    
    public int health;
    public int maxHealth;
    public int mana;
    public int maxMana;
    public int damage;
    public int armor;
    public int magic;
    public UnitStats(int _hp,int _maxHp,int _mana, int _maxMana, int _damage, int _armor, int _magic)
    {
        health = _hp;
        maxHealth = _maxHp;
        mana = _mana;
        maxMana = _maxMana;
        damage = _damage;
        armor = _armor;
        magic = _magic;
    }
}
