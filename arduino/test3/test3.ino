#include <Adafruit_MCP23X17.h>
#include <Joystick.h>
#include <Stepper.h>

Joystick_ Joystick;
Adafruit_MCP23X17 mcp;

Stepper stepper(100, 8, 9, 10, 11);

int lastButtonState[6];

void setup() {
  Serial.begin(9600);
  Serial.setTimeout(10);
  delay(1000);

  if (!mcp.begin_I2C()) {
    Serial.println("Error");
    while (1);
  }

  for(int x=0; x < 6; x++){
    mcp.pinMode(x, INPUT_PULLUP);
    lastButtonState[x] = mcp.digitalRead(x);
  }



  Joystick.begin();

  stepper.setSpeed(200);
}

void loop() {
  while(Serial.available()){
    String msg = Serial.readString();
    stepper.step(msg.toInt());
  }

    

  
  for (int i = 0; i < 6; i++)
  {
//    Serial.print(String(mcp.digitalRead(i)) + " - " + String(lastButtonState[i]) + " | ");

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

}
