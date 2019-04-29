// Photoresistor
  #define photoresistor 0
  bool lightoff = true;
// Unity char
  char unityChars[20];
// Sound
  #define ssdigital  7  // D0 
// RGB Light
  bool trig = true;
  bool state = true;
  int redPin = 3; // Red LED, connected to digital pin 9
  int greenPin = 2; // Green LED, connected to digital pin 10
  int bluePin = 4; // Blue LED, connected to digital pin 11
// Tone
  #define buzzer 8
// Temp & Humid
  #include <dht.h>
  #define DHTPIN A1
  dht DHT; 
// Ultra Sound HC
  #include "SR04.h"
  #define TRIG_PIN 5 
  #define ECHO_PIN 6 
  long a; 
  SR04 sr04 = SR04(ECHO_PIN,TRIG_PIN); 
//
//
//
  bool firstdeath =0;
void setup() {
 tone(buzzer,1000,200);
 Serial.begin(9600);
 pinMode(redPin, OUTPUT); // sets the pins as output
 pinMode(greenPin, OUTPUT); 
 pinMode(bluePin, OUTPUT);
 pinMode(ssdigital, INPUT);
 pinMode(photoresistor, INPUT);
}
//
//
void loop() 
{
  trig = digitalRead(ssdigital);
// Read From Unity
  int lf = 10;
  Serial.readBytesUntil(lf,unityChars,1); //laaag
  runEverything();


}
//
//
//
void runEverything()
{
  temphumid();
  dead();
  soundDetect();
  distance();
  light();
}
void light()
{
  lightoff = digitalRead(photoresistor);

   if (lightoff == 0)
  {
    Serial.println(0);
    delay(20);
    //Serial.flush();
   // analogWrite(redPin, 255);
    //analogWrite(greenPin, 0);
    //analogWrite(bluePin, 0);
   // delay(3000);
    //if active
  }
  else 
  {
    Serial.println(1);
    delay(20);
    //Serial.flush();
    //if inactive
}
}
void temphumid()
{
  DHT.read11(DHTPIN);
  int temp =  DHT.temperature;
  int hum = DHT.humidity;
  if (hum > 80)
  {
   Serial.println(52);
   delay(20);
  }
  if (temp > 30)
  {
   // Serial.print("Temp!");
   Serial.println(51);
   delay(20);
  }
  if (temp < 30)
  {
    Serial.println(50);
    delay(20);
    //do something
  }
}
void dead()
{
  trig = digitalRead(ssdigital);
  if(strcmp(unityChars,"d")==0 && firstdeath ==0)
  {
  tone(buzzer,2000,100);
  analogWrite(redPin, 255);
  analogWrite(greenPin, 0);
  analogWrite(bluePin, 0);
  delay(10000);
  firstdeath=1;
 }
}
void soundDetect()
{
 trig = digitalRead(ssdigital);
  if (trig == false && state == false)
{
  tone(buzzer,1000,100);
  state = true;
  Serial.println(101);
  delay(20);
  analogWrite(redPin,   255);
  analogWrite(greenPin, 0);
  analogWrite(bluePin, 0);
  delay(1000);
  Serial.println(100);
}
  else if(trig == false && state == true)
{
  Serial.println(101);
  delay(20);
  tone(buzzer,1000,100);
  analogWrite(redPin, 0);
  analogWrite(greenPin, 0);
  analogWrite(bluePin, 255);
  state = false;
  delay(1000);
  Serial.println(100);
}
}
void distance() {
  
  trig = digitalRead(ssdigital);
   a=sr04.Distance();
 
   // if (a<15)
   // {
   // Serial.println(5);
   // delay(20);
   /// analogWrite(redPin, 0);
   // analogWrite(greenPin, 255);
   // analogWrite(bluePin, 0);
    //delay(20);
   // }
    if ( a < 55)
    {
    Serial.println(6);
    delay(20);
    analogWrite(redPin, 0);
    analogWrite(greenPin, 0);
    analogWrite(bluePin, 255);
    //delay(20); 
    }
    else if (a > 55)
    {
    Serial.println(7);
    delay(20);
    analogWrite(redPin, 255);
    analogWrite(greenPin, 0);
    analogWrite(bluePin, 0);
    //delay(20); 
    }
 
 //delay(20);
}
