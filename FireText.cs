using System.Collections;
using System.Text;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
public class FireDiscord : MonoBehaviour
{
    public TextMeshProUGUI text;
    private string FireTextInfo = "";
    public void FireText()
    {
        FireTextInfo = text.text;
        StartCoroutine(PostData());
    }

    private IEnumerator PostData()
    {
        string url = "ur URL";

        string jsonData;
        jsonData = "{\"content\":\""+FireTextInfo+"\"}";
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonData);
        UnityWebRequest request = new UnityWebRequest(url,"POST");

        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        
        request.SetRequestHeader("Content-Type","application/json");

         yield return request.SendWebRequest();
    }
}
