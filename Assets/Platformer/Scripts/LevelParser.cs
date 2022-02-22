using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelParser : MonoBehaviour
{
    public string filename;
    public GameObject rockPrefab;
    public GameObject brickPrefab;
    public GameObject questionBoxPrefab;
    public GameObject stonePrefab;
    public Transform environmentRoot;

    // --------------------------------------------------------------------------
    void Start()
    {
        LoadLevel();
    }

    // --------------------------------------------------------------------------
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadLevel();
        }
    }

    // --------------------------------------------------------------------------
    private void LoadLevel()
    {
        string fileToParse = $"{Application.dataPath}{"/Resources/"}{filename}.txt";
        Debug.Log($"Loading level file: {fileToParse}");

        Stack<string> levelRows = new Stack<string>();

        // Get each line of text representing blocks in our level
        using (StreamReader sr = new StreamReader(fileToParse))
        {
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                levelRows.Push(line);
            }

            sr.Close();
        }

        // Go through the rows from bottom to top
        int row = 0;
        while (levelRows.Count > 0)
        {
            string currentLine = levelRows.Pop();

            int column = 0;
            char[] letters = currentLine.ToCharArray();
            foreach (var letter in letters)
            {
                if (letter == 'x')
                {
                    var testObject = Instantiate(rockPrefab);
                    testObject.transform.position = new Vector3(column, row, 0f);

                }else if(letter == 'b')
                {
                    var objectB = Instantiate(brickPrefab);
                    objectB.transform.position = new Vector3(column, row, 0f);

                }else if(letter == '?')
                {
                    var objectQ = Instantiate(questionBoxPrefab);
                    objectQ.transform.position = new Vector3(column, row, 0f);

                }else if(letter == 's')
                {
                    var objectS = Instantiate(stonePrefab);
                    objectS.transform.position = new Vector3(column, row, 0f);

                }

                
                // Todo - Instantiate a new GameObject that matches the type specified by letter
                // Todo - Position the new GameObject at the appropriate location by using row and column
                // Todo - Parent the new GameObject under levelRoot
                column++;
            }
            row++;
        }
    }

    // --------------------------------------------------------------------------
    private void ReloadLevel()
    {
        foreach (Transform child in environmentRoot)
        {
           Destroy(child.gameObject);
        }
        LoadLevel();
    }
}
