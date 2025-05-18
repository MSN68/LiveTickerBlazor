# 📡 Real-Time Market Data with SignalR & Blazor Server (.NET 8)

A simple yet robust example of using **ASP.NET Core SignalR** to push real-time market updates to a **Blazor Server** client.

---

## 🛠️ Features

- ✅ Stable SignalR connection
- ✅ Real-time data broadcasting with `BackgroundService`
- ✅ Clean Blazor Server client integration
- ✅ Built with .NET 8
- ✅ Automatic reconnect
- ✅ Easy to extend

---

## 🚀 Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/MSN68/LiveTickerBlazor.git
cd Signalr

### 2. Build and Run the Server
cd SignalRServer
dotnet run


### 3. Run the Blazor Client

In another terminal:
cd SignalRClientBlazor
dotnet run

Make sure both apps are running. Open the Blazor client in your browser, and you should start seeing real-time market data.

📂 Project Structure

├── SignalRServer/               # ASP.NET Core Server (SignalR Hub + BackgroundService)
│   └── TestHub.cs
│   └── MessageSenderService.cs
│   └── Program.cs
│
├── SignalRClientBlazor/         # Blazor Server App (client)
│   └── Pages/
│       └── Home.razor
│   └── Services/
│       └── MarketHubClient.cs
│   └── Program.cs
│
├── README.md
├── .gitignore
└── LICENSE


🔐 Security / Authentication (Optional)

You can easily add:

    JWT or API Key authentication

    Connection authorization on the hub

    Role-based access for different users

This sample is kept simple for clarity.

📜 License

This project is licensed under the MIT License.

🙌 Contributing

Pull requests are welcome! For major changes, please open an issue first.


✨ Credits

Made with ❤️ by Mohammad Salehi
