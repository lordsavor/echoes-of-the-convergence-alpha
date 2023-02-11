using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Draggable : MonoBehaviour
{
    [SerializeField] private Material[] outline;

    private GameManager gameManager;
    bool canMove;
    bool dragging;
    bool overlapping;
    Collider2D roomCollider;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        roomCollider = GetComponent<Collider2D>();
        canMove = false;
        dragging = false;
        overlapping = false;
    }

    // Update is called once per frame
    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (roomCollider == Physics2D.OverlapPoint(mousePos))
            {
                if (gameManager.IsSelected(this.gameObject))
                {
                    canMove = true;
                }
                else if(!overlapping)
                {
                    gameManager.SetSelected(this.gameObject);
                    gameObject.GetComponent<Renderer>().material = outline[1];
                }
            }
            else
            {
                if (!overlapping) { 
                    gameManager.Deselect(this.gameObject);
                    gameObject.GetComponent<Renderer>().material = outline[0];
                    canMove = false;
                }
            }
            if (canMove)
            {
                dragging = true;
            }
        }
        if (dragging)
        {
            Vector2 mouseVec = mousePos;
            mouseVec.x = Mathf.Round(mouseVec.x);
            mouseVec.y = Mathf.Round(mouseVec.y);

            Vector2 sprite_size = GetComponent<SpriteRenderer>().sprite.rect.size;
            Vector2 local_sprite_size = sprite_size / GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;

            if (local_sprite_size.x % 2 == 1)
            {
                mouseVec.x += 0.5f;
            }

            this.transform.position = mouseVec;
        }
        if (Input.GetMouseButtonUp(0))
        {
            canMove = false;
            dragging = false;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        overlapping = true;
        if (gameManager.IsSelected(this.gameObject))
        {
            gameObject.GetComponent<Renderer>().material = outline[2];
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        overlapping = false;
        if (gameManager.IsSelected(this.gameObject))
        {
            gameObject.GetComponent<Renderer>().material = outline[1];
        }
    }
}
