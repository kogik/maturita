#include <CheapStepper.h>
#include <Adafruit_MCP23X17.h>
#include <Joystick.h>

CheapStepper stepper;
Joystick_ Joystick;
Adafruit_MCP23X17 mcp;


String msg;
float pos;
float speed;
float final;
int lastButtonState[6];


void setup() {
  Serial.begin(9600);
  Serial.setTimeout(10);
  
  pinMode(12, INPUT_PULLUP);

  delay(1000);

  while(digitalRead(12)){
    stepper.move(true, 1);
  }

  
  stepper.move(false, 100);

  if (!mcp.begin_I2C()) {
    Serial.println("Error");
    while (1);
  }
  
  for(int x=0; x < 6; x++){
    mcp.pinMode(x, INPUT_PULLUP);
    lastButtonState[x] = mcp.digitalRead(x);
  }

  Joystick.begin();

}

void loop() {


  for (int i = 0; i < 6; i++)
  {
    int currentButtonState = !mcp.digitalRead(i);
    if (currentButtonState != lastButtonState[i])
    {
      
      if(i < 2){
        Joystick.setButton(i, !currentButtonState);
      }else{
        Joystick.setButton(i, currentButtonState);
      }
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
