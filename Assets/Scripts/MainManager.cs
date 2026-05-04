using UnityEngine;
using System.IO;

public class MainManager : MonoBehaviour
{
public static MainManager Instance;

public Color TeamColor;//linha adicionada

private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);


        LoadColor();
    }

[System.Serializable]

class SaveData
{
    public Color TeamColor;
}
 public void saveColor()
 {
     SaveData data = new SaveData();
     data.TeamColor = TeamColor;


     string Json = JsonUtility.ToJson(data);
     File.WriteAllText(Application.persistentDataPath + "/SaveFile.json",Json);
 } 
 public void LoadColor()
 {
    string path = Application.persistentDataPath + "/SaveDfile.json";
    if (File.Exists(path))
    {
     string json = File.ReadAllText(path);
     SaveData data = JsonUtility.FromJson<SaveData>(json);

     TeamColor = data.TeamColor;

    }
 }

}
