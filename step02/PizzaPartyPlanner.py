# Name: Gavin Waibel
# Date: 2026 - 11 - 9
# Program: Step 2: Pizza Planner
# Description: Write a program that plans the pizza for a party: how many whole pizzas, how many extra slices, and what it costs.
# Input: Hosts Name, number of people, and slices per person

#Const variables
SLICES_PER_PIZZA = 8
PIZZA_PRICE = 12.99
SLICE_PRICE = 2.25

print("Pizza Party Planner:")
host_name = input("Host name: ")
num_people = int(input("Number of people: "))
slice_per_person = int(input("Slices per person: "))
total_slices = num_people * slice_per_person
whole_pizzas = total_slices // SLICES_PER_PIZZA
extra_slices = total_slices % SLICES_PER_PIZZA
total_cost = (whole_pizzas * PIZZA_PRICE) + (extra_slices * SLICE_PRICE)
cost_per_person = total_cost / num_people

print(f"=== Pizza Plan for {host_name}'s Party ===")
print("Slices needed:\t" + str(total_slices))
print("Whole pizzas:\t" + str(whole_pizzas))
print("Extra Slices:\t" + str(extra_slices))
print("Total Cost:\t" + str(total_cost))
print(f"Cost Per Person:\t{cost_per_person:.2f}")
