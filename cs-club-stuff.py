import math
import random

# ----------------------------------------------------------
# CONFIGURATION
# ----------------------------------------------------------
random.seed(42)  # Fixed seed for reproducibility

# ----------------------------------------------------------
# ACTIVATION FUNCTION + DERIVATIVE
# ----------------------------------------------------------

def sigmoid(x):
    # Prevents overflow errors for very large negative x
    if x < -709: return 0 
    return 1 / (1 + math.exp(-x))

def dsigmoid(y):
    # 'y' is the already activated value
    return y * (1 - y)

# ----------------------------------------------------------
# TRAINING DATA FOR XOR
# ----------------------------------------------------------
data = [
    ([0,0], 0),
    ([0,1], 1),
    ([1,0], 1),
    ([1,1], 0)
]

# ----------------------------------------------------------
# INITIALIZE WEIGHTS
# ----------------------------------------------------------
# FIX: Use random.uniform(-1, 1) instead of random.random()
# XOR requires negative weights to create separation boundaries.

# Hidden layer weights (2 neurons, 2 inputs each)
w1 = [
    [random.uniform(-1, 1), random.uniform(-1, 1)], 
    [random.uniform(-1, 1), random.uniform(-1, 1)]  
]

# Hidden layer biases
b1 = [random.uniform(-1, 1), random.uniform(-1, 1)]

# Output layer weights (1 neuron, 2 inputs from hidden layer)
w2 = [random.uniform(-1, 1), random.uniform(-1, 1)]

# Output layer bias
b2 = random.uniform(-1, 1)

lr = 0.5

# ----------------------------------------------------------
# TRAINING PHASE
# ----------------------------------------------------------
[attachment_0](attachment)

print("Training...")
for epoch in range(10000): # Increased epochs slightly for stability
    for x, target in data:

        # --- FORWARD PASS ---
        h = [0, 0]
        for i in range(2):
            h[i] = sigmoid(w1[i][0]*x[0] + w1[i][1]*x[1] + b1[i])

        out = sigmoid(h[0]*w2[0] + h[1]*w2[1] + b2)

        # --- ERROR ---
        error = target - out

        # --- BACKPROPAGATION ---
        
        # 1. Output Gradient
        d_out = error * dsigmoid(out)

        # 2. Calculate gradients for Output Weights (don't update yet)
        d_w2 = [d_out * h[0], d_out * h[1]]
        d_b2 = d_out

        # 3. Calculate gradients for Hidden Layer (Passing error back)
        # Note: We use the *current* w2 weights before updating them
        d_h = [
            d_out * w2[0] * dsigmoid(h[0]),
            d_out * w2[1] * dsigmoid(h[1])
        ]

        # --- UPDATE WEIGHTS ---
        
        # Update Output Layer
        for i in range(2):
            w2[i] += lr * d_w2[i]
        b2 += lr * d_b2

        # Update Hidden Layer
        for i in range(2):
            b1[i] += lr * d_h[i]
            for j in range(2):
                w1[i][j] += lr * d_h[i] * x[j]

# ----------------------------------------------------------
# TESTING PHASE
# ----------------------------------------------------------
print("\nResults after training:")
print(f"{'Input':<10} | {'Target':<8} | {'Prediction':<10}")
print("-" * 35)

for x, target in data:
    # Recompute hidden
    h = [sigmoid(w1[i][0]*x[0] + w1[i][1]*x[1] + b1[i]) for i in range(2)]
    # Recompute output
    out = sigmoid(h[0]*w2[0] + h[1]*w2[1] + b2)
    
    print(f"{str(x):<10} | {target:<8} | {out:.5f}")
