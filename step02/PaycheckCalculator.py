
# Name: Gavin Waibel
# Date: 2026 - 11 - 11
# Program: Step 2 - Paycheck Calculator
# Description: input name and info and output a paystub
# Input: Employee name, hourly pay rate, hours worked this week

FEDERAL_TAX_RATE = 0.10
STATE_TAX_RATE = 0.035
SOCIAL_SECURITY_RATE = 0.062
MEDICARE_RATE = 0.0145
WEEKS_PER_YEAR = 52


name = input("Employee name: ")
hourly_rate = float(input("Hourly pay rate: "))
hours_worked = float(input("Hours worked this week: "))


gross_pay = hourly_rate * hours_worked
federal_tax = gross_pay * FEDERAL_TAX_RATE
state_tax = gross_pay * STATE_TAX_RATE
social_security_tax = gross_pay * SOCIAL_SECURITY_RATE
medicare_tax = gross_pay * MEDICARE_RATE

total_taken_out = federal_tax + state_tax + social_security_tax + medicare_tax
net_pay = gross_pay - total_taken_out
percent_kept = (net_pay / gross_pay) * 100


yearly_gross = gross_pay * WEEKS_PER_YEAR
yearly_net = net_pay * WEEKS_PER_YEAR

print()
print("=" * 32)
print(f"PAY STUB: {name}")
print("=" * 32)
print(f"Hours worked:      {hours_worked:.1f}")
print(f"Hourly rate:       ${hourly_rate:.2f}")
print(f"Gross pay:         ${gross_pay:.2f}")
print("-" * 32)
print(f"Federal tax (10%): ${federal_tax:.2f}")
print(f"State tax (3.5%):  ${state_tax:.2f}")
print(f"Social Security:   ${social_security_tax:.2f}")
print(f"Medicare:          ${medicare_tax:.2f}")
print(f"Total taken out:   ${total_taken_out:.2f}")
print("-" * 32)
print(f"NET PAY:           ${net_pay:.2f}")
print("=" * 32)
print(f"You keep {percent_kept:.1f}% of what you earn.")
print(f"Yearly gross: ${yearly_gross:.2f}")
print(f"Yearly net:   ${yearly_net:.2f}")
