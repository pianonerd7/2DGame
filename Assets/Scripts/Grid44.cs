using UnityEngine;
using System.Collections;

public class Grid44 : MonoBehaviour {


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
        Utility.gridRows = 4;
        Utility.gridCols = 4;
        Utility.offsetX = 2f;
        Utility.offsetY = 1.6f;
        Utility.startingPos = new Vector3(-3, 2, 0);
        Utility.startingScale = new Vector3(0.75f, 0.75f, 0.75f);
        Utility.totalCards = 16;

        Utility.numbers = Utility.GetNewNumbers(8);

        transform.localScale = Vector3.one;
        if (targetObject != null)
        {
            targetObject.SendMessage(targetMessage);
        }
        GameObject.FindGameObjectWithTag("selectGrid").SetActive(false);
    }
}
