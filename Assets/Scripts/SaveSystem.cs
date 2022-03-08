using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace SaveSystemTutorial
{
    public class SaveSystem
    {
        #region PlayerPrefs
        public static void SaveData(string key,object value)
        {
            PlayerPrefs.SetString(key, JsonUtility.ToJson(value));
            PlayerPrefs.Save();
        }

        public static string LoadData(string key)
        {
            return PlayerPrefs.GetString(key,null);
        }
        #endregion

        #region Json
        public static void SaveJsonData(string saveFileName,object data)
        {
            var path = Path.Combine("E:\\study",saveFileName);
            try
            {
                var json = JsonUtility.ToJson(data);
                File.WriteAllText(path, json);

                #if UNITY_EDITOR
                Debug.Log($"Susscessfuly saved data{path}");
                #endif

            }
            catch (System.Exception)
            {

                Debug.Log("have Problem");
            }
        }

        public static T LoadJsonData<T>(string loadFileName)
        {
            var path = Path.Combine("E:\\study", loadFileName);
            try
            {
                var json = File.ReadAllText(path);
                return JsonUtility.FromJson<T>(json);
            }
            catch (System.Exception)
            {
                Debug.Log("No Find");
                return default;
            }
        }

        public static void DeleteFile(string fileName)
        {
            var path = Path.Combine("E:\\study", fileName);
            File.Delete(path);

            try
            {
                File.Delete(path);
            }
            catch (System.Exception)
            {

                Debug.Log("No Find");
            }
        }
        #endregion
    }
}
