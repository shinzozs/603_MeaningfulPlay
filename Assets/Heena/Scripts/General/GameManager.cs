using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public string username;
    public int maxMsg = 1;
    [SerializeField] List<Message> messageList = new List<Message>();
    public GameObject chatPanel, textObject;
    public List<string> onboardingInstructions = new List<string>();
    private int currInstruction = 0;
    public TMP_InputField chatBox;
    public Color playerMessage, info;
    private int b_index;
    void Start()
    {
        b_index = SceneManager.GetActiveScene().buildIndex;
        if (b_index == 1)
        {
            onboardingInstructions.Add("Welcome to Consumption, Press Space Bar to go through the Onboarding!");
            onboardingInstructions.Add("My Name is The Director, you have beutiful eyes.......");
            onboardingInstructions.Add("Welcome to my realm. You let a self absorbed and arogant life...");
            onboardingInstructions.Add("Your need to inhale the displesure of others for your own entertainment is your ruin");
            onboardingInstructions.Add("You will now know what it feels like to be my entertainment as I consume your soul");
            onboardingInstructions.Add("Going to close to screens in my realm will polute your vision with spam.");
            onboardingInstructions.Add("Be careful though, some spam messages have important information hidden within...");
            onboardingInstructions.Add("Use W, A, S, D to move around....just remeber I can see you......");
            onboardingInstructions.Add("Use Keyboard Keys to Close Popups.....the same pop-ups you craved in life......");
            onboardingInstructions.Add("Use Left Shift to Sprint...but you cant run for ever : )");
            onboardingInstructions.Add("Press E to interact with the environment and steal items : (");
            onboardingInstructions.Add("Press Esc to Pause/Resume..just know it wont save you....");
            onboardingInstructions.Add("Press Tab to Quit to give up");
        }
        else if (b_index == 2)
        {
            onboardingInstructions.Add("I can see you");
            onboardingInstructions.Add("You have lovely shoes");
            onboardingInstructions.Add("So lonely......");
            onboardingInstructions.Add("They never seem to sleep");
            onboardingInstructions.Add("This is getting boring");
            onboardingInstructions.Add("Thats your good side.....");
            onboardingInstructions.Add("Thankyou for the donation");
            onboardingInstructions.Add("I grow tired of your games....");
            onboardingInstructions.Add("I can see you");
            onboardingInstructions.Add("You have lovely shoes");
            onboardingInstructions.Add("So lonely......");
            onboardingInstructions.Add("They never seem to sleep");
            onboardingInstructions.Add("This is getting boring");
            onboardingInstructions.Add("Thats your good side.....");
            onboardingInstructions.Add("Thankyou for the donation");
            onboardingInstructions.Add("I grow tired of your games....");
            onboardingInstructions.Add("You will die here");
        }

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
            if(!chatBox.isFocused && Input.GetKeyDown(KeyCode.T))
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
