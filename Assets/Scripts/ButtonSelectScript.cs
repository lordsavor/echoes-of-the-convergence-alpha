using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSelectScript : MonoBehaviour
{
    private InventoryHandler inventory;

    // Start is called before the first frame update
    void Start()
    {
        inventory = gameObject.GetComponentInParent<InventoryHandler>();
        GetComponent<Outline>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onSelected(Button button)
    {
        inventory.selectButton(button);
    }
}
