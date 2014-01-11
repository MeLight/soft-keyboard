/*
This is an example of how to use the SoftKeyboard library.
You will also need the SoftKeyboard.exe to run on your PC to accept the keyboard events sent by the Arduino.
Source code can be found here:
https://github.com/MeLight/soft-keyboard

*/

#include <SoftKeyboard.h>

SoftKeyboard sk;

void setup() {
  Serial.begin(9600);  //Must init Serial in order for SoftKeyboard to work!
}

void loop() {
  sk.tap(0x48);      //tap 'h'
  sk.tap(0x49);      //tap 'i'
  sk.press(0x10);    //hold Shift down
  sk.tap(0x31);      //tap '1' (with shift makes it '!')
  sk.release(0x10);  //release Shift
  delay(2000);
}
