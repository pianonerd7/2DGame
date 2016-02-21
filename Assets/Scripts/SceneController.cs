﻿using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour
{
    public const int gridRows = 2;
    public const int gridCols = 4;
    public const float offsetX = 2f;
    public const float offsetY = 2.5f;

    [SerializeField]
    private MemoryCard originalCard;
    [SerializeField]
    private Sprite[] images;
    [SerializeField]
    private TextMesh scoreLabel;

    private MemoryCard _firstRevealed;
    private MemoryCard _secondRevealed;
    private int _score = 0;

    private int totalCards = 8;
    private int cardsSoFar = 0;
    private GameObject winScreen;
    private GameObject endButton;
    private GameObject startButton;
    public GameObject smoke;

    public bool canReveal
    {
        get { return _secondRevealed == null; }
    }

    // Use this for initialization
    void Start()
    {
        winScreen = GameObject.FindGameObjectWithTag("winScreen");
        endButton = GameObject.FindGameObjectWithTag("endButton");
        startButton = GameObject.FindGameObjectWithTag("startButton");

        instantiate();
    }

    private void instantiate()
    {
        Vector3 startPos = originalCard.transform.position;

        // create shuffled list of cards
        int[] numbers = { 0, 0, 1, 1, 2, 2, 3, 3 };
        numbers = ShuffleArray(numbers);

        // place cards in a grid
        for (int i = 0; i < gridCols; i++)
        {
            for (int j = 0; j < gridRows; j++)
            {
                MemoryCard card;

                // use the original for the first grid space
                if (i == 0 && j == 0)
                {
                    card = originalCard;
                }
                else
                {
                    card = Instantiate(originalCard) as MemoryCard;
                }

                // next card in the list for each grid space
                int index = j * gridCols + i;
                int id = numbers[index];
                card.SetCard(id, images[id]);

                float posX = (offsetX * i) + startPos.x;
                float posY = -(offsetY * j) + startPos.y;
                card.transform.position = new Vector3(posX, posY, startPos.z);
            }
        }
    }

    // Knuth shuffle algorithm
    private int[] ShuffleArray(int[] numbers)
    {
        int[] newArray = numbers.Clone() as int[];
        for (int i = 0; i < newArray.Length; i++)
        {
            int tmp = newArray[i];
            int r = Random.Range(i, newArray.Length);
            newArray[i] = newArray[r];
            newArray[r] = tmp;
        }
        return newArray;
    }

    public void CardRevealed(MemoryCard card)
    {
        if (_firstRevealed == null)
        {
            _firstRevealed = card;
        }
        else
        {
            _secondRevealed = card;
            StartCoroutine(CheckMatch());
        }
    }

    private IEnumerator CheckMatch()
    {

        // increment score if the cards match
        if (_firstRevealed.id == _secondRevealed.id)
        {
            cardsSoFar += 2;

            _score++;
            scoreLabel.text = "Score: " + _score;

            
            var speed = 10f;

            int i = 7;
            while (i > 0)
            {
                _firstRevealed.transform.Rotate(0, 0, Mathf.Cos(Time.fixedTime) * speed, Space.World);
                _secondRevealed.transform.Rotate(0, 0, Mathf.Cos(Time.fixedTime) * speed, Space.World);
                speed = -speed;
                yield return new WaitForSeconds(.15f);
                i--;
            }

            Vector3 firstPosition = _firstRevealed.transform.position;
            Quaternion firstRotation = _firstRevealed.transform.rotation;
            Vector3 secondPosition = _secondRevealed.transform.position;
            Quaternion secondRotation = _secondRevealed.transform.rotation;

            Instantiate(smoke, firstPosition, firstRotation);
            Instantiate(smoke, secondPosition, secondRotation);
            yield return new WaitForSeconds(0.5f);
            Destroy(_firstRevealed.gameObject);
            Destroy(_secondRevealed.gameObject);

            if (cardsSoFar == totalCards)
            {
                winScreen.transform.localScale = new Vector3(1, 1, 1);
                yield return new WaitForSeconds(2f);
                winScreen.transform.localScale = new Vector3(0, 0, 0);

                startButton.transform.localScale = new Vector3(1, 1, 1);
                endButton.transform.localScale = new Vector3(1, 1, 1);
            }
        }

        // otherwise turn them back over after .5s pause
        else
        {
            yield return new WaitForSeconds(.5f);

            _firstRevealed.Unreveal();
            _secondRevealed.Unreveal();
        }

        _firstRevealed = null;
        _secondRevealed = null;
    }

    public void Restart()
    {
        Application.LoadLevel("Scene");
    }
}