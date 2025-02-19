package com.qa.core;

public class Calculator {
	private int answer;

	public Calculator() {
		this.answer = 0;
	}

	public void addTwoNumber(int x, int y) {
		this.answer = x + y;
	}

	public int getresult() {
		return this.answer;
	}

	public void subtractTwoNumbers(int x, int y) {
		this.answer = y - x; // Correcting the order
	}


	public void multiplyTwoNumbers(int x, int y) {
		this.answer = x * y;
	}

}