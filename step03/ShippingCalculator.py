# Name: Gavin Waibel
# Date: 2026 - 11 - 12
# Program: Step 3: Shipping Calculator
# Description: Figures out shipping cost and delivery time

# Constants
ZONE1_RATE = 0.50  # Per lb
ZONE2_RATE = 0.75  # Per lb
ZONE3_RATE = 1.25  # Per lb
MINIMUM_SHIPPING = 4.00
FREE_SHIPPING_AMOUNT = 50.00
RUSH_FEE = 10.00

# Input
order_total = float(input("Order total: "))
pack_weight = float(input("Package weight (lbs): "))
ship_zone = int(input("Shipping zone (1-3): "))
rush = input("Rush delivery? (y/n): ")

# Processing
if order_total <= 0 or pack_weight <= 0:
    print("Error: order total and weight must be more than 0.")
elif ship_zone != 1 and ship_zone != 2 and ship_zone != 3:
    print("Error: zone must be 1, 2, or 3.")
else:
    is_rush = rush.lower() == "y"

    # Rule 1: Zone rate and standard delivery days
    if ship_zone == 1:
        shipping = pack_weight * ZONE1_RATE
        shipping_time = 2
    elif ship_zone == 2:
        shipping = pack_weight * ZONE2_RATE
        shipping_time = 4
    else:
        shipping = pack_weight * ZONE3_RATE
        shipping_time = 6

    # Rule 2: Minimum shipping
    if shipping < MINIMUM_SHIPPING:
        shipping = MINIMUM_SHIPPING

    # Rule 3: Free shipping
    if order_total >= FREE_SHIPPING_AMOUNT and not is_rush:
        shipping = 0.0

    # Rule 4: Rush delivery
    if is_rush:
        shipping = shipping + RUSH_FEE
        if ship_zone == 1 or ship_zone == 2:
            shipping_time = 1
        else:
            shipping_time = 2

    # Rule 5: Heavy package
    if pack_weight > 50:
        shipping_time = shipping_time + 2

    total_cost = order_total + shipping

    # Output
    print()
    print("--- Shipping Summary ---")
    print(f"Order total:  ${order_total:.2f}")

    if shipping == 0:
        print("Shipping:     FREE")
    else:
        print(f"Shipping:     ${shipping:.2f}")

    print(f"Grand total:  ${total_cost:.2f}")

    if shipping_time == 1:
        print("Arrives in:   1 day")
    else:
        print(f"Arrives in:   {shipping_time} days")

    if pack_weight > 50:
        print("Note: heavy package, 2 extra days added.")


    
