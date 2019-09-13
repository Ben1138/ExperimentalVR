/*
 * PWM.c
 * Pulsweitenmodulation
 * 
 * Obwohl das Signal der Pulsweitenmodulation eine Wechselspannung bzw. eher Mischspannung ist,
 * l�sst sich damit die Leistung von Gleichstromverbrauchern wie Leuchtdioden, Motoren,
 * Heizwiderst�nden und �hnliches regulieren. Anstatt diese Bauteile und Komponenten �ber die H�he
 * der Betriebsspannung zu steuern, wird per Pulsweitenmodulation einfach die Spannung bzw. 
 * der Strom f�r eine kurze Zeit unterbrochen. Auf diese Weise entsteht ein bestimmtes Verh�ltnis 
 * zwischen Spannungsimpulsen und -pausen. Das Verh�ltnis entscheidet �ber die Effektivspannung.
 * 
 * Created: 06/08/2019 17:46:08
 *  Author: Richard
 */ 
#define F_CPU 8000000 

#include <avr/io.h>
#include <avr/delay.h>
#include <avr/interrupt.h>

int main(void){
	
	// seite 108 im handbuch
	TCCR0A = (1 << WGM00) | (1 << COM0A1);
	TCCR0B = (1 << CS01); //00000010 clk/8
	DDRD = 0xFF;
	sei();// global interrupt flag
	PORTD = 0b00000000;
	
	while(1)
	{
		for (int i=0; i<=255; i++)
		{
			OCR0A = i; // wo ist das? rx/tx ???
			_delay_ms(10);
		}
		for (int i=255; i>=0; i--)
		{
			OCR0A = i;
			_delay_ms(10);
		}
		
		//OCR0A = 120;
		//_delay_ms(500);
		//OCR0A = 0;
		//_delay_ms(500);
	}
}