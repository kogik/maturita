

#include <CheapStepper.h>


CheapStepper stepper;


String msg;
float pos;
float speed;
float final;

void setup() {

  Serial.begin(9600);
  
  
  pinMode(12, INPUT_PULLUP);

  delay(1000);


  while(digitalRead(12)){
    stepper.move(true, 20);
  }

  
  stepper.move(false, 100);
}

void loop() {

  
  while(Serial.available()){
    msg = Serial.readString();
    speed = msg.toFloat();
    if(speed < 120){
      final = (speed < 20) ?  map(speed,0,20,0,300) : map(speed,20,120,300,2850);
      (final > pos) ? stepper.move(false, final-pos) : stepper.move(true, pos-final);
      pos = final;      
    }else{
      Serial.println(" > 120"); 
    }
      
  }

 
}



float map(float s, float a1, float a2, float b1, float b2)
{
  return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
}
