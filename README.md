# ConvoSphere: 3D GPT Chat with Avatars

**ConvoSphere** is an immersive 3D multiplayer chat application that allows users to interact with GPT-powered avatars. This app brings together natural language processing with 3D avatar interactions, enabling dynamic, AI-driven conversations within a shared virtual environment.

---

## 🚀 Features

- **3D Multiplayer Chat**: Communicate with other users in a virtual world.
- **GPT-3.5 Powered Avatars**: Engage in intelligent conversations with AI-powered avatars based on OpenAI's GPT-3.5 model. (It uses the Free-tier, so it can fill up it's quota pretty fast)
- **Customizable Avatars**: Users can choose from a variety of Mixamo avatars for their characters. (Currently only 1 Avatar due to time constraint)
- **Chat Interface**: A text-based conversation UI where users can send and receive messages.
- **Emotive Avatar Reactions**: Avatars display emotions like smiling or waving based on the conversation.
- **Voice Chat (Optional)**: Use a Text-to-Speech (TTS) plugin to have the AI avatars speak their responses. (Couldn't implement due to time constraint)

---

## Demo Video: https://youtu.be/craMH1rWMTg

---

## Note: 

-  **This project uses the Free-tier OpenAI API, which has a limited usage quota. Once the quota is reached, the chatbot functionality may stop working until it resets.**

---

## 🛠️ Getting Started

Follow these steps to set up and run the app:

### ✅ Prerequisites

- **Unity 2023.1 or higher**: [Download Unity](https://unity.com/)
- **Photon PUN (Photon Unity Networking)**: [Photon Engine](https://www.photonengine.com/en-US/PUN)
- **Text-to-Speech Plugin (Optional)**: Use RT-Voice, Azure TTS, or Google Cloud TTS (Couldn't implement due to time constraint)

---

### 📦 Installation Steps

#### 1. Clone or Download the Repository

```bash
git clone https://github.com/rajarsheya/ConvoSphere-3D-GPT-Chat-with-Avatars.git
```

#### 2. Open the Project in Unity

- Launch **Unity Hub**
- Open the downloaded folder as a Unity project

#### 3. Import Photon PUN

- Open **Unity Asset Store**
- Search and import **Photon PUN 2 - Free**
- Navigate to `Window > Photon Unity Networking > Highlight PhotonServerSettings`
- Enter your **Photon App ID** from the [Photon Dashboard](https://dashboard.photonengine.com/)

#### 4. Import Necessary Assets

- Download and import **Mixamo Avatars** from [Mixamo](https://www.mixamo.com/)
- *(Optional)* Import your preferred **TTS Plugin** (e.g., RT-Voice, Azure, Google TTS) (Couldn't implement due to time constraint)
- In GPTChat.cs script, add the OpenAI API Key which you have.

#### 5. Set Up Scene Files

- Open **Login** scene for Logging in with your name
- Open **Lobby** scene for room creation and matchmaking
- Open **Game** scene for multiplayer chat and interaction
- Ensure:
  - `LoginManager.cs` is in the Lobby scene
  - `LobbyManager.cs` is in the Lobby scene
  - `GameManager.cs` is in the Game scene

#### 6. Configure Photon Settings

In `PhotonServerSettings`:

- ✅ Enable **Auto-Join Lobby**
- ✅ Enable **Automatically Sync Scene**
- Set your **Photon Nickname** and default **Room Name** if needed

In `Assets > Photon > PhotonUnityNetworking > Resources > PhotonServerSettings`
- ✅ Add the **App Id PUN** from the Photon App ID
---

## ▶️ Running the App

#### 1. Open the Login Scene

Start the app from the **Login** scene.

#### 2. Set Your Username

- The username is saved locally using `PlayerPrefs`.

#### 3. Join or Create a Room from Lobby Scene

- Enter a **room name**
- Click **Join Room** to enter or create that room

#### 4. Enter the Game Scene

- The **Game** scene loads automatically after joining a room

#### 5. Interact with GPT Avatars

- Type messages into the chat input field
- GPT-powered avatars will respond
- Avatars will react with animations like **Idle** or **Talking**

---

## 🔊 Optional Features 

### Text-to-Speech (TTS) (Couldn't implement due to time constraint)

If you want avatars to speak, integrate a TTS plugin like RT-Voice, Azure TTS, etc.

Example (RT-Voice):

```csharp
RTVoice.Speak(content); // Or your plugin's equivalent
```

---

## ⚠️ Known Limitations

- ❌ **No Speech-to-Text (STT)**: Speech recognition is not implemented
- 😐 **Simple Emotions**: Only basic reactions like smile or wave
- 👥 **Room Limit**: Max 3 players per room

---

## 🔮 Future Improvements

- 🗣️ Add **Speech-to-Text (STT)** for voice input
- 😲 Enhance emotional reactions for avatars
- 👨‍👩‍👧‍👦 Support **more users per room**

---

## ✨ Credits

- **OpenAI GPT-3.5 API** – for natural language generation  
- **Photon PUN** – for multiplayer networking  
- **Mixamo** – for animated avatars  
- **Unity** – game engine  
- Optional: **TTS Plugins** (RT-Voice, Azure, etc.) (Couldn't implement due to time constraint)
