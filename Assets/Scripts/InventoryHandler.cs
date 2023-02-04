using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public enum RoomType : int
{
    Laser = 0,
    Shield = 1,
    Missile = 2
}

public struct RoomData
{
    private RoomType roomType;
    private Button button;

    public RoomType GetType()
    {
        return roomType;
    }

    public void SetType(RoomType value)
    {
        roomType = value;
    }

    public Button getButton()
    {
        return button;
    }

    public void SetButton(Button button)
    {
        this.button = button;
    }
}

public class InventoryHandler : MonoBehaviour
{
    [SerializeField] private Button[] roomButton;
    [SerializeField] private Sprite[] roomSprites;
    [SerializeField] private GameObject[] roomPrefabs;

    private Button selected;

    private ArrayList roomList = new ArrayList();

    // Start is called before the first frame update
    void Start()
    { 
        for(int i = 0; i < 3; i++)
        {
            RoomData rd = new RoomData();
            rd.SetType(RoomType.Laser);
            rd.SetButton(AddRoomButton(rd));
            roomList.Add(rd);
        }

        for (int i = 0; i < 3; i++)
        {
            RoomData rd = new RoomData();
            rd.SetType(RoomType.Shield);
            rd.SetButton(AddRoomButton(rd));
            roomList.Add(rd);
        }

        for (int i = 0; i < 3; i++)
        {
            RoomData rd = new RoomData();
            rd.SetType(RoomType.Missile);
            rd.SetButton(AddRoomButton(rd));
            roomList.Add(rd);
        }
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Button AddRoomButton(RoomData room)
    {
        Vector2 newButtonPosition = new Vector2();
        newButtonPosition.x = 50 + (roomList.Count % 3) * 200;
        newButtonPosition.y = -50 - (125 * (roomList.Count / 3));
        
        Button button_instance = GameObject.Instantiate(roomButton[(int)room.GetType()], newButtonPosition, Quaternion.identity);
        button_instance.transform.SetParent(gameObject.transform, false);
        button_instance.image.sprite = roomSprites[(int)room.GetType()];
        return button_instance;
    }

    public void showPanel()
    {
        gameObject.SetActive(true);
    }
    public void hidePanel()
    {
        gameObject.SetActive(false);
    }

    public RoomData getRoomDataByButton(Button button)
    {
        for(int i = 0; i < roomList.Count; i++)
        {
            if(((RoomData)roomList[i]).getButton() == button)
            {
                return (RoomData)roomList[i];
            }
        }
        return new RoomData();
    }
    public void selectButton(Button new_select)
    {
        if (selected != null) { 
        Outline outline = selected.GetComponent<Outline>();
        outline.enabled = false;
        }
        Outline new_outline;
        selected = new_select;
        new_outline = selected.GetComponent<Outline>();
        new_outline.enabled = true;
    }
    public void deployRoom()
    {
        RoomData data = getRoomDataByButton(selected);
        GameObject.Instantiate(roomPrefabs[(int)data.GetType()]);
        roomList.Remove(data);
        GameObject.Destroy(selected.gameObject);
        hidePanel();
    }
}
