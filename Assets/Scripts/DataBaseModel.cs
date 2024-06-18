using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class DataBaseModel : MonoBehaviour
{
    [System.Obsolete]
    IEnumerator UploadData()
    {
        string url = "http://localhost:3000/saveData"; // Node.js ������ ��������Ʈ URL
        string jsonData = "{\"value\": 10}"; // ������ ������ (����)

        // HTTP POST ��û ����
        using (UnityWebRequest request = UnityWebRequest.Post(url, "POST"))
        {
            byte[] jsonBytes = System.Text.Encoding.UTF8.GetBytes(jsonData);
            request.uploadHandler = new UploadHandlerRaw(jsonBytes);
            request.SetRequestHeader("Content-Type", "application/json");

            // ��û ������
            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Failed to upload data: " + request.error);
            }
            else
            {
                Debug.Log("Data uploaded successfully!");
            }
        }
    }

    [System.Obsolete]
    void Start()
    {
        StartCoroutine(UploadData());
    }
}
