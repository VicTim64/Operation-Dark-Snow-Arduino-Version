using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;//
using System.IO.Ports; //Arduino
using UnityEngine.UI;

public class Ard02 : MonoBehaviour {
	public GameObject gamePaused;  //get gameobject paused text
	public  int numberOfZombies = 2; 
	private GameObject[] allWaypoints; 
	private GameObject zombiePrefab;

	public static SerialPort sp2 = new SerialPort ("COM8", 9600); //My arduino is set to COM8, can be changed for different COM ports
	public string sensordata; 

	public GameObject lightObj;
	public Light light;
	void Start () {
		allWaypoints = GameObject.FindGameObjectsWithTag("Waypoint");
		zombiePrefab = GameObject.FindGameObjectWithTag("Zombie");
		zombiePrefab.SetActive(false);
        //zombie initialization

		OpenConnection(); // Open the Port
	
		light = lightObj.GetComponent<Light> ();

	}

	// Update is called once per frame
	void Update () {
		//using a counter of the amount of zombies we have at the moment. We want to avoid having to do GameObject.find too many times
		int nrZombiesExist = GameObject.FindGameObjectsWithTag("Zombie").Length;
		if (nrZombiesExist < numberOfZombies )//numberOfZombies)
		{

			//instatiates a copy of zombiePrefab. I places it at the position of one of the waypoints (randomly picks an index in the waypoint array). It gives it a new rotation and adds the object that this script is attached to as parent
			Instantiate(zombiePrefab, allWaypoints[Random.Range(0, allWaypoints.Length - 1)].transform.position, new Quaternion(), transform).SetActive(true);
			//count them manually instead of calling FindGameObjectsWithTag every time
			nrZombiesExist++;
			//numberOfZombies++;

		}
		sensordata = sp2.ReadLine(); //read the line of data from arduino port
		//light.intensity = 0;
		int parsedData = int.Parse(sensordata); // The data from arduino is being stored in parsedData
		if (parsedData == 101) //sound
		{
			//print (parsedData);
			numberOfZombies++;
		}
		lightsensor(parsedData);
		hcdistance(parsedData);
	}
    public void OpenConnection()
    {
        if (sp2 != null)
        {
            if (sp2.IsOpen)
            {
                sp2.Close();
                print("closing port");
            }
            else
            {
                sp2.Open();
                sp2.ReadTimeout = 16;
                print("Port Opened");
            }
        }
        else
        {
            if(sp2.IsOpen)
            {
				print ("already on");
            }
            else
            {
                print("Port = NULL");
            }
        }
    }
    void OnApplicationQuit()
    {
        sp2.Close();
    }
    public static void sendDeathSignal()
    {
        sp2.Write("d");
    }
	public void lightsensor(int parsedData)
	{

		if (parsedData == 0) {
			//gamePaused.SetActive(true);
			//Time.timeScale = 0; // pause
			light.intensity = 0.7f; //lightComp.intensity = 0.7f;
		} else if (parsedData == 1) {
			Time.timeScale = 1;
			gamePaused.SetActive (false);
			light.intensity = 0.3f;
		}
	}
	public static void temperature(int parsedData)
	{
		if (parsedData == 51) {
			//damage player	
		}
		if (parsedData == 50) {
			//do something
		}
	}
	public void hcdistance(int parsedData)
	{
		if (parsedData == 6) {
			print(parsedData);
			resumegame ();
			}
		if (parsedData == 7) {
			print(parsedData);
			pausegame ();
		}
	}
	private void pausegame()
	{
		gamePaused.SetActive(true);
		Time.timeScale = 0; // pause
	}
	private void resumegame()
	{
		Time.timeScale = 1;
		gamePaused.SetActive (false);
	}
}


