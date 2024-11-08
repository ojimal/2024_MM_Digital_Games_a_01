using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI lemonText;
    // Start is called before the first frame update
    void Start()
    {
        lemonText = GetComponent<TextMeshProUGUI>();
    }
    public void UpdateLemonText(Collect playerInventory)
    {
        lemonText.text = playerInventory.NumberOfLemons.ToString();
    }
}
