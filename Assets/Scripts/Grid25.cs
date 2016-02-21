using UnityEngine;
using System.Collections;

public class Grid25 : MonoBehaviour {


    [SerializeField]
    private GameObject targetObject;
    [SerializeField]
    private string targetMessage;

    public Color highlightColor = Color.blue;
    public void OnMouseEnter()
    {
        Debug.Log("on mouse enter");
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if (sprite != null)
        {
            sprite.color = highlightColor;
        }
    }
    public void OnMouseExit()
    {
        Debug.Log("on mouse exit");
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if (sprite != null)
        {
            sprite.color = Color.white;
        }
    }

    public void OnMouseDown()
    {
        Debug.Log("on mouse down");
        transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
    }
    public void OnMouseUp()
    {
        Debug.Log("on mouse up");

        Utility.gridRows = 2;
        Utility.gridCols = 5;
        Utility.offsetX = 2f;
        Utility.offsetY = 2.5f;
        Utility.startingPos = new Vector3(-4, 1, 0);
        Utility.totalCards = 10;

        int[] numbers = { 0, 0, 1, 1, 2, 2, 3, 3 , 4, 4};
        Utility.numbers = numbers;

        transform.localScale = Vector3.one;
        if (targetObject != null)
        {
            targetObject.SendMessage(targetMessage);
        }
        GameObject.FindGameObjectWithTag("selectGrid").SetActive(false);
    }
}
