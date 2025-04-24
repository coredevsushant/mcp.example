# 🧠 MCP Web API Example with .NET

This repository contains a simple `.NET`-based **MCP Server and Web API** integration that demonstrates how to build and connect an API to **Claude (Anthropic)** using **Model Context Protocol (MCP)** via `stdio`.

---

## 📂 Projects

- `MCP.Server` - The bridge server that connects Claude to your backend logic using MCP.
- `MCP.WebApi` - A simple ASP.NET Core Web API exposing weather forecast data.

---

## ✅ Requirements

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- [Claude Desktop App](https://www.anthropic.com/index/claude) (from Anthropic)
- Git & CLI

---

## 🚀 How to Run This with Claude Desktop

### 1. Clone the Repo

```bash
git clone https://github.com/yourusername/MCP.WebApi.Example.git
cd MCP.WebApi.Example
```

> Make sure the project structure remains intact:
>
> ```
> MCP.Server/
> MCP.WebApi/
> ```

---

### 2. Configure Claude

1. Open Claude Desktop App.
2. Go to `File → Settings → Developer → Edit Config → claude_desktop_config.json`.
3. Replace it with the following:

```json
{
    "inputs": [],
    "mcpServers": {
        "weather": {
            "type": "stdio",
            "command": "dotnet",
            "args": [
                "run",
                "--project",
                "D:/MCP.example/MCP.Server",
                "--no-build"
            ]
        }
    }
}
```

> ✅ Make sure to update the `--project` path above to point to your local path for `MCP.Server`.

---

### 3. Restart Claude Desktop

Once the config is updated, restart Claude Desktop. It should automatically pick up the `weather` MCP server.

---

### 4. Test it!

Ask Claude:
```
Get weather forecast
```
Claude will call your API using the MCP Server and return 5 randomized forecasts.

Then try:
```
create new weather entry for 1 May 2025 as temperature will be 30 and it will be very hot
```
Then try:
```
what will be temparature for 1 may
```


---

## 📌 Notes

- The `MCP.Server` communicates with the `MCP.WebApi` via HTTP under the hood.
- You can extend the API to support `POST`, `PUT`, etc., and Claude will pick up those too (if described in your OpenAPI spec).
- This is a great starter template to build your own Claude-interactive backends.

---

## 🤝 Contributing

PRs are welcome! Feel free to fork and extend.

---

## 🧠 Inspired by

Anthropic’s Model Context Protocol + .NET 💡  
Built by [Sushant](https://www.linkedin.com/in/coredevsushant/)

---

