using UnityEngine;
using System.Collections;

public class Grid34 : MonoBehaviour {


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
        Utility.gridRows = 3;
        Utility.gridCols = 4;
        Utility.offsetX = 2f;
        Utility.offsetY = 2.1f;
        Utility.startingPos = new Vector3(-3, 1.5f, 0);
        Utility.totalCards = 12;

        Utility.numbers = Utility.GetNewNumbers(6);

        transform.localScale = Vector3.one;
        if (targetObject != null)
        {
            targetObject.SendMessage(targetMessage);
        }
        GameObject.FindGameObjectWithTag("selectGrid").SetActive(false);
    }
}
