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

        Utility.rows = 4;
        Utility.columns = 4;

        transform.localScale = Vector3.one;
        if (targetObject != null)
        {
            targetObject.SendMessage(targetMessage);
        }
        GameObject.FindGameObjectWithTag("selectGrid").SetActive(false);
    }
}
