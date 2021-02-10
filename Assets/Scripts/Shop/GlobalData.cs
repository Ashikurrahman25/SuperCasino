using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalData
{
    public static int selectedBall;
    public static int selectedBG;

    public static int freezeCount;
    public static int speedCount;
    public static int slowCount;
    public static int doubleCount;
}



[System.Serializable]
public class Product
{
    public string productName;
    public int productPrice;
    public bool isBought;
    public bool isSelected;

}

[System.Serializable]
public class Prize
{
    public int iconIndex;
    public string prizeName;
    public int sellPrice;

    public Prize () { }

    public Prize(int iconIndex, string prizeName, int sellPrice)
    {
        this.iconIndex = iconIndex;
        this.prizeName = prizeName;
        this.sellPrice = sellPrice;
    }
}

[System.Serializable]
public class AllList
{
    public Product[] ballSkins;
    public Product[] backgrounds;
    public Product[] powerUps;

    public List<Prize> achievedPrizes;
}

