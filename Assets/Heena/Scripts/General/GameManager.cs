using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public string username;
    public int maxMsg = 30;
    [SerializeField] List<Message> messageList = new List<Message>();
    public GameObject chatPanel, textObject;
    public List<string> onboardingInstructions = new List<string>();
    private int currInstruction = 0;
    public TMP_InputField chatBox;
    public Color playerMessage, info;
    void Start()
    {
        onboardingInstructions.Add("Welcome to Consumption, Press Space Bar to go through the Onboarding!");
        onboardingInstructions.Add("Use W, A, S, D to move around");
        onboardingInstructions.Add("Press E to interact with the environment");
        onboardingInstructions.Add("Press Esc to Pause/Resume");
        onboardingInstructions.Add("Press Tab to Quit the game");
        //SendMessageToChat(onboardingInstructions[currInstruction]);
        for (int i = 0; i < maxMsg; i++)
        {
            SendMessageToChat(onboardingInstructions[currInstruction], Message.MessageType.info);
        }
    }

    void Update()
    {
        //var chatMsg = onboardingInstructions[currInstruction];
        if(chatBox.text != "")
        {
            if(Input.GetKeyDown(KeyCode.Return))
            {
                for (int i = 0; i < maxMsg; i++)
                {
                    SendMessageToChat(username + ": " + chatBox.text, Message.MessageType.playerMessage);
                }
                chatBox.text = "";
            }
        }
        else
        {
            if(!chatBox.isFocused && Input.GetKeyDown(KeyCode.Return))
            {
                chatBox.ActivateInputField();
            }
        }
        if(!chatBox.isFocused)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ClearChat();
                if (currInstruction < onboardingInstructions.Count - 1)
                {
                    currInstruction++;
                    for (int i = 0; i < maxMsg; i++)
                    {
                        SendMessageToChat(onboardingInstructions[currInstruction], Message.MessageType.info);
                    }
                }
            }
            //var xAxis = Input.GetAxis("Horizontal");
            //if (xAxis < 0)
            //{
            //    chatMsg = onboardingInstructions[currInstruction];
            //    currInstruction++;
            //}
            //if (Input.GetKeyDown(KeyCode.Escape))
            //{
            //    chatMsg = onboardingInstructions[currInstruction];
            //    currInstruction++;
            //}
            //if (Input.GetKeyDown(KeyCode.Tab))
            //{
            //    chatMsg = onboardingInstructions[currInstruction];
            //    currInstruction++;
            //}
            //if (Input.GetKeyDown(KeyCode.E))
            //{
            //    chatMsg = onboardingInstructions[currInstruction];
            //    currInstruction++;
            //}
            //if (currInstruction < onboardingInstructions.Count - 1)
            //{
            //    currInstruction++;
            //    for (int i = 0; i < maxMsg; i++)
            //    {
            //        SendMessageToChat(chatMsg, Message.MessageType.info);
            //    }
            //}
        }
        
    }
    public void ClearChat()
    {
        foreach (var message in messageList)
        {
            Destroy(message.textObject.gameObject);
        }
        messageList.Clear();
    }
    public void SendMessageToChat(string text, Message.MessageType messageType)
    {
        if(messageList.Count >= maxMsg)
        {
            Destroy(messageList[0].textObject.gameObject);
            messageList.RemoveAt(0);
        }
        Message newMessage = new Message();
        newMessage.text = text;
        GameObject newText = Instantiate(textObject, chatPanel.transform);
        newMessage.textObject = newText.GetComponent<TMP_Text>();
        newMessage.textObject.text = newMessage.text;
        newMessage.textObject.color = MessageTypeColor(messageType);
        messageList.Add(newMessage);
    }
    Color MessageTypeColor(Message.MessageType messageType)
    {
        Color color = info;
        switch (messageType)
        {
            case Message.MessageType.playerMessage:
                color = playerMessage;
                break;
            case Message.MessageType.info:
                color = info;
                break;
        }
        return color;
    }
}
[System.Serializable]
public class Message
{
    public string text;
    public TMP_Text textObject;
    public MessageType messageType;

    public enum MessageType
    {
       playerMessage,
       info
    }
}
