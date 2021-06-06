# DiscordMantleBot
Bot for discord


Docker <br />
cd to the path where is the Dockerfile <br />
docker build --tag discordmantlebot -f  Dockerfile .. <br />
docker run -d -v F:/discord_bot/net5/bot_token:/app/bot_token -v F:/discord_bot/net5/ylyl:/app/ylyl discordmantlebot <br />
docker run -d --name DiscordMantleBot -v F:/discord_bot/net5/bot_token:/app/bot_token -v F:/discord_bot/net5/ylyl:/app/ylyl discordmantlebot <br />

Check if it's running <br />
docker logs DiscordMantleBot
