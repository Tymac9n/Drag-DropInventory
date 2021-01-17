using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attributes 
{
    public int Value;
    public bool Positive;
    public Attribut Attribut;
}

public enum Attribut
{
    Strength,
    HealthPoints,
    ManaPoints,
    Agility,
    Stamina,
    BonusWeaponDamage,
    BonusFireDamage,
    BonusFrostDamage,
    FireResist,
    FrostResist
}
