# 🐉 2D Dragon Adventure Game

A 2D action‑adventure game where the player controls a powerful dragon, explores a stylized world, fights enemies, collects items, and completes objectives while avoiding obstacles. Built with **Unity** using sprite-based visuals, physics, animations, and gameplay scripts.

---

## 🎮 **Game Overview**

The 2D Dragon Adventure Game is designed to give players a simple yet enjoyable experience of controlling a dragon that can move, fly, attack, and interact with the environment. The world is designed with terrains, enemies, collectibles, and obstacles to create engaging gameplay.

---

## 🧩 **Game Features**

* **Dragon Movement**: Smooth 2D movement including walking, flying, and directional animations.
* **Combat System**: Attack animations and hit detection for battling enemies.
* **Obstacles & Terrain**: Trees, rocks, roads, and other environment objects with proper colliders.
* **Collectible Items**: Gems, coins, or orbs that the dragon can pick up.
* **Countdown Timer**: A 10‑second or custom countdown that influences gameplay.
* **Camera Follow System**: Dynamic camera that follows the dragon’s movement.
* **Game UI**: Health bar, score counter, and timer display.

---

## ⚙️ **Technologies Used**

* **Unity Engine (2D)**
* **C# Scripting**
* **Unity Animator** for animations
* **Tilemap / Sprites** for environment design

---

## 🏗️ **Core Mechanics Implemented**

### 1. **Player Movement System**

* Controlled using Rigidbody2D and physics.
* Supports walking, flying, and rotation based on direction.

### 2. **Attack System**

* Custom weapon hitbox
* Ensures attacks do not pass through walls (correct colliders applied)
* Enemy hit detection

### 3. **Environment & Collisions**

* Proper BoxCollider2D & PolygonCollider2D on roads, trees, rocks, and walls.
* Adjusted sorting order for correct layer rendering.

### 4. **Collectibles System**

* Trigger-based collection
* Score increments

### 5. **Game Timer**

* Countdown displayed on UI
* Triggers win/lose conditions

### 6. **Camera Follow Script**

* SmoothFollow script to follow the dragon
* Ensures proper offset & smoothing

---

## 🕹️ **How to Play**

* **Move**: Arrow keys / WASD
* **Fly/Move Up**: W or Up Arrow
* **Attack**: Press Spacebar
* **Collect Items**: Move over collectibles
* **Win Condition**: Survive/collect items before countdown ends

---

## 📦 **Project Structure**

```
Assets/
│── Scripts/
│   ├── PlayerMovement.cs
│   ├── DragonAttack.cs
│   ├── CameraFollow.cs
│   ├── Collectible.cs
│   └── CountdownTimer.cs
│
│── Sprites/
│── Animations/
│── Prefabs/
│── Scenes/
```

---

## 🚀 **How to Run the Game**

1. Install **Unity (2021+ recommended)**
2. Open the project folder in Unity
3. Load the main scene (`MainScene.unity` or equivalent)
4. Press **Play** in Unity Editor

---

## 📝 **Future Improvements**

* Add multiple levels
* Add boss battles
* Add fire-breath ability
* Add health system for enemies
* Create main menu and pause menu

---

## 🏁 **Conclusion**

This project demonstrates the implementation of a complete 2D Unity game using movement mechanics, animations, environment setup, collisions, attacks, collectibles, and UI systems. It serves as a strong foundation for expanding into a more advanced adventure or RPG-style dragon game.

---

## 👤 **Developer**

**Aniket Pratap Singh**

---

## 📜 License

This project is for educational and portfolio purposes.
