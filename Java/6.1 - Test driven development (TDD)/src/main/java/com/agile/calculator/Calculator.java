package com.agile.calculator;

public class Calculator {

	public int add(String numbers) {
		if (numbers.isEmpty()) {
			return 0;
		}

		String[] splitNumbers = numbers.split("[,\n]");
		int sum = 0;
		StringBuilder negatives = new StringBuilder();

		for (String num : splitNumbers) {
			int number = Integer.parseInt(num.trim());

			// Check for negative numbers
			if (number < 0) {
				if (negatives.length() > 0) {
					negatives.append(", ");
				}
				negatives.append(number);
			}

			sum += number;
		}

		// If negatives exist, throw exception
		if (negatives.length() > 0) {
			throw new IllegalArgumentException("Negative numbers not allowed: " + negatives);
		}

		return sum;
	}
}
