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
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if (sprite != null)
        {
            sprite.color = highlightColor;
        }
    }
    public void OnMouseExit()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if (sprite != null)
        {
            sprite.color = Color.white;
        }
    }

    public void OnMouseDown()
    {
        transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
    }
    public void OnMouseUp()
    {
        Utility.gridRows = 2;
        Utility.gridCols = 5;
        Utility.offsetX = 2f;
        Utility.offsetY = 2.5f;
        Utility.startingPos = new Vector3(-4, 1, 0);
        Utility.startingScale = new Vector3(1, 1, 1);
        Utility.totalCards = 10;

        Utility.numbers = Utility.GetNewNumbers(5);

        transform.localScale = Vector3.one;
        if (targetObject != null)
        {
            targetObject.SendMessage(targetMessage);
        }
        GameObject.FindGameObjectWithTag("selectGrid").transform.localScale = Utility.removeScale;
    }
}
