/*
SoftKeyboard.h - a software keyboard library for Arduino
Must be used with the corresponding SoftKeyboard.exe installed on the PC
*/
#ifndef SoftKeyboard_h
#define SoftKeyboard_h

#include "Arduino.h"

class SoftKeyboard
{
	public:
		SoftKeyboard();
		void press(int keyCode);
		void release(int keyCode);
		void tap(int keyCode);
		//void releaseAll();

	private:
		char* _buffer;
};



#endif