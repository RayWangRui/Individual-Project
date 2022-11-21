#include "BluetoothSerial.h"
#include "Wire.h"
//#include <MPU6050_light.h>
#include <Adafruit_Sensor.h>
#include <Adafruit_BNO055.h>
#include <utility/imumaths.h>
Adafruit_BNO055 bno = Adafruit_BNO055(55);

//MPU6050 mpu(Wire);
unsigned long timer = 0;
    
BluetoothSerial SerialBT;
//int i;    
int AngleX,AngleY,AngleZ;
void setup()
{
  Serial.begin(9600);  
  SerialBT.begin("ESP32test_BLE");
  
  Wire.begin();
  
 /* Initialise the sensor */
  if(!bno.begin())
  {
    /* There was a problem detecting the BNO055 ... check your connections */
    Serial.print("Ooops, no BNO055 detected ... Check your wiring or I2C ADDR!");
    while(1);
  }
  
  delay(1000);
    
  bno.setExtCrystalUse(true);
  delay(1000);
}
     
void loop()
{
  /* Get a new sensor event */ 
  sensors_event_t event; 
  bno.getEvent(&event);
  
  /* Display the floating point data */
  Serial.print("X: ");
  Serial.print(event.orientation.x, 4);
  Serial.print("\tY: ");
  Serial.print(event.orientation.y, 4);
  Serial.print("\tZ: ");
  Serial.print(event.orientation.z, 4);
  Serial.println("");
  AngleX=event.orientation.x;
  AngleY=event.orientation.y;
  AngleZ=event.orientation.z;
  if((millis()-timer)>1000){ // print data every 500ms
  //Serial.print(AngleX);
  String StrTotal = "";
  StrTotal = "#" + String(AngleX) + "#" + String(AngleY) + "#"+ String(AngleZ) + "#";  
  SerialBT.println(StrTotal);
  StrTotal="";  
  timer = millis();  
 
  }

}
