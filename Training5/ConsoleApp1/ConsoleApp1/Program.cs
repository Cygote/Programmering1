double CalculateSalary(double hoursWorked, double hourlyRate, double overtimeFactor = 1.5)
{
	double regularHours = Math.Min(hoursWorked, 40);
	double overtimeHours = Math.Max(0, hoursWorked - 40);
	double regularPay = regularHours * hourlyRate;
	double overtimePay = overtimeHours * hourlyRate * overtimeFactor;

	return regularPay + overtimePay;
}

double hours = 45;
double rate = 200;
double totalSalary = CalculateSalary(hours,rate);

Console.WriteLine($"Total lön:{totalSalary}kr");
