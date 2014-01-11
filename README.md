soft-keyboard
=============

Software _only_ keyboard emulator for Arduino.

This library will emulate (with the provided SoftKeyboardReceiver.zip) a windows keyboard. Full list of keycodes can be found here:
http://msdn.microsoft.com/en-us/library/windows/desktop/dd375731(v=vs.85).aspx

Usage:
* Download and install the Arduino library (details here http://arduino.cc/en/Guide/Libraries)
* Open the SoftKeyboard example sketch and upload it to the Arduino
* Unpack the provided SoftKeyboardReceiver.zip on your PC and run it giving the Arduino serial port as an argument
* Open notepad, and you should be getting "hi!" string typed every 2 seconds
