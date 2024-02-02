import random


def generate_dice_rolls(n, seed=0):
    random.seed(seed)
    return [random.randint(1, 6) for _ in range(n)]


# Example usage
n_rolls = 1000  # Number of dice rolls
dice_rolls = generate_dice_rolls(n_rolls)

def count_occurrences ( dice_rolls , number ) :
    count = 0
    for i in dice_rolls:
        if(i == number):
            count+=1
            
    return count
    
def calculate_probability ( dice_rolls , number ) :
    return count_occurrences ( dice_rolls , number )/len(dice_rolls)
    
    
number_of_interest = 4
# occurrences = count_occurrences ( dice_rolls , number_of_interest )
probability = calculate_probability ( dice_rolls , number_of_interest )

print(dice_rolls, probability)

# assert occurrences == 193