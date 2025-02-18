package com.agile.calculator;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.junit.jupiter.api.Assertions.assertThrows;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

class CalculatorTest {
    private Calculator calculator;

    @BeforeEach
    void setUp() {
        calculator = new Calculator();
    }

    @Test
    void testSubtract_ValidInput() {
        assertEquals(3, calculator.subtract("8,5"));
    }

    @Test
    void testSubtract_InvalidInput() {
        assertEquals(-9999, calculator.subtract("8,a"));
    }

    @Test
    void testMultiply_ValidInput() {
        assertEquals(40, calculator.multiply("8,5"));
    }

    @Test
    void testMultiply_InvalidInput() {
        assertEquals(-9999, calculator.multiply("8,x"));
    }

    @Test
    void testDivide_ValidInput() {
        assertEquals(4, calculator.divide("8,2"));
    }

    @Test
    void testDivide_DivisionByZero() {
        assertThrows(ArithmeticException.class, () -> calculator.divide("8,0"));
    }

    @Test
    void testDivide_InvalidInput() {
        assertEquals(-9999, calculator.divide("8,z"));
    }

    @Test
    void testDivide_DifferentSeparator() {
        assertEquals(5, calculator.divide("10,2")); 
}
}
