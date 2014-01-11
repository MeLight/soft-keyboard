soft-keyboard
=============

Software _only_ keyboard emulator for Arduino.

This library will emulate (with the provided SoftKeyboardReceiver.zip) a windows keyboard. Full list of keycodes can be found here:
http://msdn.microsoft.com/en-us/library/windows/desktop/dd375731(v=vs.85).aspx

Usage:
* Download and install the Arduino library (official guide here http://arduino.cc/en/Guide/Libraries)
  * create a SoftKeyboard directory in your Arduino\libraries directory
  * unpack the .zip you've downloaded, and copy everything from soft-keyboard-master directory to Arduino\libraries\SoftKeyboard
* Restart the Arduino IDE
* Open the SoftKeyboard example sketch and upload it to the Arduino
* Run the provided SoftKeyboard.exe on your PC, giving the Arduino serial port as an argument
* Open notepad, and you should be getting "hi!" string typed every 2 seconds
