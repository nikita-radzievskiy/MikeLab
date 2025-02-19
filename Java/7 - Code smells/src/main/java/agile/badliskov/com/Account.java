package agile.badliskov.com;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

// Abstract base class to enforce common behavior while allowing specific account types
abstract class Account {
	protected String firstName, lastName, address;
	protected int accountNumber;
	protected double balance;

	public Account(String firstName, String lastName, String address, int accountNumber, double initialBalance) {
		this.firstName = firstName;
		this.lastName = lastName;
		this.address = address;
		this.accountNumber = accountNumber;
		this.balance = initialBalance;
	}

	public abstract void withDraw(double amount);

	public void deposit(double amount) {
		if (amount > 0) {
			balance += amount;
		}
	}

	public double getBalance() {
		return balance;
	}
}

// Interface for interest-bearing accounts
interface InterestBearing {
	void addInterest();
}

// Interface for accounts with overdraft capability
interface OverdraftAccount {
	void setOverdraftLimit(double limit);
	boolean isOverDrawn();
}

// DepositAccount follows the InterestBearing behavior
class DepositAccount extends Account implements InterestBearing {
	private static final double INTEREST_RATE = 0.0001;

	public DepositAccount(String firstName, String lastName, String address, int accountNumber, double initialBalance) {
		super(firstName, lastName, address, accountNumber, initialBalance);
	}

	@Override
	public void withDraw(double amount) {
		if (amount <= balance) {
			balance -= amount;
		}
	}

	@Override
	public void addInterest() {
		balance += balance * INTEREST_RATE;
	}
}

// CurrentAccount supports overdraft and payments
class CurrentAccount extends Account implements OverdraftAccount {
	private double overdraftLimit;
	private List<PaymentProcessor> paymentProcessors = new ArrayList<>();

	public CurrentAccount(String firstName, String lastName, String address, int accountNumber, double initialBalance) {
		super(firstName, lastName, address, accountNumber, initialBalance);
	}

	@Override
	public void withDraw(double amount) {
		if (amount <= balance + overdraftLimit) {
			balance -= amount;
		}
	}

	@Override
	public void setOverdraftLimit(double limit) {
		this.overdraftLimit = limit;
	}

	@Override
	public boolean isOverDrawn() {
		return balance < 0;
	}

	// Payment processing abstraction
	public void processPayments() {
		for (PaymentProcessor processor : paymentProcessors) {
			processor.processPayment(this);
		}
	}

	public void addPaymentProcessor(PaymentProcessor processor) {
		paymentProcessors.add(processor);
	}
}

// Interface to handle different types of payments
interface PaymentProcessor {
	void processPayment(CurrentAccount account);
}

// Concrete Payee class to handle payee-related data
class Payee implements PaymentProcessor {
	private String name, address;
	private Date date;
	private double amount;

	public Payee(String name, String address, Date date, double amount) {
		this.name = name;
		this.address = address;
		this.date = date;
		this.amount = amount;
	}

	@Override
	public void processPayment(CurrentAccount account) {
		if (account.getBalance() >= amount) {
			account.withDraw(amount);
		}
	}
}
