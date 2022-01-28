#include <Servo.h>

Servo servo;

String msg;

void setup() {
  Serial.begin(115200);  
  servo.attach(9);
  Serial.setTimeout(10);
}

void loop() {
  // put your main code here, to run repeatedly:
  while(Serial.available()){
    msg = Serial.readString();
    servo.write(msg.toInt());
  }
}
