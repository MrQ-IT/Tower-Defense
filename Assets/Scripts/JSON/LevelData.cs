using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LevelData
{
    public bool islock;
    public int star;
    public int lives;
    public int currency;

    public LevelData(bool islock, int star, int lives, int currency)
    {
        this.islock = islock;
        this.star = star;
        this.lives = lives;
        this.currency = currency;
    }
}
