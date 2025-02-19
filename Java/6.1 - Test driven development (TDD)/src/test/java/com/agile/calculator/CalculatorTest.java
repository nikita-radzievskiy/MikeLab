package com.agile.calculator;

import static org.junit.Assert.assertEquals;

import org.junit.Before;
import org.junit.Test;

public class CalculatorTest {

	private Calculator calculator;

	@Before
	public void setUp() {
		calculator = new Calculator();
	}

	@Test
	public void add_EmptyString_ShouldReturnZero() {
		assertEquals(0, calculator.add(""));
	}

	@Test
	public void add_SingleNumber_ShouldReturnNumber() {
		assertEquals(5, calculator.add("5"));
	}

	@Test
	public void add_TwoNumbersSeparatedByComma_ShouldReturnSum() {
		assertEquals(10, calculator.add("3,7"));
	}

	@Test
	public void add_TwoNumbersSeparatedByNewline_ShouldReturnSum() {
		assertEquals(10, calculator.add("3\n7"));
	}

	@Test
	public void add_ThreeNumbersSeparatedByCommaOrNewline_ShouldReturnSum() {
		assertEquals(6, calculator.add("1,2\n3"));
	}

	@Test(expected = IllegalArgumentException.class)
	public void add_NegativeNumbers_ShouldThrowException() {
		calculator.add("-1,2,-3");
	}
}
