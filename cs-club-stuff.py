import math
import random

# ----------------------------------------------------------
# ACTIVATION FUNCTION + DERIVATIVE
# ----------------------------------------------------------

# Sigmoid squishes any number into the range (0, 1)
def sigmoid(x):
    return 1 / (1 + math.exp(-x))

# Derivative of sigmoid (used for learning/backprop)
# NOTE: this version takes the output of sigmoid as input (y)
def dsigmoid(y):
    return y * (1 - y)


# ----------------------------------------------------------
# TRAINING DATA FOR XOR
# ----------------------------------------------------------

# XOR truth table:
# 0 xor 0 = 0
# 0 xor 1 = 1
# 1 xor 0 = 1
# 1 xor 1 = 0
data = [
    ([0, 0], 0),
    ([0, 1], 1),
    ([1, 0], 1),
    ([1, 1], 0)
]


# ----------------------------------------------------------
# INITIALIZE WEIGHTS
# ----------------------------------------------------------

# Our network has:
# - 2 inputs
# - 2 hidden neurons
# - 1 output neuron

# Hidden layer weights: w1[neuron][input]
w1 = [
    [random.random(), random.random()],  # hidden neuron 1
    [random.random(), random.random()]   # hidden neuron 2
]

# Hidden layer biases
b1 = [random.random(), random.random()]

# Output layer weights (one per hidden neuron)
w2 = [random.random(), random.random()]

# Output layer bias
b2 = random.random()

# Learning rate
lr = 0.5


# ----------------------------------------------------------
# TRAINING PHASE
# ----------------------------------------------------------

for epoch in range(5000):
    for x, target in data:

        # ------------------------------
        # FORWARD PASS
        # ------------------------------

        # Hidden activations
        h = [0, 0]
        for i in range(2):
            h[i] = sigmoid(
                w1[i][0] * x[0] +
                w1[i][1] * x[1] +
                b1[i]
            )

        # Output activation
        out = sigmoid(h[0] * w2[0] + h[1] * w2[1] + b2)

        # ------------------------------
        # ERROR
        # ------------------------------
        error = target - out

        # ------------------------------
        # BACKPROPAGATION
        # ------------------------------

        # Output gradient
        d_out = error * dsigmoid(out)

        # Output layer weight adjustments
        d_w2 = [
            d_out * h[0],
            d_out * h[1]
        ]

        # Output bias adjustment
        d_b2 = d_out

        # Hidden layer gradients
        d_h = [
            d_out * w2[0] * dsigmoid(h[0]),
            d_out * w2[1] * dsigmoid(h[1])
        ]

        # ------------------------------
        # UPDATE WEIGHTS & BIASES
        # ------------------------------

        # Update output weights
        for i in range(2):
            w2[i] += lr * d_w2[i]

        # Update output bias
        b2 += lr * d_b2

        # Update hidden layer weights & biases
        for i in range(2):
            b1[i] += lr * d_h[i]
            for j in range(2):
                w1[i][j] += lr * d_h[i] * x[j]


# ----------------------------------------------------------
# TESTING PHASE
# ----------------------------------------------------------

print("XOR Results:")

for x, _ in data:
    # Hidden layer forward pass
    h = [
        sigmoid(w1[i][0] * x[0] + w1[i][1] * x[1] + b1[i])
        for i in range(2)
    ]
    
    # Output layer forward pass
    out = sigmoid(h[0] * w2[0] + h[1] * w2[1] + b2)

    print(f"{x} → {out:.4f}")
