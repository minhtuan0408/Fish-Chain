using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;

public static class ApiClient
{
    public static IEnumerator Post(string url, string json, System.Action<string> callback)
    {
        UnityWebRequest request = new UnityWebRequest(url, "POST"); // ① Tạo HTTP POST

        byte[] body = Encoding.UTF8.GetBytes(json);                  // ② Chuyển JSON string thành byte[]

        request.uploadHandler = new UploadHandlerRaw(body);         // ③ Gửi dữ liệu đó đi
        request.downloadHandler = new DownloadHandlerBuffer();      // ④ Nhận dữ liệu phản hồi

        request.SetRequestHeader("Content-Type", "application/json"); // ⑤ Báo là gửi JSON

        yield return request.SendWebRequest();                      // ⑥ Gửi request & chờ phản hồi

        callback?.Invoke(request.downloadHandler.text);             // ⑦ Trả kết quả response qua callback
    }
    public static IEnumerator Get(string url, System.Action<string> callback)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError ||
                request.result == UnityWebRequest.Result.ProtocolError)
            {
                callback?.Invoke(null);
            }
            else
            {
                callback?.Invoke(request.downloadHandler.text);
            }
        }
    }
}
