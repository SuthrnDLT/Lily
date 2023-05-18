# Lily

Lily is a simple Discord bot that provides a few useful features for the community.

![License](https://img.shields.io/github/license/tacosontitan/Lily?logo=github&style=for-the-badge)

## 💁‍♀️ Getting Started

Get started by reviewing the answers to the following questions:

- [How do I navigate the codebase with confidence?](http://lily.tacosontitan.com)
- [How can I help?](./CONTRIBUTING.md)
- [How should I behave here?](./CODE_OF_CONDUCT.md)
- [How do I report security concerns?](./SECURITY.md)
- [What third-party dependencies are used?](./NOTICES.md)

### ✅ Small changes, continuously integrated

Lily employs workflows for continuous integration to ensure the repository is held to industry standards; here's the current state of those workflows:

![.NET Workflow](https://img.shields.io/github/actions/workflow/status/tacosontitan/Lily/dotnet.yml?label=Build%20and%20Test&logo=dotnet&style=for-the-badge)

### 💎 A few more gems

We believe in keeping the community informed, so here's a few more tidbits of information to satisfy some additional curiosities:

![Contributors](https://img.shields.io/github/contributors/tacosontitan/Lily?logo=github&style=for-the-badge)
![Issues](https://img.shields.io/github/issues/tacosontitan/Lily?logo=github&style=for-the-badge)
![Stars](https://img.shields.io/github/stars/tacosontitan/Lily?logo=github&style=for-the-badge)
![Size](https://img.shields.io/github/languages/code-size/tacosontitan/Lily?logo=github&style=for-the-badge)
![Line Count](https://img.shields.io/tokei/lines/github/tacosontitan/Lily?logo=github&style=for-the-badge)

## 🔑 Managing your secrets

There are two ways this repository uses secrets.

### 👤 VS Code User Secrets

Install the dotnet user-secrets tool by running the following command in the root directory of your project:

```bash
dotnet tool install --global dotnet-user-secrets
```

Then set your bot's token:

```bash
dotnet user-secrets set discordToken YOUR_TOKEN_HERE
```

### 🐋 Docker environment variables

When running the bot in Docker, you need to pass your secrets as environment variables:

- Create a `.env` file at the repo's root directory.
  - There's a `.envsample` file there you can copy from.
- Add your bot's Discord token to the `.env` file under the key `discordToken`:

```env
discordToken=YOUR_TOKEN_HERE
```

## ▶️ Running the bot

To run Lily locally, open the repo in VS Code, and execute the following commands in a new terminal:

```bash
dotnet restore
dotnet build
cd src/Lily
dotnet run
```

### 🐋 Running the bot in Docker

To run Lily in Docker:

- Open the repo in VS Code.
- Ensure your Discord token is established in a `.env` file as described above.
- Execute the following command in a new terminal:

```bash
docker compose up
```

That's it, Lily is officially running in Docker!

## 🛣️ Roadmap

We don't really know where this is going yet. However, we do know a few items we'd like to see realized in the future:

- [ ] Add support for integrating with Open AI.
