#include <CheapStepper.h>
#include <Adafruit_MCP23X17.h>
#include <Joystick.h>

#define calibrationPin 12

CheapStepper stepper;
Joystick_ Joystick;
Adafruit_MCP23X17 mcp;

// Defining variables
String msg;
float pos;
float speed;
float final;
int lastButtonState[15];


void setup() {

  // Initialize serial communication
  Serial.begin(9600);
  Serial.setTimeout(10);  

  delay(1000);

  Serial.println("setup");
  
  pinMode(calibrationPin, INPUT_PULLUP);


  for(int i=0; i<3000; i++){
    if (!digitalRead(calibrationPin))
      break;
    stepper.move(true, 1);
  }

    
  if(digitalRead(calibrationPin)){
    Serial.println("Error - Calibration");
  }


  // Offset from calibration position to 0
  stepper.move(false, 100);


  // Begin I2C communication with MCP23017
  if (!mcp.begin_I2C()) {
    Serial.println("Error - I2C");
    while (1);
  }


  // Setting MCP23017 pins as INPUT_PULLUP
  for(int x=0; x < 15; x++){
    mcp.pinMode(x, INPUT_PULLUP);
    lastButtonState[x] = mcp.digitalRead(x);
  }


  // Initalizing HID connection
  Joystick.begin();

}

void loop() {
  
  
  for (int i = 0; i < 15; i++)
  {
    int currentButtonState = !mcp.digitalRead(i);
    if (currentButtonState != lastButtonState[i])
    {
      
      Joystick.setButton(i, !currentButtonState);
      lastButtonState[i] = currentButtonState;
    }
  }

  while(Serial.available()){
    msg = Serial.readString();
    speed = msg.toFloat();
    if(speed < 121){
      final = (speed < 20) ?  map(speed,0,20,0,300) : map(speed,20,120,300,2850);
      (final > pos) ? stepper.move(false, final-pos) : stepper.move(true, pos-final);
      pos = final;

         
      
    }else{
      Serial.println(" > 120"); 
      
    }
    Serial.println(stepper.getStep());
      
  }

}


float map(float s, float a1, float a2, float b1, float b2)
{
  return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
}
