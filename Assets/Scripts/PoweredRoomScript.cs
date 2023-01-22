using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PoweredRoomScript : RoomScript
{
    [SerializeField] protected int max_hp;
    [SerializeField] protected float hp;
    [SerializeField] protected int max_power;
    [SerializeField] protected int power;
    [SerializeField] protected int defense;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
