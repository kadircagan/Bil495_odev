using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Net.Http;
using HtmlAgilityPack;
using Newtonsoft.Json;
using System.Xml.Serialization;
using UnityEngine.UI;
using System;
using static UnityEditor.FilePathAttribute;
using Npgsql;



public class Result
{
    public string mag { get; set; }
    public double lng { get; set; }
    public double lat { get; set; }
    public string lokasyon { get; set; }
    public double depth { get; set; }
    public List<double> coordinates { get; set; }
    public string title { get; set; }
    public object rev { get; set; }
    public int timestamp { get; set; }
    public string date_stamp { get; set; }
    public string date { get; set; }
    public string hash { get; set; }
    public string hash2 { get; set; }
}
public class Root
{
    public bool status { get; set; }
    public List<Result> result { get; set; }
}
public class FirstSC : MonoBehaviour
{
    string outputArea;
    Text Location1;
    Text Magnitude1;
    Text Time1;
    Boolean firstime;

    // Start is called before the first frame update
    void Start()
    {

        firstime = true;

    }
    
    void sendToSql(String Location, String Magnitude, String Time)
    {
        
        NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres;Password=Data1234;Database=UnityDB;");
        conn.Open();
        NpgsqlCommand command = conn.CreateCommand();
        for (int i = 1; i < 2; i++)
        {
            string query = "INSERT INTO \"UnityTable\" VALUES (@Location,@Magnitude,@Time)";
            command.Parameters.AddWithValue("@Location", Location);
            command.Parameters.AddWithValue("@Magnitude", Magnitude);
            command.Parameters.AddWithValue("@Time", Time);


            command.CommandText = query;
            command.ExecuteNonQuery();

        }
        conn.Close();
    }


    void setdata(Root m)
    {
        for(int i = 1; i < 4; i++)
        {
            Location1 = GameObject.Find("Location"+i).GetComponent<Text>();
            Magnitude1 = GameObject.Find("Magnitude"+i).GetComponent<Text>();
            Time1 = GameObject.Find("Time"+i).GetComponent<Text>();
            if (firstime)
            {
                sendToSql(m.result[i - 1].lokasyon, m.result[i - 1].mag, m.result[i - 1].date);

            }

            Location1.text = m.result[i-1].lokasyon;
            Magnitude1.text = m.result[i-1].mag;
            Time1.text = m.result[i - 1].date;


        }
        
        if(firstime!)
        if (GameObject.Find("Location" + 1).GetComponent<Text>().text.Equals(m.result[0].lokasyon)!)
        {
            sendToSql(m.result[0].lokasyon, m.result[0].mag, m.result[0].date);
        }
        firstime = false;

    }
    void GetData() => StartCoroutine(GetData_Coroutine());

    IEnumerator GetData_Coroutine()
    {
        outputArea = "Loading...";
        string uri = "https://api.orhanaydogdu.com.tr/deprem/live.php?limit=5";
        using (UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            yield return request.SendWebRequest();
            if (request.isNetworkError || request.isHttpError)
                outputArea = request.error;
            else
                outputArea = request.downloadHandler.text;
        }
        //Debug.Log(outputArea);
        Root m = JsonConvert.DeserializeObject<Root>(outputArea);

        setdata(m);
        Debug.Log(m);
        Debug.Log(m.result[0].date);




    }


    private float nextActionTime = 0.0f;
    public float period = 30.0f;

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("time " +Time.time);
        if (Time.time > nextActionTime)
        {
            //Debug.Log("NExt action time: " + nextActionTime + " Time: " + Time.time);
            nextActionTime = (period+Time.time);
          //  Debug.Log("next update :"+ nextActionTime);

            GetData();
        }

    }
}
