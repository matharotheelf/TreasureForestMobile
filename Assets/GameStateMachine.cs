using UnityEngine;
using TMPro;
using System.Collections;
using System.Text;
using UnityEngine.Networking;

public class GameStateMachine : MonoBehaviour
{
    public bool waterfallDetected = false;
    public bool crystalDetected = false;
    public bool crystalSelected = false;
    public bool waterfallSelected = false;
    public bool mapSubmitted = false;
    public string waterfallCharacter = "";
    public string crystalCharacter = "";

    [SerializeField] TMP_Text displayText;
    [SerializeField] GameObject submitButton;

    public void detectWaterfall()
    {
        waterfallDetected = true;

        if(crystalDetected)
        {
            displayText.SetText("Choose which home belongs to which guide!");
        }
    }

    public void detectCrystal()
    {
        crystalDetected = true;

        if (waterfallDetected)
        {
            displayText.SetText("Choose which home belongs to which guide!");
        }
    }

    public void selectCrystal(string character)
    {
        crystalSelected = true;
        crystalCharacter = character;

        if (waterfallSelected)
        {
            displayText.SetText("Great! now tell the world your choice!");
            submitButton.SetActive(true);
        }
    }

    public void deselectCrystal(string character)
    {
        crystalSelected = false;
        crystalCharacter = "";

        if (waterfallSelected)
        {
            displayText.SetText("Choose which home belongs to which guide!");
            submitButton.SetActive(false);
        }
    }

    public void selectWaterfall(string character)
    {
        waterfallSelected = true;
        waterfallCharacter = character;

        if (crystalSelected)
        {
            displayText.SetText("Great! now tell the world your choice!");
            submitButton.SetActive(true);
        }
    }

    public void deselectWaterfall(string character)
    {
        waterfallSelected = false;
        waterfallCharacter = "";

        if (crystalSelected)
        {
            displayText.SetText("Choose which home belongs to which guide!");
            submitButton.SetActive(false);
        }
    }

    public void submitMap()
    {
        StartCoroutine("postRequest");
        displayText.SetText("Waiting for choice to be sent out to the world...");
    }

    IEnumerator postRequest()
    {
        string bodyJsonString = $@"{{
          ""mappings"": [
            {{
              ""character"": ""{crystalCharacter}"",
              ""location"": ""crystal""
            }},
            {{
              ""character"": ""{waterfallCharacter}"",
              ""location"": ""waterfall""
            }}
          ]
        }}";

        var request = new UnityWebRequest("https://treasure-forest-api.onrender.com/forest-mapping", "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(bodyJsonString);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();
        Debug.Log("Status Code: " + request.responseCode);

        if (request.isNetworkError)
        {
            displayText.SetText("Unfortunately map not created try again.");
        }
        else
        {
            displayText.SetText("The world is waiting. GO PLAY IN VR!");
            submitButton.SetActive(false);
        }
    }
}
