using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeaponRoomScript : PoweredRoomScript
{
    [SerializeField] protected float reload;
    private float charge;
    [SerializeField] protected float cooldown;

    // Start is called before the first frame update
    void Start()
    {
        charge = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        charge += 1 / reload * Time.fixedDeltaTime * (power / max_power);
        if (charge >= 1)
        {
            Fire();
            charge = 0;
        }
    }

    private void Fire()
    {
        Debug.Log("Fire!");
    }
}
