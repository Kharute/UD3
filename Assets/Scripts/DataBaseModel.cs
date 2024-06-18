using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class DataBaseModel : MonoBehaviour
{
    [System.Obsolete]
    IEnumerator UploadData()
    {
        string url = "http://localhost:3000/saveData"; // Node.js 서버의 엔드포인트 URL
        string jsonData = "{\"value\": 10}"; // 저장할 데이터 (예시)

        // HTTP POST 요청 설정
        using (UnityWebRequest request = UnityWebRequest.Post(url, "POST"))
        {
            byte[] jsonBytes = System.Text.Encoding.UTF8.GetBytes(jsonData);
            request.uploadHandler = new UploadHandlerRaw(jsonBytes);
            request.SetRequestHeader("Content-Type", "application/json");

            // 요청 보내기
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
