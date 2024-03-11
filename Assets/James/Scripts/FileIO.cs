using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class FileIO : MonoBehaviour
{
    string directoryName = System.Environment.CurrentDirectory;
    string fileName = "player-data.txt";
    float timeStart = 0;
    bool timeStamped = false;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        fileName = directoryName + "\\" + fileName;
        //Debug.Log(fileName);
        //writeToFile("test", "0:00");

    }
    void writeToFile(string title, string time)
    {
        int numOfLines = File.ReadAllLines(fileName).Length;

        StreamWriter writer = new StreamWriter(fileName, true);
        writer.WriteLine("Player " + (numOfLines / 2 + 1));

        writer.WriteLine(title + ":" + time + "\n");
        writer.Close();
    }

    // Update is called once per frame
    void Update()
    {
        timeStart += Time.deltaTime;
        if (SceneManager.GetActiveScene().name == "End Scene" && !timeStamped)
        {
            writeToFile("Final Time", timeStart.ToString());
            timeStamped = true;
        }
    }
}
