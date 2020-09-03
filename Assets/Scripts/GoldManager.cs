using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldManager : MonoBehaviour
{
    public Text goldAmount;
    public FloatValue playerGold;

    void Start() {
        UpdateGold();
    }

    public void UpdateGold()
    {
        goldAmount.text = playerGold.initialValue.ToString();
    }
}
