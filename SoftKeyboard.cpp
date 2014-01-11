#include "Arduino.h"
#include "SoftKeyboard.h"

SoftKeyboard::SoftKeyboard()
{
	_buffer = new char[64];
}

void SoftKeyboard::press(int keyCode)
{
	sprintf(_buffer, "sk 1 %d", keyCode);
	Serial.println(_buffer);
}

void SoftKeyboard::release(int keyCode)
{
	sprintf(_buffer, "sk 2 %d", keyCode);
	Serial.println(_buffer);
}

void SoftKeyboard::tap(int keyCode)
{
	sprintf(_buffer, "sk 3 %d", keyCode);
	Serial.println(_buffer);
}
