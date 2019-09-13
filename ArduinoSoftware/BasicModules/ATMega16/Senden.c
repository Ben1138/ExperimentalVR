// ** ATMEGA16 C-Language File **

// When compiling this file use device ATMEGA16

#include <C:/avr/include/avr/io.h>
#include <C:/avr/include/stdlib.h>
#include <C:/avr/include/avr/interrupt.h>
#include <C:/avr/include/util/delay.h>
#include <C:/avr/include/avr/signal.h>
#include <C:/avr/include/util/lcd.h>


//	Author	:	Gruppe Jaisfeld
//	Company	:	FH-Gelsenkirchen
//	Date	:	24.06.2009
//	Comment	:


// Begin of Main-Function

#define BAUD 2400
#define MYUBRR F_CPU/16/BAUD-1

void USART_Init (unsigned int ubrr)
	{
	// set baud rate
	UBRRH = (unsigned char) (ubrr>>8);
	UBRRL = (unsigned char) ubrr;
	// Enable receiver ans transmitter
	UCSRB = (1<<RXEN)|(1<<TXEN) | (1<<RXCIE);
	// Set frame format: 8data, 2stop bit
	UCSRC = (1<<URSEL)|(1<<USBS)|(3<<UCSZ0);
	}

// Send data
void USART_Transmit (unsigned char data)
	{
	// Wait for empty transmit buffer
	while (!(UCSRA & (1<<UDRE)));
	// Put data into buffer, send the data
	UDR = data;
	}

void main (void)
	{
	//INIT of port A
	PORTA=0x00;
	DDRA=0x00;
	//INIT of port B
	PORTB=0x00;
	DDRB=0x00;
	//INIT of port C
	PORTC=0x00;
	DDRC=0x00;
	//INIT of port D
	PORTD=0xFF;
	DDRD=0xFF;

	USART_Init (MYUBRR);

	while(1)
		{
		USART_Transmit(0b10101010);
		_delay_ms(5000);
		}
	}
