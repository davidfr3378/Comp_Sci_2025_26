import random
import math

# ----------------------------
# ACTIVATION FUNCTION
# ----------------------------

# Sigmoid squishes any number into a range between 0 and 1.
# We use it so the neuron can make a "probability-like" prediction.
def sigmoid(x):
    return 1 / (1 + math.exp(-x))

# Derivative of sigmoid, needed for learning (gradient descent).
def sigmoid_deriv(x):
    s = sigmoid(x)
    return s * (1 - s)

# ----------------------------
# TRAINING DATA GENERATOR
# ----------------------------

# This function makes a random number and sets its label:
# even → 0, odd → 1.
def generate_sample():
    x = random.randint(0, 19)   # Pick a random number between 0 and 19
    target = x % 2              # Even → 0, Odd → 1
    return x, target            # Return the number + correct answer

# ----------------------------
# MODEL PARAMETERS (WHAT WE LEARN)
# ----------------------------

# A neuron has a weight and a bias.
# These start random and will adjust during training.
w = random.uniform(-1, 1)       # Weight (multiplies the input)
b = random.uniform(-1, 1)       # Bias (shifts the output)

# The learning rate controls how big each correction step is.
lr = 0.1

print("Even/Odd Learning — Press Enter to train once, or type q to quit.\n")

# ----------------------------
# TRAINING LOOP (MANUAL STEP)
# ----------------------------

while True:
    # Wait for user input (this prevents timeouts)
    user = input("Press Enter to train once (or type q to quit): ")

    # Quit if user types "q"
    if user.lower() == "q":
        break

    # Get one random training example (x, correct answer)
    x, target = generate_sample()

    # ----------------------------
    # FORWARD PASS (Make a prediction)
    # ----------------------------

    z = w * x + b          # Multiply input by weight and add bias
    pred = sigmoid(z)      # Pass through sigmoid → gives prediction between 0 and 1

    # ----------------------------
    # ERROR CALCULATION
    # ----------------------------

    error = pred - target  # Difference between guess and correct answer

    # ----------------------------
    # BACKPROP (Learning step)
    # ----------------------------

    # How much the neuron output changes based on error
    dz = error * sigmoid_deriv(z)

    # Adjust the weight and bias to reduce future error
    w -= lr * dz * x       # Weight update
    b -= lr * dz           # Bias update

    # ----------------------------
    # PRINT RESULTS
    # ----------------------------

    print(f"Number: {x}   Target (correct): {target}")
    print(f"Prediction (0=even,1=odd): {round(pred, 4)}")
    print(f"Error: {round(error, 4)}")
    print(f"Weight: {round(w, 3)}   Bias: {round(b, 3)}\n")
