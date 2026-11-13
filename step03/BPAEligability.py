# Name: Gavin Waibel
# Date: 2026 - 11 - 13
# Program: Step 3 - BPA Eligability
# Description: Check whether or not a student can participate in BPA
# Input: Name, Grade, GPA, Dues, Events Number


MIN_GPA = 2.0
OFFICER_GPA = 3.0
HONOR_GPA = 3.5
MAX_EVENTS = 2

name = input("Member name: ")
grade = int(input("Grade (9-12): "))
gpa = float(input("GPA (0.0-4.0): "))
dues_input = input("Dues paid? (y/n): ").strip().lower()
events = int(input("Events signed up for: "))

if grade < 9 or grade > 12:
    print("Error: grade must be 9 to 12.")
elif gpa < 0.0 or gpa > 4.0:
    print("Error: GPA must be 0.0 to 4.0.")
else:
    dues_paid = dues_input == "y"
    eligible = dues_paid and gpa >= MIN_GPA

    # Output
    print(f"\n--- BPA Check for {name} ---")

    if eligible:
        print("Status: ELIGIBLE")
        if events == 0:
            print("Sign up for at least one event.")
        elif events == 1:
            print("You are entered in 1 event.")
        elif events == MAX_EVENTS:
            print(f"You are entered in {MAX_EVENTS} events.")
        else:
            extra = events - MAX_EVENTS
            print(f"You can only enter {MAX_EVENTS} events. Drop {extra}.")
    else:
        print("Status: NOT ELIGIBLE")
        if not dues_paid:
            print("Reason: dues not paid.")
        if gpa < MIN_GPA:
            print(f"Reason: GPA is below {MIN_GPA}.")

    if (grade == 11 or grade == 12) and gpa >= OFFICER_GPA:
        print("You can run for chapter office.")

    if grade == 12 and gpa >= HONOR_GPA:
        print("Senior honor cord: yes")
