using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private ArrayList roomList;
    private GameObject selected;
    // Start is called before the first frame update
    void Start()
    {
        roomList = new ArrayList();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    public void AddRoom(GameObject room)
    {
        roomList.Add(room);
    }

    public void SetSelected(GameObject room)
    {
        this.selected = room;
    }

    public void Deselect(GameObject room)
    {
        if(this.selected == room)
        {
            this.selected = null;
        }
    }

    public bool IsSelected(GameObject room)
    {
        if (this.selected == room) return true;
        else return false;
    }
}
