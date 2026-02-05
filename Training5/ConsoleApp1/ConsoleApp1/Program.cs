double CalculateSalary(double hoursWorked,
double hourlyRate)
{
	double regularHours = Math.Min(hoursWorked, 40);
	double overtimeHours = Math.Max(0, hoursWorked - 40);
	double regularPay = regularHours * hourlyRate;
	double overtimePay = overtimeHours * hourlyRate * 1.5;
	return regularPay + overtimePay;
}

double hours = 45;
double rate = 200;
double totalSalary = CalculateSalary(hours,rate);

Console.WriteLine($"Total lön:{totalSalary}kr");