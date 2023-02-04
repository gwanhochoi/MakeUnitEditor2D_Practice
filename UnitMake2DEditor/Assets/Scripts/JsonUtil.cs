using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public class JsonUtil
{
    public JsonUtil()
    {

    }

    public T Load_Data<T>(string parts_name)
    {
        string path = Path.Combine(Application.dataPath + "/ItemJson/", parts_name + ".json");
        T loadData;
        
        if (!File.Exists(path))
        {
            Save_Data(parts_name, default(T));
            return default(T);
        }
        string json = File.ReadAllText(path);
        loadData = JsonConvert.DeserializeObject<T>(json);
        return loadData;
   
    }

    public void Save_Data<T>(string parts_name, T data)
    {
        string path = Path.Combine(Application.dataPath + "/ItemJson/", parts_name + ".json");
        if (data == null)
        {
            Debug.Log("save data null");
            File.WriteAllText(path,"");
        }
        
        string json = JsonConvert.SerializeObject(data);
        File.WriteAllText(path, json);
    }

}
